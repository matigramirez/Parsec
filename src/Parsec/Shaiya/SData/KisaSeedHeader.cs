using System.Text;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public class KisaSeedHeader : IBinary
{
    /// <summary>
    /// Encryption signature. Read as char[40]
    /// </summary>
    public string Signature { get; set; }

    public uint Checksum { get; set; }

    public uint RealSize { get; set; }

    /// <summary>
    /// Read as char[12] or char[16], depending on the header type
    /// </summary>
    public byte[] Padding { get; set; }

    public KisaSeedHeader(string signature, uint checksum, uint realSize, byte[] padding)
    {
        Signature = signature;
        Checksum = checksum;
        RealSize = realSize;
        Padding = padding;
    }

    public KisaSeedHeader(byte[] data)
    {
        Signature = Encoding.ASCII.GetString(data.SubArray(0, 40));

        var currentOffset = 40;
        Checksum = BitConverter.ToUInt32(data, currentOffset);
        currentOffset += 4;

        // Some headers have 4 extra empty bytes and the checksum comes right after them
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

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Signature.GetBytes());
        buffer.AddRange(Checksum.GetBytes());
        buffer.AddRange(RealSize.GetBytes());
        buffer.AddRange(Padding);
        return buffer;
    }
}
