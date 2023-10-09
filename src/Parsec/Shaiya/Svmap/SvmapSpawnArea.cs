using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class SvmapSpawnArea : ISerializable
{
    public int Unknown1 { get; set; }

    public SvmapFaction Faction { get; set; }

    public int Unknown2 { get; set; }

    public BoundingBox Area { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.ReadInt32();
        Faction = (SvmapFaction)binaryReader.ReadInt32();
        Unknown2 = binaryReader.ReadInt32();
        Area = binaryReader.Read<BoundingBox>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Unknown1);
        binaryWriter.Write((int)Faction);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Area);
    }
}
