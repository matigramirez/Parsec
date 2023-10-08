using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class SvmapNpc : ISerializable
{
    public int NpcType { get; set; }

    public int NpcId { get; set; }

    public List<SvmapNpcPosition> Positions { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        NpcType = binaryReader.ReadInt32();
        NpcId = binaryReader.ReadInt32();
        Positions = binaryReader.ReadList<SvmapNpcPosition>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(NpcType);
        binaryWriter.Write(NpcId);
        binaryWriter.Write(Positions.ToSerializable());
    }
}
