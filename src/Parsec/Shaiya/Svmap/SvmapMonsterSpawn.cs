using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class SvmapMonsterSpawn : ISerializable
{
    public uint MobId { get; set; }

    public uint Count { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        MobId = binaryReader.ReadUInt32();
        Count = binaryReader.ReadUInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MobId);
        binaryWriter.Write(Count);
    }
}
