using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Skill;

/// <summary>
/// Class that represents a record for the Skill.SData and NpcSkill.SData formats
/// </summary>
public sealed class SkillRecord : IBinary
{
    public SkillRecord()
    {
    }

    public SkillRecord(SBinaryReader binaryReader, Episode episode, int id)
    {
        Id = id;
        Name = binaryReader.ReadString();
        Description = binaryReader.ReadString();
        SkillLevel = binaryReader.Read<byte>();
        Icon = binaryReader.Read<ushort>();
        Animation = binaryReader.Read<ushort>();

        if (episode >= Episode.EP6)
        {
            Effect = binaryReader.Read<byte>();
        }

        ToggleType = binaryReader.Read<byte>();
        Sound = binaryReader.Read<ushort>();
        RequiredLevel = binaryReader.Read<ushort>();
        Country = binaryReader.Read<byte>();
        AttackFighter = binaryReader.Read<byte>();
        DefenseFighter = binaryReader.Read<byte>();
        PatrolRogue = binaryReader.Read<byte>();
        ShootRogue = binaryReader.Read<byte>();
        AttackMage = binaryReader.Read<byte>();
        DefenseMage = binaryReader.Read<byte>();
        Grow = binaryReader.Read<byte>();
        Point = binaryReader.Read<byte>();
        TypeShow = binaryReader.Read<byte>();
        TypeAttack = binaryReader.Read<byte>();
        TypeEffect = binaryReader.Read<byte>();
        TypeDetail = binaryReader.Read<ushort>();
        NeedWeapon1 = binaryReader.Read<byte>();
        NeedWeapon2 = binaryReader.Read<byte>();
        NeedWeapon3 = binaryReader.Read<byte>();
        NeedWeapon4 = binaryReader.Read<byte>();
        NeedWeapon5 = binaryReader.Read<byte>();
        NeedWeapon6 = binaryReader.Read<byte>();
        NeedWeapon7 = binaryReader.Read<byte>();
        NeedWeapon8 = binaryReader.Read<byte>();
        NeedWeapon9 = binaryReader.Read<byte>();
        NeedWeapon10 = binaryReader.Read<byte>();
        NeedWeapon11 = binaryReader.Read<byte>();
        NeedWeapon12 = binaryReader.Read<byte>();
        NeedWeapon13 = binaryReader.Read<byte>();
        NeedWeapon14 = binaryReader.Read<byte>();
        NeedWeapon15 = binaryReader.Read<byte>();
        Shield = binaryReader.Read<byte>();
        SP = binaryReader.Read<ushort>();
        MP = binaryReader.Read<ushort>();
        ReadyTime = binaryReader.Read<byte>();
        ResetTime = binaryReader.Read<ushort>();
        AttackRange = binaryReader.Read<byte>();
        StateType = binaryReader.Read<byte>();
        AttribType = binaryReader.Read<byte>();
        Disable = binaryReader.Read<ushort>();
        PrevSkill = binaryReader.Read<ushort>();
        SuccessType = binaryReader.Read<byte>();
        SuccessValue = binaryReader.Read<byte>();
        TargetType = binaryReader.Read<byte>();
        ApplyRange = binaryReader.Read<byte>();
        MultiAttack = binaryReader.Read<byte>();
        KeepTime = binaryReader.Read<ushort>();
        Weapon1 = binaryReader.Read<byte>();
        Weapon2 = binaryReader.Read<byte>();
        WeaponValue = binaryReader.Read<byte>();
        Bag = binaryReader.Read<byte>();
        Arrow = binaryReader.Read<ushort>();
        DamageType = binaryReader.Read<byte>();
        DamageHP = binaryReader.Read<ushort>();
        DamageSP = binaryReader.Read<ushort>();
        DamageMP = binaryReader.Read<ushort>();
        TimeDamageType = binaryReader.Read<byte>();
        TimeDamageHP = binaryReader.Read<ushort>();
        TimeDamageSP = binaryReader.Read<ushort>();
        TimeDamageMP = binaryReader.Read<ushort>();
        AddDamageHP = binaryReader.Read<ushort>();
        AddDamageSP = binaryReader.Read<ushort>();
        AddDamageMP = binaryReader.Read<ushort>();
        AbilityType1 = binaryReader.Read<byte>();
        AbilityValue1 = binaryReader.Read<ushort>();
        AbilityType2 = binaryReader.Read<byte>();
        AbilityValue2 = binaryReader.Read<ushort>();
        AbilityType3 = binaryReader.Read<byte>();
        AbilityValue3 = binaryReader.Read<ushort>();

        if (episode >= Episode.EP6)
        {
            AbilityType4 = binaryReader.Read<byte>();
            AbilityValue4 = binaryReader.Read<ushort>();
            AbilityType5 = binaryReader.Read<byte>();
            AbilityValue5 = binaryReader.Read<ushort>();
            AbilityType6 = binaryReader.Read<byte>();
            AbilityValue6 = binaryReader.Read<ushort>();
            AbilityType7 = binaryReader.Read<byte>();
            AbilityValue7 = binaryReader.Read<ushort>();
            AbilityType8 = binaryReader.Read<byte>();
            AbilityValue8 = binaryReader.Read<ushort>();
            AbilityType9 = binaryReader.Read<byte>();
            AbilityValue9 = binaryReader.Read<ushort>();
            AbilityType10 = binaryReader.Read<byte>();
            AbilityValue10 = binaryReader.Read<ushort>();
        }

        HealHP = binaryReader.Read<ushort>();
        HealSP = binaryReader.Read<ushort>();
        HealMP = binaryReader.Read<ushort>();
        TimeHealHP = binaryReader.Read<ushort>();
        TimeHealSP = binaryReader.Read<ushort>();
        TimeHealMP = binaryReader.Read<ushort>();
        DefenseType = binaryReader.Read<byte>();
        DefenseValue = binaryReader.Read<byte>();
        LimitHP = binaryReader.Read<byte>();
        FixRange = binaryReader.Read<byte>();
        ChangeType = binaryReader.Read<ushort>();
        ChangeLevel = binaryReader.Read<ushort>();
    }

    /// <summary>
    /// The skill Id. It's not part of the structure itself, but it's assigned manually when reading the file.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The skill name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The skill description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Level of skill.
    /// </summary>
    public byte SkillLevel { get; set; }

    /// <summary>
    /// Skill icon.
    /// </summary>
    public ushort Icon { get; set; }

    /// <summary>
    /// Skill animation.
    /// </summary>
    public ushort Animation { get; set; }

    /// <summary>
    /// Skill Effect
    /// </summary>
    public byte Effect { get; set; }

    /// <summary>
    /// Used for toggleable skills like "Frenzied Force", "Dungeon Map Scroll", etc.
    /// </summary>
    public byte ToggleType { get; set; }

    /// <summary>
    /// Skill Sound
    /// </summary>
    public ushort Sound { get; set; }

    /// <summary>
    /// Character required level.
    /// </summary>
    public ushort RequiredLevel { get; set; }

    /// <summary>
    /// Which faction and profession can use this skill.
    /// </summary>
    public byte Country { get; set; }

    /// <summary>
    /// Indicates if skill can be used by fighter.
    /// </summary>
    public byte AttackFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by defender.
    /// </summary>
    public byte DefenseFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by ranger.
    /// </summary>
    public byte PatrolRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by archer.
    /// </summary>
    public byte ShootRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by mage.
    /// </summary>
    public byte AttackMage { get; set; }

    /// <summary>
    /// Indicates if skill can be used by priest.
    /// </summary>
    public byte DefenseMage { get; set; }

    /// <summary>
    /// Skill can be used in basic/ultimate mode.
    /// </summary>
    public byte Grow { get; set; }

    /// <summary>
    /// How many skill points are needed in order to learn this skill.
    /// </summary>
    public byte Point { get; set; }

    /// <summary>
    /// Category of skill. E.g. combat or special.
    /// </summary>
    public byte TypeShow { get; set; }

    /// <summary>
    /// Passive, physical, magic or shooting attack.
    /// </summary>
    public byte TypeAttack { get; set; }

    /// <summary>
    /// Additional effect description.
    /// </summary>
    public byte TypeEffect { get; set; }

    /// <summary>
    /// Type detail describes what skill does.
    /// </summary>
    public ushort TypeDetail { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Sword.
    /// </summary>
    public byte NeedWeapon1 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Sword.
    /// </summary>
    public byte NeedWeapon2 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Axe.
    /// </summary>
    public byte NeedWeapon3 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Axe.
    /// </summary>
    public byte NeedWeapon4 { get; set; }

    /// <summary>
    /// Skill requires Double Sword.
    /// </summary>
    public byte NeedWeapon5 { get; set; }

    /// <summary>
    /// Skill requires Spear.
    /// </summary>
    public byte NeedWeapon6 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Blunt.
    /// </summary>
    public byte NeedWeapon7 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Blunt.
    /// </summary>
    public byte NeedWeapon8 { get; set; }

    /// <summary>
    /// Skill requires Reverse sword.
    /// </summary>
    public byte NeedWeapon9 { get; set; }

    /// <summary>
    /// Skill requires Dagger.
    /// </summary>
    public byte NeedWeapon10 { get; set; }

    /// <summary>
    /// Skill requires Javelin.
    /// </summary>
    public byte NeedWeapon11 { get; set; }

    /// <summary>
    /// Skill requires Staff.
    /// </summary>
    public byte NeedWeapon12 { get; set; }

    /// <summary>
    /// Skill requires Bow.
    /// </summary>
    public byte NeedWeapon13 { get; set; }

    /// <summary>
    /// Skill requires Crossbow.
    /// </summary>
    public byte NeedWeapon14 { get; set; }

    /// <summary>
    /// Skill requires Knuckle.
    /// </summary>
    public byte NeedWeapon15 { get; set; }

    /// <summary>
    /// Skill requires shield.
    /// </summary>
    public byte Shield { get; set; }

    /// <summary>
    /// How many stamina points requires the skill.
    /// </summary>
    public ushort SP { get; set; }

    /// <summary>
    /// How many mana points requires the skill.
    /// </summary>
    public ushort MP { get; set; }

    /// <summary>
    /// Cast time.
    /// </summary>
    public byte ReadyTime { get; set; }

    /// <summary>
    /// Time after which skill can be used again.
    /// </summary>
    public ushort ResetTime { get; set; }

    /// <summary>
    /// How many meters are needed in order to use the skill.
    /// </summary>
    public byte AttackRange { get; set; }

    /// <summary>
    /// State type contains information about what bad influence debuff has on target.
    /// </summary>
    public byte StateType { get; set; }

    /// <summary>
    /// None or fire/wind/earth/water.
    /// </summary>
    public byte AttribType { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public ushort Disable { get; set; }

    /// <summary>
    /// Skill, that must be used before the skill.
    /// </summary>
    public ushort PrevSkill { get; set; }

    /// <summary>
    /// SuccessType is always 0 for passive skills and 1 for other.
    /// </summary>
    public byte SuccessType { get; set; }

    /// <summary>
    /// Success chance in %.
    /// </summary>
    public byte SuccessValue { get; set; }

    /// <summary>
    /// What target is required for the skill.
    /// </summary>
    public byte TargetType { get; set; }

    /// <summary>
    /// Skill will be applied within X meters.
    /// </summary>
    public byte ApplyRange { get; set; }

    /// <summary>
    /// Used in multiple skill attacks.
    /// </summary>
    public byte MultiAttack { get; set; }

    /// <summary>
    /// Time for example for buffs. This time shows how long the skill will be applied.
    /// </summary>
    public ushort KeepTime { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>
    public byte Weapon1 { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>
    public byte Weapon2 { get; set; }

    /// <summary>
    /// Only for passive skills; passive skill speed modificator or passive attack power up.
    /// </summary>
    public byte WeaponValue { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public byte Bag { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public ushort Arrow { get; set; }

    /// <summary>
    /// Damage type.
    /// </summary>
    public byte DamageType { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public ushort DamageHP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public ushort DamageSP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    public ushort DamageMP { get; set; }

    /// <summary>
    /// Time damage type.
    /// </summary>
    public byte TimeDamageType { get; set; }

    /// <summary>
    /// Either fixed hp or % hp damage made over time.
    /// </summary>
    public ushort TimeDamageHP { get; set; }

    /// <summary>
    /// Either fixed sp or % sp damage made over time.
    /// </summary>
    public ushort TimeDamageSP { get; set; }

    /// <summary>
    /// Either fixed mp or % mp damage made over time.
    /// </summary>
    public ushort TimeDamageMP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public ushort AddDamageHP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public ushort AddDamageSP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    public ushort AddDamageMP { get; set; }

    public byte AbilityType1 { get; set; }

    public ushort AbilityValue1 { get; set; }

    public byte AbilityType2 { get; set; }

    public ushort AbilityValue2 { get; set; }

    public byte AbilityType3 { get; set; }

    public ushort AbilityValue3 { get; set; }

    public byte AbilityType4 { get; set; }

    public ushort AbilityValue4 { get; set; }

    public byte AbilityType5 { get; set; }

    public ushort AbilityValue5 { get; set; }

    public byte AbilityType6 { get; set; }

    public ushort AbilityValue6 { get; set; }

    public byte AbilityType7 { get; set; }

    public ushort AbilityValue7 { get; set; }

    public byte AbilityType8 { get; set; }

    public ushort AbilityValue8 { get; set; }

    public byte AbilityType9 { get; set; }

    public ushort AbilityValue9 { get; set; }

    public byte AbilityType10 { get; set; }

    public ushort AbilityValue10 { get; set; }

    /// <summary>
    /// How many health points can be healed.
    /// </summary>
    public ushort HealHP { get; set; }

    /// <summary>
    /// How many stamina points can be healed.
    /// </summary>
    public ushort HealSP { get; set; }

    /// <summary>
    /// How many mana points can be healed.
    /// </summary>
    public ushort HealMP { get; set; }

    /// <summary>
    /// HP healed over time.
    /// </summary>
    public ushort TimeHealHP { get; set; }

    /// <summary>
    /// SP healed over time.
    /// </summary>
    public ushort TimeHealSP { get; set; }

    /// <summary>
    /// MP healed over time.
    /// </summary>
    public ushort TimeHealMP { get; set; }

    /// <summary>
    /// For "Fleet Foot" it's value 2, which is block shoot attack for X %.
    /// For "Magic Veil" it's value 3, which is block X magic attacks.
    /// </summary>
    public byte DefenseType { get; set; }

    /// <summary>
    /// When <see cref="DefenseType"/> is 2, it's % of blocked shoot attacks.
    /// When <see cref="DefenseType"/> is 3, it's block X magic attacks.
    /// </summary>
    public byte DefenseValue { get; set; }

    /// <summary>
    /// % of hp, when this skill is activated.
    /// </summary>
    public byte LimitHP { get; set; }

    /// <summary>
    /// How long the skill should be kept.
    /// </summary>
    public byte FixRange { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public ushort ChangeType { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public ushort ChangeLevel { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
        {
            episode = (Episode)options[0];
        }

        var buffer = new List<byte>();
        buffer.AddRange(Name.GetLengthPrefixedBytes());
        buffer.AddRange(Description.GetLengthPrefixedBytes());
        buffer.Add(SkillLevel);
        buffer.AddRange(Icon.GetBytes());
        buffer.AddRange(Animation.GetBytes());

        if (episode >= Episode.EP6)
        {
            buffer.Add(Effect);
        }

        buffer.Add(ToggleType);
        buffer.AddRange(Sound.GetBytes());
        buffer.AddRange(RequiredLevel.GetBytes());
        buffer.Add(Country);
        buffer.Add(AttackFighter);
        buffer.Add(DefenseFighter);
        buffer.Add(PatrolRogue);
        buffer.Add(ShootRogue);
        buffer.Add(AttackMage);
        buffer.Add(DefenseMage);
        buffer.Add(Grow);
        buffer.Add(Point);
        buffer.Add(TypeShow);
        buffer.Add(TypeAttack);
        buffer.Add(TypeEffect);
        buffer.AddRange(TypeDetail.GetBytes());
        buffer.Add(NeedWeapon1);
        buffer.Add(NeedWeapon2);
        buffer.Add(NeedWeapon3);
        buffer.Add(NeedWeapon4);
        buffer.Add(NeedWeapon5);
        buffer.Add(NeedWeapon6);
        buffer.Add(NeedWeapon7);
        buffer.Add(NeedWeapon8);
        buffer.Add(NeedWeapon9);
        buffer.Add(NeedWeapon10);
        buffer.Add(NeedWeapon11);
        buffer.Add(NeedWeapon12);
        buffer.Add(NeedWeapon13);
        buffer.Add(NeedWeapon14);
        buffer.Add(NeedWeapon15);
        buffer.Add(Shield);
        buffer.AddRange(SP.GetBytes());
        buffer.AddRange(MP.GetBytes());
        buffer.Add(ReadyTime);
        buffer.AddRange(ResetTime.GetBytes());
        buffer.Add(AttackRange);
        buffer.Add(StateType);
        buffer.Add(AttribType);
        buffer.AddRange(Disable.GetBytes());
        buffer.AddRange(PrevSkill.GetBytes());
        buffer.Add(SuccessType);
        buffer.Add(SuccessValue);
        buffer.Add(TargetType);
        buffer.Add(ApplyRange);
        buffer.Add(MultiAttack);
        buffer.AddRange(KeepTime.GetBytes());
        buffer.Add(Weapon1);
        buffer.Add(Weapon2);
        buffer.Add(WeaponValue);
        buffer.Add(Bag);
        buffer.AddRange(Arrow.GetBytes());
        buffer.Add(DamageType);
        buffer.AddRange(DamageHP.GetBytes());
        buffer.AddRange(DamageSP.GetBytes());
        buffer.AddRange(DamageMP.GetBytes());
        buffer.Add(TimeDamageType);
        buffer.AddRange(TimeDamageHP.GetBytes());
        buffer.AddRange(TimeDamageSP.GetBytes());
        buffer.AddRange(TimeDamageMP.GetBytes());
        buffer.AddRange(AddDamageHP.GetBytes());
        buffer.AddRange(AddDamageSP.GetBytes());
        buffer.AddRange(AddDamageMP.GetBytes());
        buffer.Add(AbilityType1);
        buffer.AddRange(AbilityValue1.GetBytes());
        buffer.Add(AbilityType2);
        buffer.AddRange(AbilityValue2.GetBytes());
        buffer.Add(AbilityType3);
        buffer.AddRange(AbilityValue3.GetBytes());

        if (episode >= Episode.EP6)
        {
            buffer.Add(AbilityType4);
            buffer.AddRange(AbilityValue4.GetBytes());
            buffer.Add(AbilityType5);
            buffer.AddRange(AbilityValue5.GetBytes());
            buffer.Add(AbilityType6);
            buffer.AddRange(AbilityValue6.GetBytes());
            buffer.Add(AbilityType7);
            buffer.AddRange(AbilityValue7.GetBytes());
            buffer.Add(AbilityType8);
            buffer.AddRange(AbilityValue8.GetBytes());
            buffer.Add(AbilityType9);
            buffer.AddRange(AbilityValue9.GetBytes());
            buffer.Add(AbilityType10);
            buffer.AddRange(AbilityValue10.GetBytes());
        }

        buffer.AddRange(HealHP.GetBytes());
        buffer.AddRange(HealSP.GetBytes());
        buffer.AddRange(HealMP.GetBytes());
        buffer.AddRange(TimeHealHP.GetBytes());
        buffer.AddRange(TimeHealSP.GetBytes());
        buffer.AddRange(TimeHealMP.GetBytes());
        buffer.Add(DefenseType);
        buffer.Add(DefenseValue);
        buffer.Add(LimitHP);
        buffer.Add(FixRange);
        buffer.AddRange(ChangeType.GetBytes());
        buffer.AddRange(ChangeLevel.GetBytes());
        return buffer;
    }
}
