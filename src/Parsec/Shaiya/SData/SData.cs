using System;
using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.External;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SDATA
{
    public abstract class SData : FileBase
    {
        protected SData(string path) : base(path)
        {
        }

        [JsonConstructor]
        public SData()
        {
        }

        /// <summary>
        /// Checks if the file has the ".SData" extension
        /// </summary>
        [JsonIgnore]
        public bool IsValidSData => Path.Substring(Path.Length - 6, 6) == ".SData";

        /// <summary>
        /// Checks if the file is encrypted with the SEED algorithm
        /// </summary>
        [JsonIgnore]
        public bool IsEncrypted
        {
            get
            {
                const string encryptedFileHeader = "0001CBCEBC5B2784D3FC9A2A9DB84D1C3FEB6E99";

                string sDataHeader = Encoding.ASCII.GetString(Buffer.SubArray(0, encryptedFileHeader.Length));

                return sDataHeader == encryptedFileHeader;
            }
        }

        /// <summary>
        /// Encrypts the current SData object. Note that this will make it unreadable.
        /// </summary>
        public void Encrypt()
        {
            if (IsEncrypted)
                return;

            SetEncryptedBuffer();

            // Replace the binary reader's buffer so that the file becomes unreadable
            Array.Copy(_encryptedBuffer, _binaryReader.Buffer, _encryptedBuffer.Length);
        }

        /// <summary>
        /// Decrypts the current SData object. Note that this will make it readable through the Read method
        /// </summary>
        public void Decrypt()
        {
            if (!IsEncrypted)
                return;

            SetDecryptedBuffer();

            // Replace the binary reader's buffer so that the file becomes readable
            Array.Copy(_decryptedBuffer, _binaryReader.Buffer, _decryptedBuffer.Length);
        }

        private byte[] _encryptedBuffer;

        /// <summary>
        /// Saves an encrypted version of the file buffer, no matter the original encryption status.
        /// </summary>
        private void SetEncryptedBuffer()
        {
            if (IsEncrypted)
            {
                _encryptedBuffer = new byte[Buffer.Length];
                Array.Copy(Buffer, _encryptedBuffer, Buffer.Length);
                return;
            }

            var tempBuffer = new byte[Buffer.Length];

            Array.Copy(Buffer, tempBuffer, Buffer.Length);

            var newBufferLength = ShaiyaCrypt.encrypt(tempBuffer, (uint)tempBuffer.Length);

            _encryptedBuffer = new byte[newBufferLength];

            Array.Copy(tempBuffer, _encryptedBuffer, _encryptedBuffer.Length <= tempBuffer.Length ? _encryptedBuffer.Length : tempBuffer.Length);
        }

        [JsonIgnore]
        public byte[] EncryptedBuffer
        {
            get
            {
                SetEncryptedBuffer();
                return _encryptedBuffer;
            }
        }

        private byte[] _decryptedBuffer;

        /// <summary>
        /// Saves a decrypted version of the file buffer, no matter the original encryption status.
        /// </summary>
        private void SetDecryptedBuffer()
        {
            if (!IsEncrypted)
            {
                _decryptedBuffer = new byte[Buffer.Length];
                Array.Copy(Buffer, _decryptedBuffer, Buffer.Length);
                return;
            }

            var tempBuffer = new byte[Buffer.Length];

            Array.Copy(Buffer, tempBuffer, Buffer.Length);

            var newBufferLength = ShaiyaCrypt.decrypt(tempBuffer, (uint)tempBuffer.Length);

            _decryptedBuffer = new byte[newBufferLength];

            Array.Copy(tempBuffer, _decryptedBuffer, _decryptedBuffer.Length <= tempBuffer.Length ? _decryptedBuffer.Length : tempBuffer.Length);

            Array.Copy(_decryptedBuffer, Buffer, _decryptedBuffer.Length);
        }

        [JsonIgnore]
        public byte[] DecryptedBuffer
        {
            get
            {
                SetDecryptedBuffer();
                return _decryptedBuffer;
            }
        }

        public void ExportEncrypted(string path) =>
            FileHelper.WriteFile(path, EncryptedBuffer);

        public void ExportDecrypted(string path) =>
            FileHelper.WriteFile(path, DecryptedBuffer);
    }
}
