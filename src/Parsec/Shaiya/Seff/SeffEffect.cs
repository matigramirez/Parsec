using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;

namespace Parsec.Shaiya.Seff;

public sealed class SeffEffect
{
    [JsonConstructor]
    public SeffEffect()
    {
    }

    public SeffEffect(SBinaryReader binaryReader, int format)
    {
        Unknown1 = binaryReader.Read<int>();
        Unknown2 = binaryReader.Read<float>();
        Unknown3 = binaryReader.Read<int>();
        Unknown4 = binaryReader.Read<int>();
        Unknown5 = binaryReader.Read<int>();
        Unknown6 = binaryReader.Read<float>();

        Name = binaryReader.ReadString(Encoding.Unicode);

        Red = binaryReader.Read<byte>();
        Green = binaryReader.Read<byte>();
        Blue = binaryReader.Read<byte>();

        Unknown7 = binaryReader.Read<float>();
        Unknown8 = binaryReader.Read<float>();
        Unknown9 = binaryReader.Read<float>();
        Unknown10 = binaryReader.Read<float>();
        Unknown11 = binaryReader.Read<float>();

        UnkByte4 = binaryReader.Read<byte>();

        Unknown12 = binaryReader.Read<float>();

        if (format > 2)
            Unknown13 = binaryReader.Read<float>();

        if (format > 3)
            Unknown14 = binaryReader.Read<float>();

        if (format > 5)
            Unknown15 = binaryReader.Read<uint>();
    }

    public int Unknown1 { get; set; }
    public float Unknown2 { get; set; }
    public int Unknown3 { get; set; }
    public int Unknown4 { get; set; }
    public int Unknown5 { get; set; }
    public float Unknown6 { get; set; }

    public string Name { get; set; }

    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }

    public float Unknown7 { get; set; }
    public float Unknown8 { get; set; }
    public float Unknown9 { get; set; }
    public float Unknown10 { get; set; }
    public float Unknown11 { get; set; }

    public byte UnkByte4 { get; set; }

    public float Unknown12 { get; set; }
    public float Unknown13 { get; set; }
    public float Unknown14 { get; set; }
    public uint Unknown15 { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        int format = 0;

        if (options.Length > 0)
            format = (int)options[0];

        var buffer = new List<byte>();

        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        buffer.AddRange(Unknown3.GetBytes());
        buffer.AddRange(Unknown4.GetBytes());
        buffer.AddRange(Unknown5.GetBytes());
        buffer.AddRange(Unknown6.GetBytes());

        buffer.AddRange(Name.GetLengthPrefixedBytes(Encoding.Unicode, false));

        buffer.Add(Red);
        buffer.Add(Green);
        buffer.Add(Blue);

        buffer.AddRange(Unknown7.GetBytes());
        buffer.AddRange(Unknown8.GetBytes());
        buffer.AddRange(Unknown9.GetBytes());
        buffer.AddRange(Unknown10.GetBytes());
        buffer.AddRange(Unknown11.GetBytes());

        buffer.Add(UnkByte4);

        buffer.AddRange(Unknown12.GetBytes());

        if (format > 2)
            buffer.AddRange(Unknown13.GetBytes());

        if (format > 3)
            buffer.AddRange(Unknown14.GetBytes());

        if (format > 5)
            buffer.AddRange(Unknown15.GetBytes());

        return buffer;
    }
}
