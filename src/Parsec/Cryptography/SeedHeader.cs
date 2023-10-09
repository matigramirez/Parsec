using System.Text;
using Parsec.Extensions;
using Parsec.Shaiya.SData;

namespace Parsec.Cryptography;

public sealed class SeedHeader
{
    public SeedHeader(string signature, uint checksum, uint realSize, byte[] padding)
    {
        Signature = signature;
        Checksum = checksum;
        RealSize = realSize;
        Padding = padding;
    }

    public SeedHeader(byte[] data)
    {
        Signature = Encoding.ASCII.GetString(data.SubArray(0, 40));

        var currentOffset = 40;
        Checksum = BitConverter.ToUInt32(data, currentOffset);
        currentOffset += 4;

        // BinarySData headers have 4 extra empty bytes and the checksum comes right after them
        if (Checksum == 0)
        {
            Checksum = BitConverter.ToUInt32(data, currentOffset);
            currentOffset += 4;
        }

        RealSize = BitConverter.ToUInt32(data, currentOffset);
        currentOffset += 4;

        // Depending on the header type, the padding is 12 or 16 bytes (based on the existence of the 4 empty bytes)
        var paddingLength = currentOffset == 48 ? 16 : 12;
        Padding = data.SubArray(currentOffset, paddingLength);
    }

    /// <summary>
    /// Encryption signature. Read as char[40]
    /// </summary>
    public string Signature { get; set; }

    public uint Checksum { get; set; }

    public uint RealSize { get; set; }

    /// <summary>
    /// Read as char[12] for EP4-7 and char[16] for EP8 (BinarySData)
    /// </summary>
    public byte[] Padding { get; set; }

    public IEnumerable<byte> GetBytes(SDataVersion version)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Encoding.ASCII.GetBytes(Signature));

        if (version == SDataVersion.Binary)
        {
            buffer.AddRange(new byte[4]);
        }

        buffer.AddRange(BitConverter.GetBytes(Checksum));
        buffer.AddRange(BitConverter.GetBytes(RealSize));
        buffer.AddRange(version == SDataVersion.Binary ? new byte[12] : new byte[16]);
        return buffer;
    }
}
