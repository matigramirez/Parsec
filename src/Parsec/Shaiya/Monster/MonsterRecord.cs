using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Monster;

public sealed class MonsterRecord : ISerializable
{
    public string MobName { get; set; } = string.Empty;

    public short ModelId { get; set; }

    public short Level { get; set; }

    public byte Ai { get; set; }

    public int Hp { get; set; }

    public byte Day { get; set; }

    public byte Size { get; set; }

    public byte Element { get; set; }

    public int NormalTime { get; set; }

    public byte NormalStep { get; set; }

    public int ChaseTime { get; set; }

    public byte ChaseStep { get; set; }

    public byte AttackType1 { get; set; }

    public byte AttackAni1 { get; set; }

    public byte AttackType2 { get; set; }

    public byte AttackAni2 { get; set; }

    public byte AttackType3 { get; set; }

    public byte AttackAni3 { get; set; }

    public byte AttackPlus3 { get; set; }

    public short QuestItemId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        MobName = binaryReader.ReadString();
        ModelId = binaryReader.ReadInt16();
        Level = binaryReader.ReadInt16();
        Ai = binaryReader.ReadByte();
        Hp = binaryReader.ReadInt32();
        Day = binaryReader.ReadByte();
        Size = binaryReader.ReadByte();
        Element = binaryReader.ReadByte();
        NormalTime = binaryReader.ReadInt32();
        NormalStep = binaryReader.ReadByte();
        ChaseTime = binaryReader.ReadInt32();
        ChaseStep = binaryReader.ReadByte();
        AttackType1 = binaryReader.ReadByte();
        AttackAni1 = binaryReader.ReadByte();
        AttackType2 = binaryReader.ReadByte();
        AttackAni2 = binaryReader.ReadByte();
        AttackType3 = binaryReader.ReadByte();
        AttackAni3 = binaryReader.ReadByte();
        AttackPlus3 = binaryReader.ReadByte();
        QuestItemId = binaryReader.ReadInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MobName);
        binaryWriter.Write(ModelId);
        binaryWriter.Write(Level);
        binaryWriter.Write(Ai);
        binaryWriter.Write(Hp);
        binaryWriter.Write(Day);
        binaryWriter.Write(Size);
        binaryWriter.Write(Element);
        binaryWriter.Write(NormalTime);
        binaryWriter.Write(NormalStep);
        binaryWriter.Write(ChaseTime);
        binaryWriter.Write(ChaseStep);
        binaryWriter.Write(AttackType1);
        binaryWriter.Write(AttackAni1);
        binaryWriter.Write(AttackType2);
        binaryWriter.Write(AttackAni2);
        binaryWriter.Write(AttackType3);
        binaryWriter.Write(AttackAni3);
        binaryWriter.Write(AttackPlus3);
        binaryWriter.Write(QuestItemId);
    }
}
