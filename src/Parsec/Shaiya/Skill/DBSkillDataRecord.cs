using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Skill
{
    public class DBSkillDataRecord : IBinarySDataRecord
    {
        public long Id { get; set; }
        public long SkillLevel { get; set; }
        public long Image { get; set; }
        public long Ani { get; set; }
        public long Effect { get; set; }
        public long ToggleType { get; set; }
        public long Sound { get; set; }
        public long Level { get; set; }
        public long Country { get; set; }
        public long AttackFighter { get; set; }
        public long DefenseFighter { get; set; }
        public long PatrolRogue { get; set; }
        public long ShootRogue { get; set; }
        public long AttackMage { get; set; }
        public long DefenseMage { get; set; }
        public long Grow { get; set; }
        public long Point { get; set; }
        public long Typeshow { get; set; }
        public long TypeAttack { get; set; }
        public long Typeeffect { get; set; }
        public long Type { get; set; }
        public long NeedWeapon1 { get; set; }
        public long NeedWeapon2 { get; set; }
        public long NeedWeapon3 { get; set; }
        public long NeedWeapon4 { get; set; }
        public long NeedWeapon5 { get; set; }
        public long NeedWeapon6 { get; set; }
        public long NeedWeapon7 { get; set; }
        public long NeedWeapon8 { get; set; }
        public long NeedWeapon9 { get; set; }
        public long NeedWeapon10 { get; set; }
        public long NeedWeapon11 { get; set; }
        public long NeedWeapon12 { get; set; }
        public long NeedWeapon13 { get; set; }
        public long NeedWeapon14 { get; set; }
        public long NeedWeapon15 { get; set; }
        public long Shield { get; set; }
        public long Sp { get; set; }
        public long Mp { get; set; }
        public long ReadyTime { get; set; }
        public long ResetTime { get; set; }
        public long AttackRange { get; set; }
        public long StateType { get; set; }
        public long AttribType { get; set; }
        public long Disable { get; set; }
        public long PrevSkill { get; set; }
        public long SuccessType { get; set; }
        public long SuccessValue { get; set; }
        public long TargetType { get; set; }
        public long ApplyRange { get; set; }
        public long MultiAttack { get; set; }
        public long KeepTime { get; set; }
        public long Weapon1 { get; set; }
        public long Weapon2 { get; set; }
        public long WeaponValue { get; set; }
        public long Bag { get; set; }
        public long Arrow { get; set; }
        public long DaMageType { get; set; }
        public long DaMage1 { get; set; }
        public long DaMage2 { get; set; }
        public long DaMage3 { get; set; }
        public long TimeDaMageType { get; set; }
        public long TimeDaMage1 { get; set; }
        public long TimeDaMage2 { get; set; }
        public long TimeDaMage3 { get; set; }
        public long AddDaMage1 { get; set; }
        public long AddDaMage2 { get; set; }
        public long AddDaMage3 { get; set; }
        public long AbilityType1 { get; set; }
        public long AbilityValue1 { get; set; }
        public long AbilityType2 { get; set; }
        public long AbilityValue2 { get; set; }
        public long AbilityType3 { get; set; }
        public long AbilityValue3 { get; set; }
        public long AbilityType4 { get; set; }
        public long AbilityValue4 { get; set; }
        public long AbilityType5 { get; set; }
        public long AbilityValue5 { get; set; }
        public long AbilityType6 { get; set; }
        public long AbilityValue6 { get; set; }
        public long AbilityType7 { get; set; }
        public long AbilityValue7 { get; set; }
        public long AbilityType8 { get; set; }
        public long AbilityValue8 { get; set; }
        public long AbilityType9 { get; set; }
        public long AbilityValue9 { get; set; }
        public long AbilityType10 { get; set; }
        public long AbilityValue10 { get; set; }
        public long Heal1 { get; set; }
        public long Heal2 { get; set; }
        public long Heal3 { get; set; }
        public long TimeHeal1 { get; set; }
        public long TimeHeal2 { get; set; }
        public long TimeHeal3 { get; set; }
        public long DefenceType { get; set; }
        public long DefenceValue { get; set; }
        public long LimitHp { get; set; }
        public long FixRange { get; set; }
        public long ChangeType { get; set; }
        public long ChangeLevel { get; set; }
        public long TacticZoneBound { get; set; }

        public void Read(SBinaryReader binaryReader, params object[] options)
        {
            Id = binaryReader.Read<long>();
            SkillLevel = binaryReader.Read<long>();
            Image = binaryReader.Read<long>();
            Ani = binaryReader.Read<long>();
            Effect = binaryReader.Read<long>();
            ToggleType = binaryReader.Read<long>();
            Sound = binaryReader.Read<long>();
            Level = binaryReader.Read<long>();
            Country = binaryReader.Read<long>();
            AttackFighter = binaryReader.Read<long>();
            DefenseFighter = binaryReader.Read<long>();
            PatrolRogue = binaryReader.Read<long>();
            ShootRogue = binaryReader.Read<long>();
            AttackMage = binaryReader.Read<long>();
            DefenseMage = binaryReader.Read<long>();
            Grow = binaryReader.Read<long>();
            Point = binaryReader.Read<long>();
            Typeshow = binaryReader.Read<long>();
            TypeAttack = binaryReader.Read<long>();
            Typeeffect = binaryReader.Read<long>();
            Type = binaryReader.Read<long>();
            NeedWeapon1 = binaryReader.Read<long>();
            NeedWeapon2 = binaryReader.Read<long>();
            NeedWeapon3 = binaryReader.Read<long>();
            NeedWeapon4 = binaryReader.Read<long>();
            NeedWeapon5 = binaryReader.Read<long>();
            NeedWeapon6 = binaryReader.Read<long>();
            NeedWeapon7 = binaryReader.Read<long>();
            NeedWeapon8 = binaryReader.Read<long>();
            NeedWeapon9 = binaryReader.Read<long>();
            NeedWeapon10 = binaryReader.Read<long>();
            NeedWeapon11 = binaryReader.Read<long>();
            NeedWeapon12 = binaryReader.Read<long>();
            NeedWeapon13 = binaryReader.Read<long>();
            NeedWeapon14 = binaryReader.Read<long>();
            NeedWeapon15 = binaryReader.Read<long>();
            Shield = binaryReader.Read<long>();
            Sp = binaryReader.Read<long>();
            Mp = binaryReader.Read<long>();
            ReadyTime = binaryReader.Read<long>();
            ResetTime = binaryReader.Read<long>();
            AttackRange = binaryReader.Read<long>();
            StateType = binaryReader.Read<long>();
            AttribType = binaryReader.Read<long>();
            Disable = binaryReader.Read<long>();
            PrevSkill = binaryReader.Read<long>();
            SuccessType = binaryReader.Read<long>();
            SuccessValue = binaryReader.Read<long>();
            TargetType = binaryReader.Read<long>();
            ApplyRange = binaryReader.Read<long>();
            MultiAttack = binaryReader.Read<long>();
            KeepTime = binaryReader.Read<long>();
            Weapon1 = binaryReader.Read<long>();
            Weapon2 = binaryReader.Read<long>();
            WeaponValue = binaryReader.Read<long>();
            Bag = binaryReader.Read<long>();
            Arrow = binaryReader.Read<long>();
            DaMageType = binaryReader.Read<long>();
            DaMage1 = binaryReader.Read<long>();
            DaMage2 = binaryReader.Read<long>();
            DaMage3 = binaryReader.Read<long>();
            TimeDaMageType = binaryReader.Read<long>();
            TimeDaMage1 = binaryReader.Read<long>();
            TimeDaMage2 = binaryReader.Read<long>();
            TimeDaMage3 = binaryReader.Read<long>();
            AddDaMage1 = binaryReader.Read<long>();
            AddDaMage2 = binaryReader.Read<long>();
            AddDaMage3 = binaryReader.Read<long>();
            AbilityType1 = binaryReader.Read<long>();
            AbilityValue1 = binaryReader.Read<long>();
            AbilityType2 = binaryReader.Read<long>();
            AbilityValue2 = binaryReader.Read<long>();
            AbilityType3 = binaryReader.Read<long>();
            AbilityValue3 = binaryReader.Read<long>();
            AbilityType4 = binaryReader.Read<long>();
            AbilityValue4 = binaryReader.Read<long>();
            AbilityType5 = binaryReader.Read<long>();
            AbilityValue5 = binaryReader.Read<long>();
            AbilityType6 = binaryReader.Read<long>();
            AbilityValue6 = binaryReader.Read<long>();
            AbilityType7 = binaryReader.Read<long>();
            AbilityValue7 = binaryReader.Read<long>();
            AbilityType8 = binaryReader.Read<long>();
            AbilityValue8 = binaryReader.Read<long>();
            AbilityType9 = binaryReader.Read<long>();
            AbilityValue9 = binaryReader.Read<long>();
            AbilityType10 = binaryReader.Read<long>();
            AbilityValue10 = binaryReader.Read<long>();
            Heal1 = binaryReader.Read<long>();
            Heal2 = binaryReader.Read<long>();
            Heal3 = binaryReader.Read<long>();
            TimeHeal1 = binaryReader.Read<long>();
            TimeHeal2 = binaryReader.Read<long>();
            TimeHeal3 = binaryReader.Read<long>();
            DefenceType = binaryReader.Read<long>();
            DefenceValue = binaryReader.Read<long>();
            LimitHp = binaryReader.Read<long>();
            FixRange = binaryReader.Read<long>();
            ChangeType = binaryReader.Read<long>();
            ChangeLevel = binaryReader.Read<long>();
            TacticZoneBound = binaryReader.Read<long>();
        }

        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Id.GetBytes());
            buffer.AddRange(SkillLevel.GetBytes());
            buffer.AddRange(Image.GetBytes());
            buffer.AddRange(Ani.GetBytes());
            buffer.AddRange(Effect.GetBytes());
            buffer.AddRange(ToggleType.GetBytes());
            buffer.AddRange(Sound.GetBytes());
            buffer.AddRange(Level.GetBytes());
            buffer.AddRange(Country.GetBytes());
            buffer.AddRange(AttackFighter.GetBytes());
            buffer.AddRange(DefenseFighter.GetBytes());
            buffer.AddRange(PatrolRogue.GetBytes());
            buffer.AddRange(ShootRogue.GetBytes());
            buffer.AddRange(AttackMage.GetBytes());
            buffer.AddRange(DefenseMage.GetBytes());
            buffer.AddRange(Grow.GetBytes());
            buffer.AddRange(Point.GetBytes());
            buffer.AddRange(Typeshow.GetBytes());
            buffer.AddRange(TypeAttack.GetBytes());
            buffer.AddRange(Typeeffect.GetBytes());
            buffer.AddRange(Type.GetBytes());
            buffer.AddRange(NeedWeapon1.GetBytes());
            buffer.AddRange(NeedWeapon2.GetBytes());
            buffer.AddRange(NeedWeapon3.GetBytes());
            buffer.AddRange(NeedWeapon4.GetBytes());
            buffer.AddRange(NeedWeapon5.GetBytes());
            buffer.AddRange(NeedWeapon6.GetBytes());
            buffer.AddRange(NeedWeapon7.GetBytes());
            buffer.AddRange(NeedWeapon8.GetBytes());
            buffer.AddRange(NeedWeapon9.GetBytes());
            buffer.AddRange(NeedWeapon10.GetBytes());
            buffer.AddRange(NeedWeapon11.GetBytes());
            buffer.AddRange(NeedWeapon12.GetBytes());
            buffer.AddRange(NeedWeapon13.GetBytes());
            buffer.AddRange(NeedWeapon14.GetBytes());
            buffer.AddRange(NeedWeapon15.GetBytes());
            buffer.AddRange(Shield.GetBytes());
            buffer.AddRange(Sp.GetBytes());
            buffer.AddRange(Mp.GetBytes());
            buffer.AddRange(ReadyTime.GetBytes());
            buffer.AddRange(ResetTime.GetBytes());
            buffer.AddRange(AttackRange.GetBytes());
            buffer.AddRange(StateType.GetBytes());
            buffer.AddRange(AttribType.GetBytes());
            buffer.AddRange(Disable.GetBytes());
            buffer.AddRange(PrevSkill.GetBytes());
            buffer.AddRange(SuccessType.GetBytes());
            buffer.AddRange(SuccessValue.GetBytes());
            buffer.AddRange(TargetType.GetBytes());
            buffer.AddRange(ApplyRange.GetBytes());
            buffer.AddRange(MultiAttack.GetBytes());
            buffer.AddRange(KeepTime.GetBytes());
            buffer.AddRange(Weapon1.GetBytes());
            buffer.AddRange(Weapon2.GetBytes());
            buffer.AddRange(WeaponValue.GetBytes());
            buffer.AddRange(Bag.GetBytes());
            buffer.AddRange(Arrow.GetBytes());
            buffer.AddRange(DaMageType.GetBytes());
            buffer.AddRange(DaMage1.GetBytes());
            buffer.AddRange(DaMage2.GetBytes());
            buffer.AddRange(DaMage3.GetBytes());
            buffer.AddRange(TimeDaMageType.GetBytes());
            buffer.AddRange(TimeDaMage1.GetBytes());
            buffer.AddRange(TimeDaMage2.GetBytes());
            buffer.AddRange(TimeDaMage3.GetBytes());
            buffer.AddRange(AddDaMage1.GetBytes());
            buffer.AddRange(AddDaMage2.GetBytes());
            buffer.AddRange(AddDaMage3.GetBytes());
            buffer.AddRange(AbilityType1.GetBytes());
            buffer.AddRange(AbilityValue1.GetBytes());
            buffer.AddRange(AbilityType2.GetBytes());
            buffer.AddRange(AbilityValue2.GetBytes());
            buffer.AddRange(AbilityType3.GetBytes());
            buffer.AddRange(AbilityValue3.GetBytes());
            buffer.AddRange(AbilityType4.GetBytes());
            buffer.AddRange(AbilityValue4.GetBytes());
            buffer.AddRange(AbilityType5.GetBytes());
            buffer.AddRange(AbilityValue5.GetBytes());
            buffer.AddRange(AbilityType6.GetBytes());
            buffer.AddRange(AbilityValue6.GetBytes());
            buffer.AddRange(AbilityType7.GetBytes());
            buffer.AddRange(AbilityValue7.GetBytes());
            buffer.AddRange(AbilityType8.GetBytes());
            buffer.AddRange(AbilityValue8.GetBytes());
            buffer.AddRange(AbilityType9.GetBytes());
            buffer.AddRange(AbilityValue9.GetBytes());
            buffer.AddRange(AbilityType10.GetBytes());
            buffer.AddRange(AbilityValue10.GetBytes());
            buffer.AddRange(Heal1.GetBytes());
            buffer.AddRange(Heal2.GetBytes());
            buffer.AddRange(Heal3.GetBytes());
            buffer.AddRange(TimeHeal1.GetBytes());
            buffer.AddRange(TimeHeal2.GetBytes());
            buffer.AddRange(TimeHeal3.GetBytes());
            buffer.AddRange(DefenceType.GetBytes());
            buffer.AddRange(DefenceValue.GetBytes());
            buffer.AddRange(LimitHp.GetBytes());
            buffer.AddRange(FixRange.GetBytes());
            buffer.AddRange(ChangeType.GetBytes());
            buffer.AddRange(ChangeLevel.GetBytes());
            buffer.AddRange(TacticZoneBound.GetBytes());
            return buffer;
        }
    }
}
