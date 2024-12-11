using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Monster;

public sealed class DBMonsterDataRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public long Image { get; set; }

    public long Level { get; set; }

    public long Exp { get; set; }

    public long Ai { get; set; }

    public long Money1 { get; set; }

    public long Money2 { get; set; }

    public long Item1 { get; set; }

    public long ItemDropRate1 { get; set; }

    public long Item2 { get; set; }

    public long ItemDropRate2 { get; set; }

    public long Item3 { get; set; }

    public long ItemDropRate3 { get; set; }

    public long Item4 { get; set; }

    public long ItemDropRate4 { get; set; }

    public long Item5 { get; set; }

    public long ItemDropRate5 { get; set; }

    public long Item6 { get; set; }

    public long ItemDropRate6 { get; set; }

    public long Item7 { get; set; }

    public long ItemDropRate7 { get; set; }

    public long Item8 { get; set; }

    public long ItemDropRate8 { get; set; }

    public long Item9 { get; set; }

    public long ItemDropRate9 { get; set; }

    public long QuestItem { get; set; }

    public long Hp { get; set; }

    public long Sp { get; set; }

    public long Mp { get; set; }

    public long Dex { get; set; }

    public long Wis { get; set; }

    public long Luc { get; set; }

    public long Day { get; set; }

    public long Size { get; set; }

    public long Attrib { get; set; }

    public long Defense { get; set; }

    public long Magic { get; set; }

    public long State1 { get; set; }

    public long State2 { get; set; }

    public long State3 { get; set; }

    public long State4 { get; set; }

    public long State5 { get; set; }

    public long State6 { get; set; }

    public long State7 { get; set; }

    public long State8 { get; set; }

    public long State9 { get; set; }

    public long State10 { get; set; }

    public long State11 { get; set; }

    public long State12 { get; set; }

    public long State13 { get; set; }

    public long State14 { get; set; }

    public long State15 { get; set; }

    public long Skill1 { get; set; }

    public long Skill2 { get; set; }

    public long Skill3 { get; set; }

    public long Skill4 { get; set; }

    public long Skill5 { get; set; }

    public long Skill6 { get; set; }

    public long NormalTime { get; set; }

    public long NormalStep { get; set; }

    public long ChaseTime { get; set; }

    public long ChaseStep { get; set; }

    public long ChaseRange { get; set; }

    public long AttackAni1 { get; set; }

    public long AttackType1 { get; set; }

    public long AttackTime1 { get; set; }

    public long AttackRange1 { get; set; }

    public long Attack1 { get; set; }

    public long AttackPlus1 { get; set; }

    public long AttackAttrib1 { get; set; }

    public long AttackSpecial1 { get; set; }

    public long AttackOk1 { get; set; }

    public long AttackAni2 { get; set; }

    public long AttackType2 { get; set; }

    public long AttackTime2 { get; set; }

    public long AttackRange2 { get; set; }

    public long Attack2 { get; set; }

    public long AttackPlus2 { get; set; }

    public long AttackAttrib2 { get; set; }

    public long AttackSpecial2 { get; set; }

    public long AttackOk2 { get; set; }

    public long AttackAni3 { get; set; }

    public long AttackType3 { get; set; }

    public long AttackTime3 { get; set; }

    public long AttackRange3 { get; set; }

    public long Attack3 { get; set; }

    public long AttackPlus3 { get; set; }

    public long AttackAttrib3 { get; set; }

    public long AttackSpecial3 { get; set; }

    public long AttackOk3 { get; set; }

    public long ColorType { get; set; }

    public long ColorHue { get; set; }

    public long ColorSaturation { get; set; }

    public long ColorLight { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        Image = binaryReader.ReadInt64();
        Level = binaryReader.ReadInt64();
        Exp = binaryReader.ReadInt64();
        Ai = binaryReader.ReadInt64();
        Money1 = binaryReader.ReadInt64();
        Money2 = binaryReader.ReadInt64();
        Item1 = binaryReader.ReadInt64();
        ItemDropRate1 = binaryReader.ReadInt64();
        Item2 = binaryReader.ReadInt64();
        ItemDropRate2 = binaryReader.ReadInt64();
        Item3 = binaryReader.ReadInt64();
        ItemDropRate3 = binaryReader.ReadInt64();
        Item4 = binaryReader.ReadInt64();
        ItemDropRate4 = binaryReader.ReadInt64();
        Item5 = binaryReader.ReadInt64();
        ItemDropRate5 = binaryReader.ReadInt64();
        Item6 = binaryReader.ReadInt64();
        ItemDropRate6 = binaryReader.ReadInt64();
        Item7 = binaryReader.ReadInt64();
        ItemDropRate7 = binaryReader.ReadInt64();
        Item8 = binaryReader.ReadInt64();
        ItemDropRate8 = binaryReader.ReadInt64();
        Item9 = binaryReader.ReadInt64();
        ItemDropRate9 = binaryReader.ReadInt64();
        QuestItem = binaryReader.ReadInt64();
        Hp = binaryReader.ReadInt64();
        Sp = binaryReader.ReadInt64();
        Mp = binaryReader.ReadInt64();
        Dex = binaryReader.ReadInt64();
        Wis = binaryReader.ReadInt64();
        Luc = binaryReader.ReadInt64();
        Day = binaryReader.ReadInt64();
        Size = binaryReader.ReadInt64();
        Attrib = binaryReader.ReadInt64();
        Defense = binaryReader.ReadInt64();
        Magic = binaryReader.ReadInt64();
        State1 = binaryReader.ReadInt64();
        State2 = binaryReader.ReadInt64();
        State3 = binaryReader.ReadInt64();
        State4 = binaryReader.ReadInt64();
        State5 = binaryReader.ReadInt64();
        State6 = binaryReader.ReadInt64();
        State7 = binaryReader.ReadInt64();
        State8 = binaryReader.ReadInt64();
        State9 = binaryReader.ReadInt64();
        State10 = binaryReader.ReadInt64();
        State11 = binaryReader.ReadInt64();
        State12 = binaryReader.ReadInt64();
        State13 = binaryReader.ReadInt64();
        State14 = binaryReader.ReadInt64();
        State15 = binaryReader.ReadInt64();
        Skill1 = binaryReader.ReadInt64();
        Skill2 = binaryReader.ReadInt64();
        Skill3 = binaryReader.ReadInt64();
        Skill4 = binaryReader.ReadInt64();
        Skill5 = binaryReader.ReadInt64();
        Skill6 = binaryReader.ReadInt64();
        NormalTime = binaryReader.ReadInt64();
        NormalStep = binaryReader.ReadInt64();
        ChaseTime = binaryReader.ReadInt64();
        ChaseStep = binaryReader.ReadInt64();
        ChaseRange = binaryReader.ReadInt64();
        AttackAni1 = binaryReader.ReadInt64();
        AttackType1 = binaryReader.ReadInt64();
        AttackTime1 = binaryReader.ReadInt64();
        AttackRange1 = binaryReader.ReadInt64();
        Attack1 = binaryReader.ReadInt64();
        AttackPlus1 = binaryReader.ReadInt64();
        AttackAttrib1 = binaryReader.ReadInt64();
        AttackSpecial1 = binaryReader.ReadInt64();
        AttackOk1 = binaryReader.ReadInt64();
        AttackAni2 = binaryReader.ReadInt64();
        AttackType2 = binaryReader.ReadInt64();
        AttackTime2 = binaryReader.ReadInt64();
        AttackRange2 = binaryReader.ReadInt64();
        Attack2 = binaryReader.ReadInt64();
        AttackPlus2 = binaryReader.ReadInt64();
        AttackAttrib2 = binaryReader.ReadInt64();
        AttackSpecial2 = binaryReader.ReadInt64();
        AttackOk2 = binaryReader.ReadInt64();
        AttackAni3 = binaryReader.ReadInt64();
        AttackType3 = binaryReader.ReadInt64();
        AttackTime3 = binaryReader.ReadInt64();
        AttackRange3 = binaryReader.ReadInt64();
        Attack3 = binaryReader.ReadInt64();
        AttackPlus3 = binaryReader.ReadInt64();
        AttackAttrib3 = binaryReader.ReadInt64();
        AttackSpecial3 = binaryReader.ReadInt64();
        AttackOk3 = binaryReader.ReadInt64();
        ColorType = binaryReader.ReadInt64();
        ColorHue = binaryReader.ReadInt64();
        ColorSaturation = binaryReader.ReadInt64();
        ColorLight = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Image);
        binaryWriter.Write(Level);
        binaryWriter.Write(Exp);
        binaryWriter.Write(Ai);
        binaryWriter.Write(Money1);
        binaryWriter.Write(Money2);
        binaryWriter.Write(Item1);
        binaryWriter.Write(ItemDropRate1);
        binaryWriter.Write(Item2);
        binaryWriter.Write(ItemDropRate2);
        binaryWriter.Write(Item3);
        binaryWriter.Write(ItemDropRate3);
        binaryWriter.Write(Item4);
        binaryWriter.Write(ItemDropRate4);
        binaryWriter.Write(Item5);
        binaryWriter.Write(ItemDropRate5);
        binaryWriter.Write(Item6);
        binaryWriter.Write(ItemDropRate6);
        binaryWriter.Write(Item7);
        binaryWriter.Write(ItemDropRate7);
        binaryWriter.Write(Item8);
        binaryWriter.Write(ItemDropRate8);
        binaryWriter.Write(Item9);
        binaryWriter.Write(ItemDropRate9);
        binaryWriter.Write(QuestItem);
        binaryWriter.Write(Hp);
        binaryWriter.Write(Sp);
        binaryWriter.Write(Mp);
        binaryWriter.Write(Dex);
        binaryWriter.Write(Wis);
        binaryWriter.Write(Luc);
        binaryWriter.Write(Day);
        binaryWriter.Write(Size);
        binaryWriter.Write(Attrib);
        binaryWriter.Write(Defense);
        binaryWriter.Write(Magic);
        binaryWriter.Write(State1);
        binaryWriter.Write(State2);
        binaryWriter.Write(State3);
        binaryWriter.Write(State4);
        binaryWriter.Write(State5);
        binaryWriter.Write(State6);
        binaryWriter.Write(State7);
        binaryWriter.Write(State8);
        binaryWriter.Write(State9);
        binaryWriter.Write(State10);
        binaryWriter.Write(State11);
        binaryWriter.Write(State12);
        binaryWriter.Write(State13);
        binaryWriter.Write(State14);
        binaryWriter.Write(State15);
        binaryWriter.Write(Skill1);
        binaryWriter.Write(Skill2);
        binaryWriter.Write(Skill3);
        binaryWriter.Write(Skill4);
        binaryWriter.Write(Skill5);
        binaryWriter.Write(Skill6);
        binaryWriter.Write(NormalTime);
        binaryWriter.Write(NormalStep);
        binaryWriter.Write(ChaseTime);
        binaryWriter.Write(ChaseStep);
        binaryWriter.Write(ChaseRange);
        binaryWriter.Write(AttackAni1);
        binaryWriter.Write(AttackType1);
        binaryWriter.Write(AttackTime1);
        binaryWriter.Write(AttackRange1);
        binaryWriter.Write(Attack1);
        binaryWriter.Write(AttackPlus1);
        binaryWriter.Write(AttackAttrib1);
        binaryWriter.Write(AttackSpecial1);
        binaryWriter.Write(AttackOk1);
        binaryWriter.Write(AttackAni2);
        binaryWriter.Write(AttackType2);
        binaryWriter.Write(AttackTime2);
        binaryWriter.Write(AttackRange2);
        binaryWriter.Write(Attack2);
        binaryWriter.Write(AttackPlus2);
        binaryWriter.Write(AttackAttrib2);
        binaryWriter.Write(AttackSpecial2);
        binaryWriter.Write(AttackOk2);
        binaryWriter.Write(AttackAni3);
        binaryWriter.Write(AttackType3);
        binaryWriter.Write(AttackTime3);
        binaryWriter.Write(AttackRange3);
        binaryWriter.Write(Attack3);
        binaryWriter.Write(AttackPlus3);
        binaryWriter.Write(AttackAttrib3);
        binaryWriter.Write(AttackSpecial3);
        binaryWriter.Write(AttackOk3);
        binaryWriter.Write(ColorType);
        binaryWriter.Write(ColorHue);
        binaryWriter.Write(ColorSaturation);
        binaryWriter.Write(ColorLight);
    }
}
