using System.Text;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mlx;

public sealed class MlxRecord : ISerializable
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string UpperTextureName { get; set; } = string.Empty;

    public string UpperMeshName { get; set; } = string.Empty;

    public int UpperNumber { get; set; } = 1;

    public string LowerTextureName { get; set; } = string.Empty;

    public string LowerMeshName { get; set; } = string.Empty;

    public int LowerNumber { get; set; } = 1;

    public string BootsTextureName { get; set; } = string.Empty;

    public string BootsMeshName { get; set; } = string.Empty;

    public int BootsNumber { get; set; } = 1;

    public string HandsTextureName { get; set; } = string.Empty;

    public string HandsMeshName { get; set; } = string.Empty;

    public int HandsNumber { get; set; } = 1;

    public void Read(SBinaryReader binaryReader)
    {
        var format = MlxFormat.MLX1;

        if (binaryReader.SerializationOptions.ExtraOption is MlxFormat optionFormat)
        {
            format = optionFormat;
        }

        // Define encoding based on format
        var stringEncoding = format == MlxFormat.MLX2 ? Encoding.Unicode : Encoding.ASCII;
        binaryReader.SerializationOptions.Encoding = stringEncoding;

        Id = binaryReader.ReadInt32();
        Name = binaryReader.ReadString();

        UpperTextureName = binaryReader.ReadString();
        UpperMeshName = binaryReader.ReadString();

        if (format == MlxFormat.MLX2)
        {
            UpperNumber = binaryReader.ReadInt32();
        }

        LowerTextureName = binaryReader.ReadString();
        LowerMeshName = binaryReader.ReadString();

        if (format == MlxFormat.MLX2)
        {
            LowerNumber = binaryReader.ReadInt32();
        }

        BootsTextureName = binaryReader.ReadString();
        BootsMeshName = binaryReader.ReadString();

        if (format == MlxFormat.MLX2)
        {
            BootsNumber = binaryReader.ReadInt32();
        }

        HandsTextureName = binaryReader.ReadString();
        HandsMeshName = binaryReader.ReadString();

        if (format == MlxFormat.MLX2)
        {
            HandsNumber = binaryReader.ReadInt32();
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var format = MlxFormat.MLX1;

        if (binaryWriter.SerializationOptions.ExtraOption is MlxFormat optionFormat)
        {
            format = optionFormat;
        }

        // Define encoding based on format
        var stringEncoding = format == MlxFormat.MLX2 ? Encoding.Unicode : Encoding.ASCII;
        binaryWriter.SerializationOptions.Encoding = stringEncoding;

        binaryWriter.Write(Id);
        binaryWriter.Write(Name);

        binaryWriter.Write(UpperTextureName);
        binaryWriter.Write(UpperMeshName);

        if (format == MlxFormat.MLX2)
        {
            binaryWriter.Write(UpperNumber);
        }

        binaryWriter.Write(LowerTextureName);
        binaryWriter.Write(LowerMeshName);

        if (format == MlxFormat.MLX2)
        {
            binaryWriter.Write(LowerNumber);
        }

        binaryWriter.Write(BootsTextureName);
        binaryWriter.Write(BootsMeshName);

        if (format == MlxFormat.MLX2)
        {
            binaryWriter.Write(BootsNumber);
        }

        binaryWriter.Write(HandsTextureName);
        binaryWriter.Write(HandsMeshName);

        if (format == MlxFormat.MLX2)
        {
            binaryWriter.Write(HandsNumber);
        }
    }
}
