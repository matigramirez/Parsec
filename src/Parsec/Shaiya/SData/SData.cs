using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Cryptography;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SDATA
{
    public class SData : FileBase
    {
        public SData(string path) : base(path)
        {
            if (IsEncrypted)
                Decrypt();
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
        /// The signature present in the header of encrypted files
        /// </summary>
        [JsonIgnore]
        private const string _encryptionSignature = "0001CBCEBC5B2784D3FC9A2A9DB84D1C3FEB6E99";

        /// <summary>
        /// Checks if the file is encrypted with the SEED algorithm
        /// </summary>
        [JsonIgnore]
        public bool IsEncrypted
        {
            get
            {
                string sDataHeader = Encoding.ASCII.GetString(Buffer.SubArray(0, _encryptionSignature.Length));
                return sDataHeader == _encryptionSignature;
            }
        }

        /// <summary>
        /// Function that encrypts the SData buffer using the SEED algorithm
        /// </summary>
        public byte[] EncryptedBuffer
        {
            get
            {
                if (IsEncrypted)
                    return Buffer;

                var data = new byte[Buffer.Length];
                Array.Copy(Buffer, data, Buffer.Length);

                var dataLength = data.Length;

                // Create SEED header
                var header = new SDataHeader(_encryptionSignature, 0, (uint)dataLength, new byte[16]);

                // Calculate and set checksum
                var checksum = uint.MaxValue;

                for (var i = 0; i < dataLength; i++)
                {
                    uint index = (checksum & 0xFF) ^ data[i];
                    uint key = SEED.ByteArrayToUInt32(SEEDConstants.ChecksumTable, index * 4);
                    key = SEED.EndianessSwap(key);
                    checksum >>= 8;
                    checksum ^= key;
                }

                header.Checksum = checksum;

                var buffer = new List<byte>();

                // Add header bytes
                buffer.AddRange(Encoding.ASCII.GetBytes(header.Signature));
                buffer.AddRange(BitConverter.GetBytes(header.Checksum));
                buffer.AddRange(BitConverter.GetBytes(header.RealSize));
                buffer.AddRange(header.Padding);

                // Encrypt in chunks of 16 bytes
                for (var i = 0; i < header.RealSize / 16; ++i)
                {
                    byte[] data16 = data[(i * 16)..((i + 1) * 16)];
                    SEED.EncryptChunk(data16, out byte[] encryptedBytes);
                    buffer.AddRange(encryptedBytes);
                }

                // Make sure the file length is a multiple of 16
                var remainingBytes = (64 + header.RealSize) % 16;

                // Add empty bytes
                for (var i = 0; i < remainingBytes; i++)
                {
                    var emptyData = new byte[16];
                    SEED.EncryptChunk(emptyData, out byte[] encryptedBytes);
                    buffer.AddRange(encryptedBytes);
                }

                return buffer.ToArray();
            }
        }

        /// <summary>
        /// Function that decrypts the SData buffer using the SEED algorithm
        /// </summary>
        protected void Decrypt()
        {
            // Check if file is encrypted
            if (!IsEncrypted)
                return;

            // Get file buffer
            var fileData = new byte[Buffer.Length];
            Array.Copy(Buffer, fileData, Buffer.Length);

            // Check 16-byte alignment
            if (fileData.Length % 16 != 0)
                throw new FormatException("SData file is not properly aligned.");

            // Read SEED Header
            var header = new SDataHeader(fileData);

            // Get data without header
            byte[] data = fileData[64..];

            var buffer = new List<byte>();

            // Decrypt in chunks of 16 bytes
            for (var i = 0; i < data.Length / 16; ++i)
            {
                // Get 16 bytes
                byte[] data16 = data[(i * 16)..((i + 1) * 16)];

                // Decrypt seed
                SEED.DecryptChunk(data16, out byte[] decryptedData);
                buffer.AddRange(decryptedData);
            }

            // Fill remaining bytes with 0
            if (buffer.Count < header.RealSize)
            {
                buffer.AddRange(new byte[header.RealSize - buffer.Count + 64]);
            }

            // TODO: Check CRC

            // Replace file buffer
            byte[] finalData = buffer.ToArray();
            Array.Copy(finalData, Buffer, header.RealSize);

            FileHelper.WriteFile("NpcQuest.Decrypted.SData", Buffer);
        }
    }
}
