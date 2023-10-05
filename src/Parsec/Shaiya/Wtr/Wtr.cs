using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wtr;

public sealed class Wtr : FileBase
{
    public float Unknown1 { get; set; }
    public uint Unknown2 { get; set; }
    public int Unknown3 { get; set; }

    /// <summary>
    /// List of texture file names with a fixed lenght of 256
    /// </summary>
    public List<String256> Textures { get; set; } = new();

    public override string Extension => "wtr";

    protected override void Read(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.ReadSingle();
        Unknown2 = binaryReader.ReadUInt32();
        Unknown3 = binaryReader.ReadInt32();
        Textures = binaryReader.ReadList<String256>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Unknown3);
        binaryWriter.Write(Textures.ToSerializable());
    }
}
