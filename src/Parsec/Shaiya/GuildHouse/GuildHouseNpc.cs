using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.GuildHouse;

public class GuildHouseNpc : ISerializable
{
    public uint NpcId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        NpcId = binaryReader.ReadUInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(NpcId);
    }
}
