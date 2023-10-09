using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mlx;

/// <summary>
/// Represents a .MLX file, which is used as an index for 3DC-DDS combinations for each class/sex combination
/// </summary>
public sealed class Mlx : FileBase
{
    public MlxFormat Format { get; set; } = MlxFormat.MLX1;

    public List<MlxRecord> Records { get; set; } = new();

    public override string Extension => "MLX";

    protected override void Read(SBinaryReader binaryReader)
    {
        // Some MLX files are empty
        if (binaryReader.StreamLength == 0)
        {
            return;
        }

        var signature = binaryReader.ReadString(4);

        if (signature == "MLX2")
        {
            Format = MlxFormat.MLX2;
        }
        else
        {
            Format = MlxFormat.MLX1;
            binaryReader.ResetOffset();
        }

        // MlxRecord instances expect the Format to be set as the ExtraOption on the serialization options
        binaryReader.SerializationOptions.ExtraOption = Format;
        Records = binaryReader.ReadList<MlxRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        if (Format == MlxFormat.MLX2)
        {
            binaryWriter.Write("MLX2", isLengthPrefixed: false, includeStringTerminator: false);
        }

        // MlxRecord instances expect the Format to be set as the ExtraOption on the serialization options
        binaryWriter.SerializationOptions.ExtraOption = Format;
        binaryWriter.Write(Records.ToSerializable());
    }
}
