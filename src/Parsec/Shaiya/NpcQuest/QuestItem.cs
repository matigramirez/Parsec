using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class QuestItem : ISerializable
{
    public byte Type { get; set; }

    public byte TypeId { get; set; }

    public byte Count { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Type = binaryReader.ReadByte();
        TypeId = binaryReader.ReadByte();
        Count = binaryReader.ReadByte();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Type);
        binaryWriter.Write(TypeId);
        binaryWriter.Write(Count);
    }
}
