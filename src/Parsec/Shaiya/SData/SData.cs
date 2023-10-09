using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Cryptography;
using Parsec.Helpers;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public abstract class SData : FileBase, IEncryptable
{
    /// <summary>
    /// The signature present in the header of encrypted files
    /// </summary>
    [JsonIgnore]
    private const string SEED_SIGNATURE = "0001CBCEBC5B2784D3FC9A2A9DB84D1C3FEB6E99";

    /// <summary>
    /// KISA SEED chunk size in bytes
    /// </summary>
    [JsonIgnore]
    private const int CHUNK_SIZE = 16;

    /// <summary>
    /// KISA SEED Header size in bytes
    /// </summary>
    [JsonIgnore]
    private const int HEADER_SIZE = 64;

    [JsonIgnore]
    public override string Extension => "SData";

    /// <inheritdoc />
    public void DecryptBuffer(SBinaryReader binaryReader, bool validateChecksum = false)
    {
        var fileBuffer = binaryReader.ReadAllBytes();

        if (!IsEncrypted(fileBuffer))
        {
            binaryReader.ResetOffset();
            return;
        }

        var decryptedBuffer = Decrypt(fileBuffer, validateChecksum);
        binaryReader.ResetBuffer(decryptedBuffer);
    }

    /// <inheritdoc />
    public byte[] GetEncryptedBytes()
    {
        var version = Episode == Episode.EP8 ? SDataVersion.Binary : SDataVersion.Regular;
        var serializationOptions = new BinarySerializationOptions(Episode, Encoding);

        var memoryStream = new MemoryStream();
        var binaryWriter = new SBinaryWriter(memoryStream, serializationOptions);
        Write(binaryWriter);

        var encryptedBuffer = Encrypt(memoryStream.ToArray(), version);
        return encryptedBuffer;
    }

    /// <inheritdoc />
    public void WriteEncrypted(string path)
    {
        var encryptedBuffer = GetEncryptedBytes();
        FileHelper.WriteFile(path, encryptedBuffer);
    }

    /// <inheritdoc />
    public void WriteDecrypted(string path) => Write(path);

    /// <summary>
    /// Checks if the file is encrypted with the SEED algorithm
    /// </summary>
    public static bool IsEncrypted(byte[] data)
    {
        if (data.Length < SEED_SIGNATURE.Length)
            return false;

        var sDataHeader = Encoding.ASCII.GetString(data.AsSpan().Slice(0, SEED_SIGNATURE.Length).ToArray());
        return sDataHeader == SEED_SIGNATURE;
    }

    /// <summary>
    /// Function that encrypts the provided byte array using the SEED algorithm
    /// </summary>
    /// <param name="decryptedData">The decrypted byte array</param>
    /// <param name="version">Indicates whether the SData version is Pre-EP8 (Regular) or EP8 (Binary)</param>
    public static byte[] Encrypt(byte[] decryptedData, SDataVersion version = SDataVersion.Regular)
    {
        // Check if data is decrypted
        if (IsEncrypted(decryptedData))
            return decryptedData;

        var padding = version == SDataVersion.Regular ? new byte[16] : new byte[12];
        var header = new SeedHeader(SEED_SIGNATURE, 0, (uint)decryptedData.Length, padding);
        var alignmentSize = header.RealSize;

        if (alignmentSize % CHUNK_SIZE != 0)
            alignmentSize = header.RealSize + (CHUNK_SIZE - header.RealSize % CHUNK_SIZE);

        // Create data array including the extra alignment bytes
        var data = new byte[alignmentSize];
        Array.Copy(decryptedData, data, decryptedData.Length);

        // Calculate and set checksum
        var checksum = uint.MaxValue;

        for (var i = 0; i < header.RealSize; i++)
        {
            var index = (checksum & 0xFF) ^ decryptedData[i];
            var key = Seed.ByteArrayToUInt32(SeedConstants.ChecksumTable, index * 4);
            Seed.EndiannessSwap(ref key);
            checksum >>= 8;
            checksum ^= key;
        }

        // Final checksum is the bitwise complement of the previously calculated value
        header.Checksum = ~checksum;

        var buffer = new List<byte>();
        buffer.AddRange(header.GetBytes(version));

        // Encrypt data in chunks
        for (int i = 0; i < alignmentSize / CHUNK_SIZE; ++i)
        {
            var chunk = data.AsSpan().Slice(i * CHUNK_SIZE, CHUNK_SIZE).ToArray();
            Seed.EncryptChunk(chunk, out var encryptedChunk);
            buffer.AddRange(encryptedChunk);
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

        // Check alignment
        if (encryptedBuffer.Length % CHUNK_SIZE != 0)
            throw new FormatException("SData file is not properly aligned.");

        var header = new SeedHeader(encryptedBuffer);
        var encryptedData = encryptedBuffer.AsSpan().Slice(HEADER_SIZE);

        var data = new List<byte>();

        // Decrypt data in chunks
        for (var i = 0; i < encryptedData.Length / CHUNK_SIZE; ++i)
        {
            var chunk = encryptedData.Slice(i * CHUNK_SIZE, CHUNK_SIZE);
            Seed.DecryptChunk(chunk.ToArray(), out var decryptedChunk);
            data.AddRange(decryptedChunk);
        }

        if (validateChecksum)
        {
            var checksum = uint.MaxValue;

            // Checksum is calculated with the whole file's data except for the header (not with the real size)
            for (var i = 0; i < header.RealSize; i++)
            {
                var index = (checksum & 0xFF) ^ data[i];
                var key = Seed.ByteArrayToUInt32(SeedConstants.ChecksumTable, index * 4);
                Seed.EndiannessSwap(ref key);
                checksum >>= 8;
                checksum ^= key;
            }

            // Final checksum is the bitwise complement of the previously calculated value
            checksum = ~checksum;

            if (checksum != header.Checksum)
                throw new FormatException("Invalid SEED checksum.");
        }

        var decryptedData = new byte[header.RealSize];
        Array.Copy(data.ToArray(), decryptedData, header.RealSize);
        return decryptedData;
    }

    public static void EncryptFile(string inputFilePath, string outputFilePath, SDataVersion sDataVersion = SDataVersion.Regular)
    {
        var fileData = FileHelper.ReadBytes(inputFilePath);
        var encryptedData = Encrypt(fileData, sDataVersion);
        FileHelper.WriteFile(outputFilePath, encryptedData);
    }

    public static void DecryptFile(string inputFilePath, string outputFilePath, bool validateChecksum = false)
    {
        var fileData = FileHelper.ReadBytes(inputFilePath);
        var decryptedData = Decrypt(fileData, validateChecksum);
        FileHelper.WriteFile(outputFilePath, decryptedData);
    }
}
