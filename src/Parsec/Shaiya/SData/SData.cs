using System.Text;
using System.Text.Json.Serialization;
using Parsec.Common;
using Parsec.Cryptography;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public abstract class SData : FileBase, IEncryptable
{
    /// <summary>
    /// The signature present in the header of encrypted files
    /// </summary>
    [JsonIgnore]
    private const string SeedSignature = "0001CBCEBC5B2784D3FC9A2A9DB84D1C3FEB6E99";

    /// <summary>
    /// KISA SEED chunk size in bytes
    /// </summary>
    [JsonIgnore]
    private const int SeedChunkSize = 16;

    /// <summary>
    /// KISA SEED Header size in bytes
    /// </summary>
    [JsonIgnore]
    private const int SeedHeaderSize = 64;

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
        File.WriteAllBytes(path, encryptedBuffer);
    }

    /// <inheritdoc />
    public void WriteDecrypted(string path) => Write(path);

    /// <summary>
    /// Checks if the file is encrypted with the SEED algorithm
    /// </summary>
    public static bool IsEncrypted(byte[] data)
    {
        if (data.Length < SeedSignature.Length)
            return false;

        var sDataHeader = Encoding.ASCII.GetString(data.AsSpan().Slice(0, SeedSignature.Length).ToArray());
        return sDataHeader == SeedSignature;
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
        var header = new SeedHeader(SeedSignature, 0, (uint)decryptedData.Length, padding);
        var alignmentSize = header.RealSize;

        if (alignmentSize % SeedChunkSize != 0)
            alignmentSize = header.RealSize + (SeedChunkSize - header.RealSize % SeedChunkSize);

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
        for (int i = 0; i < alignmentSize / SeedChunkSize; ++i)
        {
            var chunk = data.AsSpan().Slice(i * SeedChunkSize, SeedChunkSize).ToArray();
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
        if (encryptedBuffer.Length % SeedChunkSize != 0)
            throw new FormatException("SData file is not properly aligned.");

        var header = new SeedHeader(encryptedBuffer);
        var encryptedData = encryptedBuffer.AsSpan().Slice(SeedHeaderSize);

        var data = new List<byte>();

        // Decrypt data in chunks
        for (var i = 0; i < encryptedData.Length / SeedChunkSize; ++i)
        {
            var chunk = encryptedData.Slice(i * SeedChunkSize, SeedChunkSize);
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
        var fileData = File.ReadAllBytes(inputFilePath);
        var encryptedData = Encrypt(fileData, sDataVersion);
        File.WriteAllBytes(outputFilePath, encryptedData);
    }

    public static void DecryptFile(string inputFilePath, string outputFilePath, bool validateChecksum = false)
    {
        var fileData = File.ReadAllBytes(inputFilePath);
        var decryptedData = Decrypt(fileData, validateChecksum);
        File.WriteAllBytes(outputFilePath, decryptedData);
    }
}
