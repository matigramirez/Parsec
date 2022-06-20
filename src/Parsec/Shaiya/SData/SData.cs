using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Cryptography;
using Parsec.Extensions;
using Parsec.Helpers;
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
        private const string SEED_SIGNATURE = "0001CBCEBC5B2784D3FC9A2A9DB84D1C3FEB6E99";

        /// <summary>
        /// Checks if the file is encrypted with the SEED algorithm
        /// </summary>
        public static bool IsEncrypted(byte[] data)
        {
            if (data.Length < SEED_SIGNATURE.Length)
                return false;

            string sDataHeader = Encoding.ASCII.GetString(data.SubArray(0, SEED_SIGNATURE.Length));
            return sDataHeader == SEED_SIGNATURE;
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
            var header = new KisaSeedHeader(SEED_SIGNATURE, 0, (uint)decryptedData.Length, new byte[16]);

            // Calculate alignment size
            var alignmentSize = header.RealSize;

            if (alignmentSize % 16 != 0)
                alignmentSize = header.RealSize + (16 - header.RealSize % 16);

            // Create data array including the extra alignment bytes
            var data = new byte[alignmentSize];
            Array.Copy(decryptedData, data, decryptedData.Length);

            // Calculate and set checksum
            var checksum = uint.MaxValue;

            for (var i = 0; i < header.RealSize; i++)
            {
                var dat = decryptedData[i];
                var index = (checksum & 0xFF) ^ dat;
                var key = SEED.ByteArrayToUInt32(SEEDConstants.ChecksumTable, index * 4);
                key = SEED.EndianessSwap(key);
                checksum >>= 8;
                checksum ^= key;
            }

            // Final checksum is the bitwise complement of the previously calculated value
            header.Checksum = ~checksum;

            var buffer = new List<byte>();

            // Add header bytes
            buffer.AddRange(header.GetBytes());

            // Encrypt in chunks of 16 bytes
            for (var i = 0; i < alignmentSize / 16; ++i)
            {
                var data16 = data.SubArray(i * 16, 16);
                SEED.EncryptChunk(data16, out var encryptedData16);
                buffer.AddRange(encryptedData16);
            }

            var encryptedData = buffer.ToArray();
            return encryptedData;
        }

        /// <summary>
        /// Function that decrypts the SData buffer using the SEED algorithm
        /// </summary>
        public static byte[] Decrypt(byte[] encryptedBuffer, bool validateChecksum = false)
        {
            // Check if data is encrypted
            if (!IsEncrypted(encryptedBuffer))
                return encryptedBuffer;

            // Check 16-byte alignment
            if (encryptedBuffer.Length % 16 != 0)
                throw new FormatException("SData file is not properly aligned.");

            // Read SEED Header
            var header = new KisaSeedHeader(encryptedBuffer);

            // Get data without header
            var encryptedData = encryptedBuffer.SubArray(64, encryptedBuffer.Length - 64);

            // Create array of decrypted data
            var data = new List<byte>();

            // Decrypt in chunks of 16 bytes
            for (var i = 0; i < encryptedData.Length / 16; ++i)
            {
                // Get 16 bytes
                var data16 = encryptedData.SubArray(i * 16, 16);

                // Decrypt seed
                SEED.DecryptChunk(data16, out var decryptedData16);
                data.AddRange(decryptedData16);
            }

            if (validateChecksum)
            {
                var checksum = uint.MaxValue;

                // Checksum is calculated with the whole file's data except for the header (not with the real size)
                for (var i = 0; i < header.RealSize; i++)
                {
                    var dat = data[i];
                    var index = (checksum & 0xFF) ^ dat;
                    var key = SEED.ByteArrayToUInt32(SEEDConstants.ChecksumTable, index * 4);
                    key = SEED.EndianessSwap(key);
                    checksum >>= 8;
                    checksum ^= key;
                }

                // Validate checksum
                checksum = ~checksum;

                if (checksum != header.Checksum)
                    throw new FormatException("Invalid SEED checksum.");
            }

            var decryptedData = new byte[header.RealSize];
            Array.Copy(data.ToArray(), decryptedData, header.RealSize);
            return decryptedData;
        }

        /// <inheritdoc />
        public void DecryptBuffer(bool validateChecksum = false)
        {
            // Decrypt buffer if it's encrypted
            if (IsEncrypted(Buffer))
            {
                var decryptedBuffer = Decrypt(Buffer, validateChecksum);
                _binaryReader = new SBinaryReader(decryptedBuffer);
            }
        }

        /// <inheritdoc />
        public byte[] GetEncryptedBytes(Episode episode = Episode.Unknown) => Encrypt(GetBytes(episode).ToArray());

        /// <inheritdoc />
        public void WriteEncrypted(string path, Episode episode = Episode.Unknown)
        {
            var encryptedBuffer = Encrypt(GetBytes(episode).ToArray());
            FileHelper.WriteFile(path, encryptedBuffer);
        }

        /// <inheritdoc />
        public void WriteDecrypted(string path, Episode episode = Episode.Unknown) => Write(path, episode);

        public static void EncryptFile(string inputFilePath, string outputFilePath)
        {
            var fileData = FileHelper.ReadBytes(inputFilePath);
            var encryptedData = Encrypt(fileData);
            FileHelper.WriteFile(outputFilePath, encryptedData);
        }

        public static void DecryptFile(string inputFilePath, string outputFilePath, bool validateChecksum = false)
        {
            var fileData = FileHelper.ReadBytes(inputFilePath);
            var decryptedData = Decrypt(fileData, validateChecksum);
            FileHelper.WriteFile(outputFilePath, decryptedData);
        }
    }
}
