using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Skill;

public sealed class DBSkillDataRecord : IBinarySDataRecord
{
    /// <summary>
    /// Id of skill.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Level of skill.
    /// </summary>
    public long SkillLevel { get; set; }

    /// <summary>
    /// Skill icon.
    /// </summary>
    public long Image { get; set; }

    /// <summary>
    /// Skill animation.
    /// </summary>
    public long Ani { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long Effect { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long ToggleType { get; set; }

    /// <summary>
    /// Skill sound effect.
    /// </summary>
    public long Sound { get; set; }

    /// <summary>
    /// Character required level.
    /// </summary>
    public long Level { get; set; }

    /// <summary>
    /// Which faction and profession can use this skill.
    /// </summary>
    public long Country { get; set; }

    /// <summary>
    /// Indicates if skill can be used by fighter.
    /// </summary>
    public long AttackFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by defender.
    /// </summary>
    public long DefenseFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by ranger.
    /// </summary>
    public long PatrolRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by archer.
    /// </summary>
    public long ShootRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by mage.
    /// </summary>
    public long AttackMage { get; set; }

    /// <summary>
    /// Indicates if skill can be used by priest.
    /// </summary>
    public long DefenseMage { get; set; }

    /// <summary>
    /// Skill can be used in basic/ultimate mode.
    /// </summary>
    public long Grow { get; set; }

    /// <summary>
    /// How many skill points are needed in order to learn this skill.
    /// </summary>
    public long Point { get; set; }

    /// <summary>
    /// Category of skill. E.g. combat or special.
    /// </summary>
    public long TypeShow { get; set; }

    /// <summary>
    /// Passive, physical, magic or shooting attack.
    /// </summary>
    public long TypeAttack { get; set; }

    /// <summary>
    /// Additional effect description.
    /// </summary>
    public long TypeEffect { get; set; }

    /// <summary>
    /// Type detail describes what skill does.
    /// </summary>
    public long Type { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Sword.
    /// </summary>
    public long NeedWeapon1 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Sword.
    /// </summary>
    public long NeedWeapon2 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Axe.
    /// </summary>
    public long NeedWeapon3 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Axe.
    /// </summary>
    public long NeedWeapon4 { get; set; }

    /// <summary>
    /// Skill requires Double Sword.
    /// </summary>
    public long NeedWeapon5 { get; set; }

    /// <summary>
    /// Skill requires Spear.
    /// </summary>
    public long NeedWeapon6 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Blunt.
    /// </summary>
    public long NeedWeapon7 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Blunt.
    /// </summary>
    public long NeedWeapon8 { get; set; }

    /// <summary>
    /// Skill requires Reverse sword.
    /// </summary>
    public long NeedWeapon9 { get; set; }

    /// <summary>
    /// Skill requires Dagger.
    /// </summary>
    public long NeedWeapon10 { get; set; }

    /// <summary>
    /// Skill requires Javelin.
    /// </summary>
    public long NeedWeapon11 { get; set; }

    /// <summary>
    /// Skill requires Staff.
    /// </summary>
    public long NeedWeapon12 { get; set; }

    /// <summary>
    /// Skill requires Bow.
    /// </summary>
    public long NeedWeapon13 { get; set; }

    /// <summary>
    /// Skill requires Crossbow.
    /// </summary>
    public long NeedWeapon14 { get; set; }

    /// <summary>
    /// Skill requires Knuckle.
    /// </summary>
    public long NeedWeapon15 { get; set; }

    /// <summary>
    /// Skill requires shield.
    /// </summary>
    public long Shield { get; set; }

    /// <summary>
    /// How many stamina points requires the skill.
    /// </summary>
    public long SP { get; set; }

    /// <summary>
    /// How many mana points requires the skill.
    /// </summary>
    public long MP { get; set; }

    /// <summary>
    /// Cast time.
    /// </summary>
    public long ReadyTime { get; set; }

    /// <summary>
    /// Time after which skill can be used again.
    /// </summary>
    public long ResetTime { get; set; }

    /// <summary>
    /// How many meters are needed in order to use the skill.
    /// </summary>
    public long AttackRange { get; set; }

    /// <summary>
    /// State type contains information about what bad influence debuff has on target.
    /// </summary>
    public long StateType { get; set; }

    /// <summary>
    /// None or fire/wind/earth/water.
    /// </summary>
    public long AttribType { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long Disable { get; set; }

    /// <summary>
    /// Skill, that must be used before the skill.
    /// </summary>
    public long PrevSkill { get; set; }

    /// <summary>
    /// SuccessType is always 0 for passive skills and 1 for other.
    /// </summary>
    public long SuccessType { get; set; }

    /// <summary>
    /// Success chance in %.
    /// </summary>
    public long SuccessValue { get; set; }

    /// <summary>
    /// What target is required for the skill.
    /// </summary>
    public long TargetType { get; set; }

    /// <summary>
    /// Skill will be applied within X meters.
    /// </summary>
    public long ApplyRange { get; set; }

    /// <summary>
    /// Used in multiple skill attacks.
    /// </summary>
    public long MultiAttack { get; set; }

    /// <summary>
    /// Time for example for buffs. This time shows how long the skill will be applied.
    /// </summary>
    public long KeepTime { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>
    public long Weapon1 { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>
    public long Weapon2 { get; set; }

    /// <summary>
    /// Only for passive skills; passive skill speed modificator or passive attack power up.
    /// </summary>
    public long WeaponValue { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long Bag { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long Arrow { get; set; }

    /// <summary>
    /// Damage type.
    /// </summary>
    public long DamageType { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public long Damage1 { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public long Damage2 { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public long Damage3 { get; set; }

    /// <summary>
    /// Time damage type.
    /// </summary>
    public long TimeDamageType { get; set; }

    /// <summary>
    /// Either fixed hp or % hp damage made over time.
    /// </summary>
    public long TimeDamage1 { get; set; }

    /// <summary>
    /// Either fixed sp or % sp damage made over time.
    /// </summary>
    public long TimeDamage2 { get; set; }

    /// <summary>
    /// Either fixed mp or % mp damage made over time.
    /// </summary>
    public long TimeDamage3 { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public long AddDamage1 { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public long AddDamage2 { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
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

    /// <summary>
    /// How many health points can be healed.
    /// </summary>
    public long Heal1 { get; set; }

    /// <summary>
    /// How many stamina points can be healed.
    /// </summary>
    public long Heal2 { get; set; }

    /// <summary>
    /// How many mana points can be healed.
    /// </summary>
    public long Heal3 { get; set; }

    /// <summary>
    /// HP healed over time.
    /// </summary>
    public long TimeHeal1 { get; set; }

    /// <summary>
    /// SP healed over time.
    /// </summary>
    public long TimeHeal2 { get; set; }

    /// <summary>
    /// MP healed over time.
    /// </summary>
    public long TimeHeal3 { get; set; }

    /// <summary>
    /// For "Fleet Foot" it's value 2, which is block shoot attack for X %.
    /// For "Magic Veil" it's value 3, which is block X magic attacks.
    /// </summary>
    public long DefenceType { get; set; }

    /// <summary>
    /// When <see cref="DefenceType"/> is 2, it's % of blocked shoot attacks.
    /// When <see cref="DefenceType"/> is 3, it's block X magic attacks.
    /// </summary>
    public long DefenceValue { get; set; }

    /// <summary>
    /// % of hp, when this skill is activated.
    /// </summary>
    public long LimitHP { get; set; }

    /// <summary>
    /// How long the skill should be kept.
    /// </summary>
    public long FixRange { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long ChangeType { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long ChangeLevel { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public long TacticZoneBound { get; set; }

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
        TacticZoneBound = binaryReader.ReadInt64();
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
        binaryWriter.Write(TacticZoneBound);
    }
}
