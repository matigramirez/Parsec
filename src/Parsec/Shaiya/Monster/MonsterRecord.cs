using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Monster;

public sealed class MonsterRecord : IBinary
{
    [JsonConstructor]
    public MonsterRecord()
    {
    }

    public MonsterRecord(SBinaryReader binaryReader)
    {
        MobName = binaryReader.ReadString();
        ModelId = binaryReader.Read<short>();
        Level = binaryReader.Read<short>();
        AI = binaryReader.Read<byte>();
        HP = binaryReader.Read<int>();
        Day = binaryReader.Read<byte>();
        Size = binaryReader.Read<byte>();
        Element = binaryReader.Read<byte>();
        NormalTime = binaryReader.Read<int>();
        NormalStep = binaryReader.Read<byte>();
        ChaseTime = binaryReader.Read<int>();
        ChaseStep = binaryReader.Read<byte>();
        AttackType1 = binaryReader.Read<byte>();
        AttackElement1 = binaryReader.Read<byte>();
        AttackType2 = binaryReader.Read<byte>();
        AttackRange2 = binaryReader.Read<byte>();
        AttackType3 = binaryReader.Read<byte>();
        Unknown1 = binaryReader.Read<byte>();
        Unknown2 = binaryReader.Read<byte>();
        QuestItemId = binaryReader.Read<short>();
    }

    public string MobName { get; set; }
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

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(MobName.GetLengthPrefixedBytes());
        buffer.AddRange(ModelId.GetBytes());
        buffer.AddRange(Level.GetBytes());
        buffer.Add(AI);
        buffer.AddRange(HP.GetBytes());
        buffer.Add(Day);
        buffer.Add(Size);
        buffer.Add(Element);
        buffer.AddRange(NormalTime.GetBytes());
        buffer.Add(NormalStep);
        buffer.AddRange(ChaseTime.GetBytes());
        buffer.Add(ChaseStep);
        buffer.Add(AttackType1);
        buffer.Add(AttackElement1);
        buffer.Add(AttackType2);
        buffer.Add(AttackRange2);
        buffer.Add(AttackType3);
        buffer.Add(Unknown1);
        buffer.Add(Unknown2);
        buffer.AddRange(QuestItemId.GetBytes());
        return buffer;
    }
}
