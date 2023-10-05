using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Monster;

public sealed class MonsterRecord : ISerializable
{
    public string MobName { get; set; } = string.Empty;
    public short ModelId { get; set; }
    public short Level { get; set; }
    public byte AI { get; set; }
    public int HP { get; set; }
    public byte Day { get; set; }
    public byte Size { get; set; }
    public byte Element { get; set; }
    public int NormalTime { get; set; }
    public byte NormalStep { get; set; }
    public int ChaseTime { get; set; }
    public byte ChaseStep { get; set; }
    public byte AttackType1 { get; set; }
    public byte AttackElement1 { get; set; }
    public byte AttackType2 { get; set; }
    public byte AttackRange2 { get; set; }
    public byte AttackType3 { get; set; }
    public byte Unknown1 { get; set; }
    public byte Unknown2 { get; set; }
    public short QuestItemId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        MobName = binaryReader.ReadString();
        ModelId = binaryReader.ReadInt16();
        Level = binaryReader.ReadInt16();
        AI = binaryReader.ReadByte();
        HP = binaryReader.ReadInt32();
        Day = binaryReader.ReadByte();
        Size = binaryReader.ReadByte();
        Element = binaryReader.ReadByte();
        NormalTime = binaryReader.ReadInt32();
        NormalStep = binaryReader.ReadByte();
        ChaseTime = binaryReader.ReadInt32();
        ChaseStep = binaryReader.ReadByte();
        AttackType1 = binaryReader.ReadByte();
        AttackElement1 = binaryReader.ReadByte();
        AttackType2 = binaryReader.ReadByte();
        AttackRange2 = binaryReader.ReadByte();
        AttackType3 = binaryReader.ReadByte();
        Unknown1 = binaryReader.ReadByte();
        Unknown2 = binaryReader.ReadByte();
        QuestItemId = binaryReader.ReadInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MobName);
        binaryWriter.Write(ModelId);
        binaryWriter.Write(Level);
        binaryWriter.Write(AI);
        binaryWriter.Write(HP);
        binaryWriter.Write(Day);
        binaryWriter.Write(Size);
        binaryWriter.Write(Element);
        binaryWriter.Write(NormalTime);
        binaryWriter.Write(NormalStep);
        binaryWriter.Write(ChaseTime);
        binaryWriter.Write(ChaseStep);
        binaryWriter.Write(AttackType1);
        binaryWriter.Write(AttackElement1);
        binaryWriter.Write(AttackType2);
        binaryWriter.Write(AttackRange2);
        binaryWriter.Write(AttackType3);
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(QuestItemId);
    }
}
