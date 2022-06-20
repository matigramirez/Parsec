using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Monster
{
    public class DBMonsterDataRecord : IBinarySDataRecord
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

        public void Read(SBinaryReader binaryReader, params object[] options)
        {
            Id = binaryReader.Read<long>();
            Image = binaryReader.Read<long>();
            Level = binaryReader.Read<long>();
            Exp = binaryReader.Read<long>();
            Ai = binaryReader.Read<long>();
            Money1 = binaryReader.Read<long>();
            Money2 = binaryReader.Read<long>();
            Item1 = binaryReader.Read<long>();
            ItemDropRate1 = binaryReader.Read<long>();
            Item2 = binaryReader.Read<long>();
            ItemDropRate2 = binaryReader.Read<long>();
            Item3 = binaryReader.Read<long>();
            ItemDropRate3 = binaryReader.Read<long>();
            Item4 = binaryReader.Read<long>();
            ItemDropRate4 = binaryReader.Read<long>();
            Item5 = binaryReader.Read<long>();
            ItemDropRate5 = binaryReader.Read<long>();
            Item6 = binaryReader.Read<long>();
            ItemDropRate6 = binaryReader.Read<long>();
            Item7 = binaryReader.Read<long>();
            ItemDropRate7 = binaryReader.Read<long>();
            Item8 = binaryReader.Read<long>();
            ItemDropRate8 = binaryReader.Read<long>();
            Item9 = binaryReader.Read<long>();
            ItemDropRate9 = binaryReader.Read<long>();
            QuestItem = binaryReader.Read<long>();
            Hp = binaryReader.Read<long>();
            Sp = binaryReader.Read<long>();
            Mp = binaryReader.Read<long>();
            Dex = binaryReader.Read<long>();
            Wis = binaryReader.Read<long>();
            Luc = binaryReader.Read<long>();
            Day = binaryReader.Read<long>();
            Size = binaryReader.Read<long>();
            Attrib = binaryReader.Read<long>();
            Defense = binaryReader.Read<long>();
            Magic = binaryReader.Read<long>();
            State1 = binaryReader.Read<long>();
            State2 = binaryReader.Read<long>();
            State3 = binaryReader.Read<long>();
            State4 = binaryReader.Read<long>();
            State5 = binaryReader.Read<long>();
            State6 = binaryReader.Read<long>();
            State7 = binaryReader.Read<long>();
            State8 = binaryReader.Read<long>();
            State9 = binaryReader.Read<long>();
            State10 = binaryReader.Read<long>();
            State11 = binaryReader.Read<long>();
            State12 = binaryReader.Read<long>();
            State13 = binaryReader.Read<long>();
            State14 = binaryReader.Read<long>();
            State15 = binaryReader.Read<long>();
            Skill1 = binaryReader.Read<long>();
            Skill2 = binaryReader.Read<long>();
            Skill3 = binaryReader.Read<long>();
            Skill4 = binaryReader.Read<long>();
            Skill5 = binaryReader.Read<long>();
            Skill6 = binaryReader.Read<long>();
            NormalTime = binaryReader.Read<long>();
            NormalStep = binaryReader.Read<long>();
            ChaseTime = binaryReader.Read<long>();
            ChaseStep = binaryReader.Read<long>();
            ChaseRange = binaryReader.Read<long>();
            AttackAni1 = binaryReader.Read<long>();
            AttackType1 = binaryReader.Read<long>();
            AttackTime1 = binaryReader.Read<long>();
            AttackRange1 = binaryReader.Read<long>();
            Attack1 = binaryReader.Read<long>();
            AttackPlus1 = binaryReader.Read<long>();
            AttackAttrib1 = binaryReader.Read<long>();
            AttackSpecial1 = binaryReader.Read<long>();
            AttackOk1 = binaryReader.Read<long>();
            AttackAni2 = binaryReader.Read<long>();
            AttackType2 = binaryReader.Read<long>();
            AttackTime2 = binaryReader.Read<long>();
            AttackRange2 = binaryReader.Read<long>();
            Attack2 = binaryReader.Read<long>();
            AttackPlus2 = binaryReader.Read<long>();
            AttackAttrib2 = binaryReader.Read<long>();
            AttackSpecial2 = binaryReader.Read<long>();
            AttackOk2 = binaryReader.Read<long>();
            AttackAni3 = binaryReader.Read<long>();
            AttackType3 = binaryReader.Read<long>();
            AttackTime3 = binaryReader.Read<long>();
            AttackRange3 = binaryReader.Read<long>();
            Attack3 = binaryReader.Read<long>();
            AttackPlus3 = binaryReader.Read<long>();
            AttackAttrib3 = binaryReader.Read<long>();
            AttackSpecial3 = binaryReader.Read<long>();
            AttackOk3 = binaryReader.Read<long>();
            ColorType = binaryReader.Read<long>();
            ColorHue = binaryReader.Read<long>();
            ColorSaturation = binaryReader.Read<long>();
            ColorLight = binaryReader.Read<long>();
        }

        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Id.GetBytes());
            buffer.AddRange(Image.GetBytes());
            buffer.AddRange(Level.GetBytes());
            buffer.AddRange(Exp.GetBytes());
            buffer.AddRange(Ai.GetBytes());
            buffer.AddRange(Money1.GetBytes());
            buffer.AddRange(Money2.GetBytes());
            buffer.AddRange(Item1.GetBytes());
            buffer.AddRange(ItemDropRate1.GetBytes());
            buffer.AddRange(Item2.GetBytes());
            buffer.AddRange(ItemDropRate2.GetBytes());
            buffer.AddRange(Item3.GetBytes());
            buffer.AddRange(ItemDropRate3.GetBytes());
            buffer.AddRange(Item4.GetBytes());
            buffer.AddRange(ItemDropRate4.GetBytes());
            buffer.AddRange(Item5.GetBytes());
            buffer.AddRange(ItemDropRate5.GetBytes());
            buffer.AddRange(Item6.GetBytes());
            buffer.AddRange(ItemDropRate6.GetBytes());
            buffer.AddRange(Item7.GetBytes());
            buffer.AddRange(ItemDropRate7.GetBytes());
            buffer.AddRange(Item8.GetBytes());
            buffer.AddRange(ItemDropRate8.GetBytes());
            buffer.AddRange(Item9.GetBytes());
            buffer.AddRange(ItemDropRate9.GetBytes());
            buffer.AddRange(QuestItem.GetBytes());
            buffer.AddRange(Hp.GetBytes());
            buffer.AddRange(Sp.GetBytes());
            buffer.AddRange(Mp.GetBytes());
            buffer.AddRange(Dex.GetBytes());
            buffer.AddRange(Wis.GetBytes());
            buffer.AddRange(Luc.GetBytes());
            buffer.AddRange(Day.GetBytes());
            buffer.AddRange(Size.GetBytes());
            buffer.AddRange(Attrib.GetBytes());
            buffer.AddRange(Defense.GetBytes());
            buffer.AddRange(Magic.GetBytes());
            buffer.AddRange(State1.GetBytes());
            buffer.AddRange(State2.GetBytes());
            buffer.AddRange(State3.GetBytes());
            buffer.AddRange(State4.GetBytes());
            buffer.AddRange(State5.GetBytes());
            buffer.AddRange(State6.GetBytes());
            buffer.AddRange(State7.GetBytes());
            buffer.AddRange(State8.GetBytes());
            buffer.AddRange(State9.GetBytes());
            buffer.AddRange(State10.GetBytes());
            buffer.AddRange(State11.GetBytes());
            buffer.AddRange(State12.GetBytes());
            buffer.AddRange(State13.GetBytes());
            buffer.AddRange(State14.GetBytes());
            buffer.AddRange(State15.GetBytes());
            buffer.AddRange(Skill1.GetBytes());
            buffer.AddRange(Skill2.GetBytes());
            buffer.AddRange(Skill3.GetBytes());
            buffer.AddRange(Skill4.GetBytes());
            buffer.AddRange(Skill5.GetBytes());
            buffer.AddRange(Skill6.GetBytes());
            buffer.AddRange(NormalTime.GetBytes());
            buffer.AddRange(NormalStep.GetBytes());
            buffer.AddRange(ChaseTime.GetBytes());
            buffer.AddRange(ChaseStep.GetBytes());
            buffer.AddRange(ChaseRange.GetBytes());
            buffer.AddRange(AttackAni1.GetBytes());
            buffer.AddRange(AttackType1.GetBytes());
            buffer.AddRange(AttackTime1.GetBytes());
            buffer.AddRange(AttackRange1.GetBytes());
            buffer.AddRange(Attack1.GetBytes());
            buffer.AddRange(AttackPlus1.GetBytes());
            buffer.AddRange(AttackAttrib1.GetBytes());
            buffer.AddRange(AttackSpecial1.GetBytes());
            buffer.AddRange(AttackOk1.GetBytes());
            buffer.AddRange(AttackAni2.GetBytes());
            buffer.AddRange(AttackType2.GetBytes());
            buffer.AddRange(AttackTime2.GetBytes());
            buffer.AddRange(AttackRange2.GetBytes());
            buffer.AddRange(Attack2.GetBytes());
            buffer.AddRange(AttackPlus2.GetBytes());
            buffer.AddRange(AttackAttrib2.GetBytes());
            buffer.AddRange(AttackSpecial2.GetBytes());
            buffer.AddRange(AttackOk2.GetBytes());
            buffer.AddRange(AttackAni3.GetBytes());
            buffer.AddRange(AttackType3.GetBytes());
            buffer.AddRange(AttackTime3.GetBytes());
            buffer.AddRange(AttackRange3.GetBytes());
            buffer.AddRange(Attack3.GetBytes());
            buffer.AddRange(AttackPlus3.GetBytes());
            buffer.AddRange(AttackAttrib3.GetBytes());
            buffer.AddRange(AttackSpecial3.GetBytes());
            buffer.AddRange(AttackOk3.GetBytes());
            buffer.AddRange(ColorType.GetBytes());
            buffer.AddRange(ColorHue.GetBytes());
            buffer.AddRange(ColorSaturation.GetBytes());
            buffer.AddRange(ColorLight.GetBytes());
            return buffer;
        }
    }
}
