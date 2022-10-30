using System.Text;
using Parsec.Extensions;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.SData;

namespace Parsec.Cryptography;

public sealed class SeedHeader : IBinary
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

        int currentOffset = 40;
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
        int paddingLength = currentOffset == 48 ? 16 : 12;
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

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var version = SDataVersion.Regular;

        if (options.Length > 0)
            version = (SDataVersion)options[0];

        var buffer = new List<byte>();
        buffer.AddRange(Signature.GetBytes());

        if (version == SDataVersion.Binary)
            buffer.AddRange(new byte[4]);

        buffer.AddRange(Checksum.GetBytes());
        buffer.AddRange(RealSize.GetBytes());
        buffer.AddRange(Padding);
        return buffer;
    }
}
