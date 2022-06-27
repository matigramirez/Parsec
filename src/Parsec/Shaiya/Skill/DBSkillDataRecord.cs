using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Skill;

public class DBSkillDataRecord : IBinarySDataRecord
{
    /// <summary>
    /// Id of skill.
    /// </summary>
    public long SkillId { get; set; }

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
    /// Skill music.
    /// </summary>
    public long Sound { get; set; }

    /// <summary>
    /// Character required level.
    /// </summary>
    public long Level { get; set; }

    /// <summary>
    /// Which faction and profession can use this skill.
    /// </summary
    public SkillUtilizer SkillUtilizer { get; set; }

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
    public TypeShow TypeShow { get; set; }

    /// <summary>
    /// Passive, physical, magic or shooting attack.
    /// </summary>
    public TypeAttack TypeAttack { get; set; }

    /// <summary>
    /// Additional effect description.
    /// </summary>
    public TypeEffect TypeEffect { get; set; }

    /// <summary>
    /// Type detail describes what skill does.
    /// </summary>
    public TypeDetail TypeDetail { get; set; }

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
    public long NeedShield { get; set; }

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
    public StateType StateType { get; set; }

    /// <summary>
    /// None or fire/wind/earth/water.
    /// </summary>
    public Element Element { get; set; }

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
    public SuccessType SuccessType { get; set; }

    /// <summary>
    /// Success chance in %.
    /// </summary>
    public long SuccessValue { get; set; }

    /// <summary>
    /// What target is required for the skill.
    /// </summary>
    public TargetType TargetType { get; set; }

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
    public DamageType DamageType { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public long DamageHP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public long DamageSP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public long DamageMP { get; set; }

    /// <summary>
    /// Time damage type.
    /// </summary>
    public TimeDamageType TimeDamageType { get; set; }

    /// <summary>
    /// Either fixed hp or % hp damage made over time.
    /// </summary>
    public long TimeDamageHP { get; set; }

    /// <summary>
    /// Either fixed sp or % sp damage made over time.
    /// </summary>
    public long TimeDamageSP { get; set; }

    /// <summary>
    /// Either fixed mp or % mp damage made over time.
    /// </summary>
    public long TimeDamageMP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public long AddDamageHP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public long AddDamageSP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public long AddDamageMP { get; set; }
    public AbilityType AbilityType1 { get; set; }
    public long AbilityValue1 { get; set; }
    public AbilityType AbilityType2 { get; set; }
    public long AbilityValue2 { get; set; }
    public AbilityType AbilityType3 { get; set; }
    public long AbilityValue3 { get; set; }
    public AbilityType AbilityType4 { get; set; }
    public long AbilityValue4 { get; set; }
    public AbilityType AbilityType5 { get; set; }
    public long AbilityValue5 { get; set; }
    public AbilityType AbilityType6 { get; set; }
    public long AbilityValue6 { get; set; }
    public AbilityType AbilityType7 { get; set; }
    public long AbilityValue7 { get; set; }
    public AbilityType AbilityType8 { get; set; }
    public long AbilityValue8 { get; set; }
    public AbilityType AbilityType9 { get; set; }
    public long AbilityValue9 { get; set; }
    public AbilityType AbilityType10 { get; set; }
    public long AbilityValue10 { get; set; }

    /// <summary>
    /// How many health points can be healed.
    /// </summary>
    public long HealHP { get; set; }

    /// <summary>
    /// How many stamina points can be healed.
    /// </summary>
    public long HealSP { get; set; }

    /// <summary>
    /// How many mana points can be healed.
    /// </summary>
    public long HealMP { get; set; }

    /// <summary>
    /// HP healed over time.
    /// </summary>
    public long TimeHealHP { get; set; }

    /// <summary>
    /// SP healed over time.
    /// </summary>
    public long TimeHealSP { get; set; }

    /// <summary>
    /// MP healed over time.
    /// </summary>
    public long TimeHealMP { get; set; }

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
    /// Is buff should be cleared after character death?
    /// </summary>
    public ClearAfterDeath FixRange { get; set; }

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

    public void Read(SBinaryReader binaryReader, params object[] options)
    {
        SkillId = binaryReader.Read<long>();
        SkillLevel = binaryReader.Read<long>();
        Image = binaryReader.Read<long>();
        Ani = binaryReader.Read<long>();
        Effect = binaryReader.Read<long>();
        ToggleType = binaryReader.Read<long>();
        Sound = binaryReader.Read<long>();
        Level = binaryReader.Read<long>();
        SkillUtilizer = (SkillUtilizer)binaryReader.Read<long>();
        AttackFighter = binaryReader.Read<long>();
        DefenseFighter = binaryReader.Read<long>();
        PatrolRogue = binaryReader.Read<long>();
        ShootRogue = binaryReader.Read<long>();
        AttackMage = binaryReader.Read<long>();
        DefenseMage = binaryReader.Read<long>();
        Grow = binaryReader.Read<long>();
        Point = binaryReader.Read<long>();
        TypeShow = (TypeShow)binaryReader.Read<long>();
        TypeAttack = (TypeAttack)binaryReader.Read<long>();
        TypeEffect = (TypeEffect)binaryReader.Read<long>();
        TypeDetail = (TypeDetail)binaryReader.Read<long>();
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
        NeedShield = binaryReader.Read<long>();
        SP = binaryReader.Read<long>();
        MP = binaryReader.Read<long>();
        ReadyTime = binaryReader.Read<long>();
        ResetTime = binaryReader.Read<long>();
        AttackRange = binaryReader.Read<long>();
        StateType = (StateType)binaryReader.Read<long>();
        Element = (Element)binaryReader.Read<long>();
        Disable = binaryReader.Read<long>();
        PrevSkill = binaryReader.Read<long>();
        SuccessType = (SuccessType)binaryReader.Read<long>();
        SuccessValue = binaryReader.Read<long>();
        TargetType = (TargetType)binaryReader.Read<long>();
        ApplyRange = binaryReader.Read<long>();
        MultiAttack = binaryReader.Read<long>();
        KeepTime = binaryReader.Read<long>();
        Weapon1 = binaryReader.Read<long>();
        Weapon2 = binaryReader.Read<long>();
        WeaponValue = binaryReader.Read<long>();
        Bag = binaryReader.Read<long>();
        Arrow = binaryReader.Read<long>();
        DamageType = (DamageType)binaryReader.Read<long>();
        DamageHP = binaryReader.Read<long>();
        DamageSP = binaryReader.Read<long>();
        DamageMP = binaryReader.Read<long>();
        TimeDamageType = (TimeDamageType)binaryReader.Read<long>();
        TimeDamageHP = binaryReader.Read<long>();
        TimeDamageSP = binaryReader.Read<long>();
        TimeDamageMP = binaryReader.Read<long>();
        AddDamageHP = binaryReader.Read<long>();
        AddDamageSP = binaryReader.Read<long>();
        AddDamageMP = binaryReader.Read<long>();
        AbilityType1 = (AbilityType)binaryReader.Read<long>();
        AbilityValue1 = binaryReader.Read<long>();
        AbilityType2 = (AbilityType)binaryReader.Read<long>();
        AbilityValue2 = binaryReader.Read<long>();
        AbilityType3 = (AbilityType)binaryReader.Read<long>();
        AbilityValue3 = binaryReader.Read<long>();
        AbilityType4 = (AbilityType)binaryReader.Read<long>();
        AbilityValue4 = binaryReader.Read<long>();
        AbilityType5 = (AbilityType)binaryReader.Read<long>();
        AbilityValue5 = binaryReader.Read<long>();
        AbilityType6 = (AbilityType)binaryReader.Read<long>();
        AbilityValue6 = binaryReader.Read<long>();
        AbilityType7 = (AbilityType)binaryReader.Read<long>();
        AbilityValue7 = binaryReader.Read<long>();
        AbilityType8 = (AbilityType)binaryReader.Read<long>();
        AbilityValue8 = binaryReader.Read<long>();
        AbilityType9 = (AbilityType)binaryReader.Read<long>();
        AbilityValue9 = binaryReader.Read<long>();
        AbilityType10 = (AbilityType)binaryReader.Read<long>();
        AbilityValue10 = binaryReader.Read<long>();
        HealHP = binaryReader.Read<long>();
        HealSP = binaryReader.Read<long>();
        HealMP = binaryReader.Read<long>();
        TimeHealHP = binaryReader.Read<long>();
        TimeHealSP = binaryReader.Read<long>();
        TimeHealMP = binaryReader.Read<long>();
        DefenceType = binaryReader.Read<long>();
        DefenceValue = binaryReader.Read<long>();
        LimitHP = binaryReader.Read<long>();
        FixRange = (ClearAfterDeath)binaryReader.Read<long>();
        ChangeType = binaryReader.Read<long>();
        ChangeLevel = binaryReader.Read<long>();
        TacticZoneBound = binaryReader.Read<long>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(SkillId.GetBytes());
        buffer.AddRange(SkillLevel.GetBytes());
        buffer.AddRange(Image.GetBytes());
        buffer.AddRange(Ani.GetBytes());
        buffer.AddRange(Effect.GetBytes());
        buffer.AddRange(ToggleType.GetBytes());
        buffer.AddRange(Sound.GetBytes());
        buffer.AddRange(Level.GetBytes());
        buffer.AddRange(((long)SkillUtilizer).GetBytes());
        buffer.AddRange(AttackFighter.GetBytes());
        buffer.AddRange(DefenseFighter.GetBytes());
        buffer.AddRange(PatrolRogue.GetBytes());
        buffer.AddRange(ShootRogue.GetBytes());
        buffer.AddRange(AttackMage.GetBytes());
        buffer.AddRange(DefenseMage.GetBytes());
        buffer.AddRange(Grow.GetBytes());
        buffer.AddRange(Point.GetBytes());
        buffer.AddRange(((long)TypeShow).GetBytes());
        buffer.AddRange(((long)TypeAttack).GetBytes());
        buffer.AddRange(((long)TypeEffect).GetBytes());
        buffer.AddRange(((long)TypeDetail).GetBytes());
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
        buffer.AddRange(NeedShield.GetBytes());
        buffer.AddRange(SP.GetBytes());
        buffer.AddRange(MP.GetBytes());
        buffer.AddRange(ReadyTime.GetBytes());
        buffer.AddRange(ResetTime.GetBytes());
        buffer.AddRange(AttackRange.GetBytes());
        buffer.AddRange(((long)StateType).GetBytes());
        buffer.AddRange(((long)Element).GetBytes());
        buffer.AddRange(Disable.GetBytes());
        buffer.AddRange(PrevSkill.GetBytes());
        buffer.AddRange(((long)SuccessType).GetBytes());
        buffer.AddRange(SuccessValue.GetBytes());
        buffer.AddRange(((long)TargetType).GetBytes());
        buffer.AddRange(ApplyRange.GetBytes());
        buffer.AddRange(MultiAttack.GetBytes());
        buffer.AddRange(KeepTime.GetBytes());
        buffer.AddRange(Weapon1.GetBytes());
        buffer.AddRange(Weapon2.GetBytes());
        buffer.AddRange(WeaponValue.GetBytes());
        buffer.AddRange(Bag.GetBytes());
        buffer.AddRange(Arrow.GetBytes());
        buffer.AddRange(((long)DamageType).GetBytes());
        buffer.AddRange(DamageHP.GetBytes());
        buffer.AddRange(DamageSP.GetBytes());
        buffer.AddRange(DamageMP.GetBytes());
        buffer.AddRange(((long)TimeDamageType).GetBytes());
        buffer.AddRange(TimeDamageHP.GetBytes());
        buffer.AddRange(TimeDamageSP.GetBytes());
        buffer.AddRange(TimeDamageMP.GetBytes());
        buffer.AddRange(AddDamageHP.GetBytes());
        buffer.AddRange(AddDamageSP.GetBytes());
        buffer.AddRange(AddDamageMP.GetBytes());
        buffer.AddRange(((long)AbilityType1).GetBytes());
        buffer.AddRange(AbilityValue1.GetBytes());
        buffer.AddRange(((long)AbilityType2).GetBytes());
        buffer.AddRange(AbilityValue2.GetBytes());
        buffer.AddRange(((long)AbilityType3).GetBytes());
        buffer.AddRange(AbilityValue3.GetBytes());
        buffer.AddRange(((long)AbilityType4).GetBytes());
        buffer.AddRange(AbilityValue4.GetBytes());
        buffer.AddRange(((long)AbilityType5).GetBytes());
        buffer.AddRange(AbilityValue5.GetBytes());
        buffer.AddRange(((long)AbilityType6).GetBytes());
        buffer.AddRange(AbilityValue6.GetBytes());
        buffer.AddRange(((long)AbilityType7).GetBytes());
        buffer.AddRange(AbilityValue7.GetBytes());
        buffer.AddRange(((long)AbilityType8).GetBytes());
        buffer.AddRange(AbilityValue8.GetBytes());
        buffer.AddRange(((long)AbilityType9).GetBytes());
        buffer.AddRange(AbilityValue9.GetBytes());
        buffer.AddRange(((long)AbilityType10).GetBytes());
        buffer.AddRange(AbilityValue10.GetBytes());
        buffer.AddRange(HealHP.GetBytes());
        buffer.AddRange(HealSP.GetBytes());
        buffer.AddRange(HealMP.GetBytes());
        buffer.AddRange(TimeHealHP.GetBytes());
        buffer.AddRange(TimeHealSP.GetBytes());
        buffer.AddRange(TimeHealMP.GetBytes());
        buffer.AddRange(DefenceType.GetBytes());
        buffer.AddRange(DefenceValue.GetBytes());
        buffer.AddRange(LimitHP.GetBytes());
        buffer.AddRange(((long)FixRange).GetBytes());
        buffer.AddRange(ChangeType.GetBytes());
        buffer.AddRange(ChangeLevel.GetBytes());
        buffer.AddRange(TacticZoneBound.GetBytes());
        return buffer;
    }
}
