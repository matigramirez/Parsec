using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Cryptography;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Readers;
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
    public void DecryptBuffer(bool validateChecksum = false)
    {
        if (!IsEncrypted(Buffer))
            return;

        byte[] decryptedBuffer = Decrypt(Buffer, validateChecksum);
        _binaryReader = new SBinaryReader(decryptedBuffer);
    }

    /// <inheritdoc />
    public byte[] GetEncryptedBytes(Episode episode = Episode.Unknown, SDataVersion version = SDataVersion.Regular) =>
        Encrypt(GetBytes(episode).ToArray(), version);

    /// <inheritdoc />
    public void WriteEncrypted(string path, Episode episode = Episode.Unknown, SDataVersion version = SDataVersion.Regular)
    {
        byte[] encryptedBuffer = Encrypt(GetBytes(episode).ToArray(), version);
        FileHelper.WriteFile(path, encryptedBuffer);
    }

    /// <inheritdoc />
    public void WriteDecrypted(string path, Episode episode = Episode.Unknown) => Write(path, episode);

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
    /// <param name="version">Indicates whether the SData version is Pre-EP8 (Regular) or EP8 (Binary)</param>
    public static byte[] Encrypt(byte[] decryptedData, SDataVersion version = SDataVersion.Regular)
    {
        // Check if data is decrypted
        if (IsEncrypted(decryptedData))
            return decryptedData;

        byte[] padding = version == SDataVersion.Regular ? new byte[16] : new byte[12];
        var header = new SeedHeader(SEED_SIGNATURE, 0, (uint)decryptedData.Length, padding);
        uint alignmentSize = header.RealSize;

        if (alignmentSize % CHUNK_SIZE != 0)
            alignmentSize = header.RealSize + (CHUNK_SIZE - header.RealSize % CHUNK_SIZE);

        // Create data array including the extra alignment bytes
        byte[] data = new byte[alignmentSize];
        Array.Copy(decryptedData, data, decryptedData.Length);

        // Calculate and set checksum
        uint checksum = uint.MaxValue;

        for (int i = 0; i < header.RealSize; i++)
        {
            uint index = (checksum & 0xFF) ^ decryptedData[i];
            uint key = Seed.ByteArrayToUInt32(SeedConstants.ChecksumTable, index * 4);
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
            byte[] chunk = data.AsSpan().Slice(i * CHUNK_SIZE, CHUNK_SIZE).ToArray();
            Seed.EncryptChunk(chunk, out byte[] encryptedChunk);
            buffer.AddRange(encryptedChunk);
        }

        byte[] encryptedData = buffer.ToArray();
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
        for (int i = 0; i < encryptedData.Length / CHUNK_SIZE; ++i)
        {
            var chunk = encryptedData.Slice(i * CHUNK_SIZE, CHUNK_SIZE);
            Seed.DecryptChunk(chunk.ToArray(), out byte[] decryptedChunk);
            data.AddRange(decryptedChunk);
        }

        if (validateChecksum)
        {
            uint checksum = uint.MaxValue;

            // Checksum is calculated with the whole file's data except for the header (not with the real size)
            for (int i = 0; i < header.RealSize; i++)
            {
                uint index = (checksum & 0xFF) ^ data[i];
                uint key = Seed.ByteArrayToUInt32(SeedConstants.ChecksumTable, index * 4);
                Seed.EndiannessSwap(ref key);
                checksum >>= 8;
                checksum ^= key;
            }

            // Final checksum is the bitwise complement of the previously calculated value
            checksum = ~checksum;

            if (checksum != header.Checksum)
                throw new FormatException("Invalid SEED checksum.");
        }

        byte[] decryptedData = new byte[header.RealSize];
        Array.Copy(data.ToArray(), decryptedData, header.RealSize);
        return decryptedData;
    }

    public static void EncryptFile(string inputFilePath, string outputFilePath)
    {
        byte[] fileData = FileHelper.ReadBytes(inputFilePath);
        byte[] encryptedData = Encrypt(fileData);
        FileHelper.WriteFile(outputFilePath, encryptedData);
    }

    public static void DecryptFile(string inputFilePath, string outputFilePath, bool validateChecksum = false)
    {
        byte[] fileData = FileHelper.ReadBytes(inputFilePath);
        byte[] decryptedData = Decrypt(fileData, validateChecksum);
        FileHelper.WriteFile(outputFilePath, decryptedData);
    }
}
