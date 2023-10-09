using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class SvmapNamedArea : ISerializable
{
    public BoundingBox Area { get; set; }

    public int NameIdentifier1 { get; set; }

    public int NameIdentifier2 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Area = binaryReader.Read<BoundingBox>();
        NameIdentifier1 = binaryReader.ReadInt32();
        NameIdentifier2 = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Area);
        binaryWriter.Write(NameIdentifier1);
        binaryWriter.Write(NameIdentifier2);
    }
}
