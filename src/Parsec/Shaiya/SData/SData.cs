using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Cryptography;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData
{
    public abstract class SData : FileBase, IEncryptable
    {
        [JsonIgnore]
        public override string Extension => "SData";

        /// <summary>
        /// The signature present in the header of encrypted files
        /// </summary>
        [JsonIgnore]
        private const string _encryptionSignature = "0001CBCEBC5B2784D3FC9A2A9DB84D1C3FEB6E99";

        /// <summary>
        /// Checks if the file is encrypted with the SEED algorithm
        /// </summary>
        public static bool IsEncrypted(byte[] data)
        {
            if (data.Length < _encryptionSignature.Length)
                return false;

            string sDataHeader = Encoding.ASCII.GetString(data.SubArray(0, _encryptionSignature.Length));
            return sDataHeader == _encryptionSignature;
        }

        /// <summary>
        /// Function that encrypts the provided byte array using the SEED algorithm
        /// </summary>
        /// <param name="decryptedData">The decrypted byte array</param>
        public static byte[] Encrypt(byte[] decryptedData)
        {
            // Check if data is decrypted
            if (IsEncrypted(decryptedData))
                return decryptedData;

            // Create SEED header
            var header = new SDataHeader(_encryptionSignature, 0, (uint)decryptedData.Length, new byte[16]);

            // Calculate alignment size
            var alignmentSize = header.RealSize;

            if (alignmentSize % 16 != 0)
                alignmentSize = header.RealSize + (16 - (header.RealSize % 16));

            // Create data array including the extra alignment bytes
            var data = new byte[alignmentSize];
            Array.Copy(decryptedData, data, decryptedData.Length);

            // Calculate and set checksum
            var checksum = uint.MaxValue;

            for (var i = 0; i < alignmentSize; i++)
            {
                var dat = data[i];
                uint index = (checksum & 0xFF) ^ dat;
                uint key = SEED.ByteArrayToUInt32(SEEDConstants.ChecksumTable, index * 4);
                key = SEED.EndianessSwap(key);
                checksum >>= 8;
                checksum ^= key;
            }

            // Final checksum is the bitwise complement of the previously calculated value
            header.Checksum = ~checksum;

            var buffer = new List<byte>();

            // Add header bytes
            buffer.AddRange(Encoding.ASCII.GetBytes(header.Signature));
            buffer.AddRange(BitConverter.GetBytes(header.Checksum));
            buffer.AddRange(BitConverter.GetBytes(header.RealSize));
            buffer.AddRange(header.Padding);

            // Encrypt in chunks of 16 bytes
            for (var i = 0; i < alignmentSize / 16; ++i)
            {
                byte[] data16 = data[(i * 16)..((i + 1) * 16)];
                SEED.EncryptChunk(data16, out byte[] encryptedData16);
                buffer.AddRange(encryptedData16);
            }

            var encryptedData = buffer.ToArray();
            return encryptedData;
        }

        /// <summary>
        /// Function that decrypts the SData buffer using the SEED algorithm
        /// </summary>
        public static byte[] Decrypt(byte[] encryptedData)
        {
            // Check if data is encrypted
            if (!IsEncrypted(encryptedData))
                return encryptedData;

            // Check 16-byte alignment
            if (encryptedData.Length % 16 != 0)
                throw new FormatException("SData file is not properly aligned.");

            // Read SEED Header
            var header = new SDataHeader(encryptedData);

            // Get data without header
            byte[] data = encryptedData[64..];

            var buffer = new List<byte>();

            // Decrypt in chunks of 16 bytes
            for (var i = 0; i < data.Length / 16; ++i)
            {
                // Get 16 bytes
                byte[] data16 = data[(i * 16)..((i + 1) * 16)];

                // Decrypt seed
                SEED.DecryptChunk(data16, out byte[] decryptedData16);
                buffer.AddRange(decryptedData16);
            }

            var checksum = uint.MaxValue;

            // Checksum is calculated with the whole file's data except for the header (not with the real size)
            for (var i = 0; i < data.Length; i++)
            {
                var dat = data[i];
                uint index = (checksum & 0xFF) ^ dat;
                uint key = SEED.ByteArrayToUInt32(SEEDConstants.ChecksumTable, index * 4);
                key = SEED.EndianessSwap(key);
                checksum >>= 8;
                checksum ^= key;
            }

            // TODO: Validate checksum
            // The actual checksum is the bitwise complement of the header's checksum value
            var actualChecksum = ~header.Checksum;

            var decryptedData = new byte[header.RealSize];
            Array.Copy(buffer.ToArray(), decryptedData, header.RealSize);
            return decryptedData;
        }

        /// <inheritdoc />
        public void EncryptBuffer()
        {
            // Encrypt buffer if it's decrypted
            if (!IsEncrypted(Buffer))
            {
                var encryptedBuffer = Encrypt(Buffer);
                _binaryReader = new SBinaryReader(encryptedBuffer);
            }
        }

        /// <inheritdoc />
        public void DecryptBuffer()
        {
            // Decrypt buffer if it's encrypted
            if (IsEncrypted(Buffer))
            {
                var decryptedBuffer = Decrypt(Buffer);
                _binaryReader = new SBinaryReader(decryptedBuffer);
            }
        }
    }
}
