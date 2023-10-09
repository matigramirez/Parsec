using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.NpcSkill;

public sealed class DBNpcSkillDataRecord : IBinarySDataRecord
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

    public long TypeShow { get; set; }

    public long TypeAttack { get; set; }

    public long TypeEffect { get; set; }

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

    public long SP { get; set; }

    public long MP { get; set; }

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

    public long DamageType { get; set; }

    public long Damage1 { get; set; }

    public long Damage2 { get; set; }

    public long Damage3 { get; set; }

    public long TimeDamageType { get; set; }

    public long TimeDamage1 { get; set; }

    public long TimeDamage2 { get; set; }

    public long TimeDamage3 { get; set; }

    public long AddDamage1 { get; set; }

    public long AddDamage2 { get; set; }

    public long AddDamage3 { get; set; }

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

    public long LimitHP { get; set; }

    public long FixRange { get; set; }

    public long ChangeType { get; set; }

    public long ChangeLevel { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        SkillLevel = binaryReader.ReadInt64();
        Image = binaryReader.ReadInt64();
        Ani = binaryReader.ReadInt64();
        Effect = binaryReader.ReadInt64();
        ToggleType = binaryReader.ReadInt64();
        Sound = binaryReader.ReadInt64();
        Level = binaryReader.ReadInt64();
        Country = binaryReader.ReadInt64();
        AttackFighter = binaryReader.ReadInt64();
        DefenseFighter = binaryReader.ReadInt64();
        PatrolRogue = binaryReader.ReadInt64();
        ShootRogue = binaryReader.ReadInt64();
        AttackMage = binaryReader.ReadInt64();
        DefenseMage = binaryReader.ReadInt64();
        Grow = binaryReader.ReadInt64();
        Point = binaryReader.ReadInt64();
        TypeShow = binaryReader.ReadInt64();
        TypeAttack = binaryReader.ReadInt64();
        TypeEffect = binaryReader.ReadInt64();
        Type = binaryReader.ReadInt64();
        NeedWeapon1 = binaryReader.ReadInt64();
        NeedWeapon2 = binaryReader.ReadInt64();
        NeedWeapon3 = binaryReader.ReadInt64();
        NeedWeapon4 = binaryReader.ReadInt64();
        NeedWeapon5 = binaryReader.ReadInt64();
        NeedWeapon6 = binaryReader.ReadInt64();
        NeedWeapon7 = binaryReader.ReadInt64();
        NeedWeapon8 = binaryReader.ReadInt64();
        NeedWeapon9 = binaryReader.ReadInt64();
        NeedWeapon10 = binaryReader.ReadInt64();
        NeedWeapon11 = binaryReader.ReadInt64();
        NeedWeapon12 = binaryReader.ReadInt64();
        NeedWeapon13 = binaryReader.ReadInt64();
        NeedWeapon14 = binaryReader.ReadInt64();
        NeedWeapon15 = binaryReader.ReadInt64();
        Shield = binaryReader.ReadInt64();
        SP = binaryReader.ReadInt64();
        MP = binaryReader.ReadInt64();
        ReadyTime = binaryReader.ReadInt64();
        ResetTime = binaryReader.ReadInt64();
        AttackRange = binaryReader.ReadInt64();
        StateType = binaryReader.ReadInt64();
        AttribType = binaryReader.ReadInt64();
        Disable = binaryReader.ReadInt64();
        PrevSkill = binaryReader.ReadInt64();
        SuccessType = binaryReader.ReadInt64();
        SuccessValue = binaryReader.ReadInt64();
        TargetType = binaryReader.ReadInt64();
        ApplyRange = binaryReader.ReadInt64();
        MultiAttack = binaryReader.ReadInt64();
        KeepTime = binaryReader.ReadInt64();
        Weapon1 = binaryReader.ReadInt64();
        Weapon2 = binaryReader.ReadInt64();
        WeaponValue = binaryReader.ReadInt64();
        Bag = binaryReader.ReadInt64();
        Arrow = binaryReader.ReadInt64();
        DamageType = binaryReader.ReadInt64();
        Damage1 = binaryReader.ReadInt64();
        Damage2 = binaryReader.ReadInt64();
        Damage3 = binaryReader.ReadInt64();
        TimeDamageType = binaryReader.ReadInt64();
        TimeDamage1 = binaryReader.ReadInt64();
        TimeDamage2 = binaryReader.ReadInt64();
        TimeDamage3 = binaryReader.ReadInt64();
        AddDamage1 = binaryReader.ReadInt64();
        AddDamage2 = binaryReader.ReadInt64();
        AddDamage3 = binaryReader.ReadInt64();
        AbilityType1 = binaryReader.ReadInt64();
        AbilityValue1 = binaryReader.ReadInt64();
        AbilityType2 = binaryReader.ReadInt64();
        AbilityValue2 = binaryReader.ReadInt64();
        AbilityType3 = binaryReader.ReadInt64();
        AbilityValue3 = binaryReader.ReadInt64();
        AbilityType4 = binaryReader.ReadInt64();
        AbilityValue4 = binaryReader.ReadInt64();
        AbilityType5 = binaryReader.ReadInt64();
        AbilityValue5 = binaryReader.ReadInt64();
        AbilityType6 = binaryReader.ReadInt64();
        AbilityValue6 = binaryReader.ReadInt64();
        AbilityType7 = binaryReader.ReadInt64();
        AbilityValue7 = binaryReader.ReadInt64();
        AbilityType8 = binaryReader.ReadInt64();
        AbilityValue8 = binaryReader.ReadInt64();
        AbilityType9 = binaryReader.ReadInt64();
        AbilityValue9 = binaryReader.ReadInt64();
        AbilityType10 = binaryReader.ReadInt64();
        AbilityValue10 = binaryReader.ReadInt64();
        Heal1 = binaryReader.ReadInt64();
        Heal2 = binaryReader.ReadInt64();
        Heal3 = binaryReader.ReadInt64();
        TimeHeal1 = binaryReader.ReadInt64();
        TimeHeal2 = binaryReader.ReadInt64();
        TimeHeal3 = binaryReader.ReadInt64();
        DefenceType = binaryReader.ReadInt64();
        DefenceValue = binaryReader.ReadInt64();
        LimitHP = binaryReader.ReadInt64();
        FixRange = binaryReader.ReadInt64();
        ChangeType = binaryReader.ReadInt64();
        ChangeLevel = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(SkillLevel);
        binaryWriter.Write(Image);
        binaryWriter.Write(Ani);
        binaryWriter.Write(Effect);
        binaryWriter.Write(ToggleType);
        binaryWriter.Write(Sound);
        binaryWriter.Write(Level);
        binaryWriter.Write(Country);
        binaryWriter.Write(AttackFighter);
        binaryWriter.Write(DefenseFighter);
        binaryWriter.Write(PatrolRogue);
        binaryWriter.Write(ShootRogue);
        binaryWriter.Write(AttackMage);
        binaryWriter.Write(DefenseMage);
        binaryWriter.Write(Grow);
        binaryWriter.Write(Point);
        binaryWriter.Write(TypeShow);
        binaryWriter.Write(TypeAttack);
        binaryWriter.Write(TypeEffect);
        binaryWriter.Write(Type);
        binaryWriter.Write(NeedWeapon1);
        binaryWriter.Write(NeedWeapon2);
        binaryWriter.Write(NeedWeapon3);
        binaryWriter.Write(NeedWeapon4);
        binaryWriter.Write(NeedWeapon5);
        binaryWriter.Write(NeedWeapon6);
        binaryWriter.Write(NeedWeapon7);
        binaryWriter.Write(NeedWeapon8);
        binaryWriter.Write(NeedWeapon9);
        binaryWriter.Write(NeedWeapon10);
        binaryWriter.Write(NeedWeapon11);
        binaryWriter.Write(NeedWeapon12);
        binaryWriter.Write(NeedWeapon13);
        binaryWriter.Write(NeedWeapon14);
        binaryWriter.Write(NeedWeapon15);
        binaryWriter.Write(Shield);
        binaryWriter.Write(SP);
        binaryWriter.Write(MP);
        binaryWriter.Write(ReadyTime);
        binaryWriter.Write(ResetTime);
        binaryWriter.Write(AttackRange);
        binaryWriter.Write(StateType);
        binaryWriter.Write(AttribType);
        binaryWriter.Write(Disable);
        binaryWriter.Write(PrevSkill);
        binaryWriter.Write(SuccessType);
        binaryWriter.Write(SuccessValue);
        binaryWriter.Write(TargetType);
        binaryWriter.Write(ApplyRange);
        binaryWriter.Write(MultiAttack);
        binaryWriter.Write(KeepTime);
        binaryWriter.Write(Weapon1);
        binaryWriter.Write(Weapon2);
        binaryWriter.Write(WeaponValue);
        binaryWriter.Write(Bag);
        binaryWriter.Write(Arrow);
        binaryWriter.Write(DamageType);
        binaryWriter.Write(Damage1);
        binaryWriter.Write(Damage2);
        binaryWriter.Write(Damage3);
        binaryWriter.Write(TimeDamageType);
        binaryWriter.Write(TimeDamage1);
        binaryWriter.Write(TimeDamage2);
        binaryWriter.Write(TimeDamage3);
        binaryWriter.Write(AddDamage1);
        binaryWriter.Write(AddDamage2);
        binaryWriter.Write(AddDamage3);
        binaryWriter.Write(AbilityType1);
        binaryWriter.Write(AbilityValue1);
        binaryWriter.Write(AbilityType2);
        binaryWriter.Write(AbilityValue2);
        binaryWriter.Write(AbilityType3);
        binaryWriter.Write(AbilityValue3);
        binaryWriter.Write(AbilityType4);
        binaryWriter.Write(AbilityValue4);
        binaryWriter.Write(AbilityType5);
        binaryWriter.Write(AbilityValue5);
        binaryWriter.Write(AbilityType6);
        binaryWriter.Write(AbilityValue6);
        binaryWriter.Write(AbilityType7);
        binaryWriter.Write(AbilityValue7);
        binaryWriter.Write(AbilityType8);
        binaryWriter.Write(AbilityValue8);
        binaryWriter.Write(AbilityType9);
        binaryWriter.Write(AbilityValue9);
        binaryWriter.Write(AbilityType10);
        binaryWriter.Write(AbilityValue10);
        binaryWriter.Write(Heal1);
        binaryWriter.Write(Heal2);
        binaryWriter.Write(Heal3);
        binaryWriter.Write(TimeHeal1);
        binaryWriter.Write(TimeHeal2);
        binaryWriter.Write(TimeHeal3);
        binaryWriter.Write(DefenceType);
        binaryWriter.Write(DefenceValue);
        binaryWriter.Write(LimitHP);
        binaryWriter.Write(FixRange);
        binaryWriter.Write(ChangeType);
        binaryWriter.Write(ChangeLevel);
    }
}
