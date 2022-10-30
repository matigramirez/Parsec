using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MLX;

public sealed class MLXRecord : IBinary
{
    [JsonConstructor]
    public MLXRecord()
    {
    }

    public MLXRecord(SBinaryReader binaryReader, MLXFormat format)
    {
        var stringEncoding = format == MLXFormat.MLX2 ? Encoding.Unicode : Encoding.ASCII;

        Id = binaryReader.Read<int>();
        Name = binaryReader.ReadString(stringEncoding);

        UpperTextureName = binaryReader.ReadString(stringEncoding);
        Upper3DCName = binaryReader.ReadString(stringEncoding);

        if (format == MLXFormat.MLX2)
            UpperNumber = binaryReader.Read<int>();

        LowerTextureName = binaryReader.ReadString(stringEncoding);
        Lower3DCName = binaryReader.ReadString(stringEncoding);

        if (format == MLXFormat.MLX2)
            LowerNumber = binaryReader.Read<int>();

        BootsTextureName = binaryReader.ReadString(stringEncoding);
        Boots3DCName = binaryReader.ReadString(stringEncoding);

        if (format == MLXFormat.MLX2)
            BootsNumber = binaryReader.Read<int>();

        HandsTextureName = binaryReader.ReadString(stringEncoding);
        Hands3DCName = binaryReader.ReadString(stringEncoding);

        if (format == MLXFormat.MLX2)
            HandsNumber = binaryReader.Read<int>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string UpperTextureName { get; set; }
    public string Upper3DCName { get; set; }
    public int UpperNumber { get; set; } = 1;
    public string LowerTextureName { get; set; }
    public string Lower3DCName { get; set; }
    public int LowerNumber { get; set; } = 1;
    public string BootsTextureName { get; set; }
    public string Boots3DCName { get; set; }
    public int BootsNumber { get; set; } = 1;
    public string HandsTextureName { get; set; }
    public string Hands3DCName { get; set; }
    public int HandsNumber { get; set; } = 1;

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var version = MLXFormat.MLX1;

        if (options.Length > 0)
            version = (MLXFormat)options[0];

        var stringEncoding = version == MLXFormat.MLX2 ? Encoding.Unicode : Encoding.ASCII;

        var buffer = new List<byte>();
        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Name.GetLengthPrefixedBytes(stringEncoding));
        buffer.AddRange(UpperTextureName.GetLengthPrefixedBytes(stringEncoding));
        buffer.AddRange(Upper3DCName.GetLengthPrefixedBytes(stringEncoding));

        if (version == MLXFormat.MLX2)
            buffer.AddRange(UpperNumber.GetBytes());

        buffer.AddRange(LowerTextureName.GetLengthPrefixedBytes(stringEncoding));
        buffer.AddRange(Lower3DCName.GetLengthPrefixedBytes(stringEncoding));

        if (version == MLXFormat.MLX2)
            buffer.AddRange(LowerNumber.GetBytes());

        buffer.AddRange(BootsTextureName.GetLengthPrefixedBytes(stringEncoding));
        buffer.AddRange(Boots3DCName.GetLengthPrefixedBytes(stringEncoding));

        if (version == MLXFormat.MLX2)
            buffer.AddRange(BootsNumber.GetBytes());

        buffer.AddRange(HandsTextureName.GetLengthPrefixedBytes(stringEncoding));
        buffer.AddRange(Hands3DCName.GetLengthPrefixedBytes(stringEncoding));

        if (version == MLXFormat.MLX2)
            buffer.AddRange(HandsNumber.GetBytes());

        return buffer;
    }
}
