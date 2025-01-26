using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class Dg : FileBase
{
    public BoundingBox BoundingBox { get; set; }

    public List<String256> TextureNames { get; set; } = new();

    public int UnknownInt32 { get; set; }

    public DgNode RootNode { get; set; } = new();

    public override string Extension => "dg";

    protected override void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        TextureNames = binaryReader.ReadList<String256>().ToList();
        UnknownInt32 = binaryReader.ReadInt32();

        var value = binaryReader.ReadInt32();

        if (value > 0)
        {
            RootNode = binaryReader.Read<DgNode>();
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(TextureNames.ToSerializable());
        binaryWriter.Write(UnknownInt32);

        binaryWriter.Write(1);
        binaryWriter.Write(RootNode);
    }
}
