using Parsec.Common;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Skill;

/// <summary>
/// Class that represents a record for the Skill.SData and NpcSkill.SData formats
/// </summary>
public sealed class SkillRecord : ISerializable
{
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

    public void Read(SBinaryReader binaryReader)
    {
        var episode = binaryReader.SerializationOptions.Episode;

        Name = binaryReader.ReadString();
        Description = binaryReader.ReadString();
        SkillLevel = binaryReader.ReadByte();
        Icon = binaryReader.ReadUInt16();
        Animation = binaryReader.ReadUInt16();

        if (episode >= Episode.EP6)
        {
            Effect = binaryReader.ReadByte();
        }

        ToggleType = binaryReader.ReadByte();
        Sound = binaryReader.ReadUInt16();
        RequiredLevel = binaryReader.ReadUInt16();
        Country = binaryReader.ReadByte();
        AttackFighter = binaryReader.ReadByte();
        DefenseFighter = binaryReader.ReadByte();
        PatrolRogue = binaryReader.ReadByte();
        ShootRogue = binaryReader.ReadByte();
        AttackMage = binaryReader.ReadByte();
        DefenseMage = binaryReader.ReadByte();
        Grow = binaryReader.ReadByte();
        Point = binaryReader.ReadByte();
        TypeShow = binaryReader.ReadByte();
        TypeAttack = binaryReader.ReadByte();
        TypeEffect = binaryReader.ReadByte();
        TypeDetail = binaryReader.ReadUInt16();
        NeedWeapon1 = binaryReader.ReadByte();
        NeedWeapon2 = binaryReader.ReadByte();
        NeedWeapon3 = binaryReader.ReadByte();
        NeedWeapon4 = binaryReader.ReadByte();
        NeedWeapon5 = binaryReader.ReadByte();
        NeedWeapon6 = binaryReader.ReadByte();
        NeedWeapon7 = binaryReader.ReadByte();
        NeedWeapon8 = binaryReader.ReadByte();
        NeedWeapon9 = binaryReader.ReadByte();
        NeedWeapon10 = binaryReader.ReadByte();
        NeedWeapon11 = binaryReader.ReadByte();
        NeedWeapon12 = binaryReader.ReadByte();
        NeedWeapon13 = binaryReader.ReadByte();
        NeedWeapon14 = binaryReader.ReadByte();
        NeedWeapon15 = binaryReader.ReadByte();
        Shield = binaryReader.ReadByte();
        SP = binaryReader.ReadUInt16();
        MP = binaryReader.ReadUInt16();
        ReadyTime = binaryReader.ReadByte();
        ResetTime = binaryReader.ReadUInt16();
        AttackRange = binaryReader.ReadByte();
        StateType = binaryReader.ReadByte();
        AttribType = binaryReader.ReadByte();
        Disable = binaryReader.ReadUInt16();
        PrevSkill = binaryReader.ReadUInt16();
        SuccessType = binaryReader.ReadByte();
        SuccessValue = binaryReader.ReadByte();
        TargetType = binaryReader.ReadByte();
        ApplyRange = binaryReader.ReadByte();
        MultiAttack = binaryReader.ReadByte();
        KeepTime = binaryReader.ReadUInt16();
        Weapon1 = binaryReader.ReadByte();
        Weapon2 = binaryReader.ReadByte();
        WeaponValue = binaryReader.ReadByte();
        Bag = binaryReader.ReadByte();
        Arrow = binaryReader.ReadUInt16();
        DamageType = binaryReader.ReadByte();
        DamageHP = binaryReader.ReadUInt16();
        DamageSP = binaryReader.ReadUInt16();
        DamageMP = binaryReader.ReadUInt16();
        TimeDamageType = binaryReader.ReadByte();
        TimeDamageHP = binaryReader.ReadUInt16();
        TimeDamageSP = binaryReader.ReadUInt16();
        TimeDamageMP = binaryReader.ReadUInt16();
        AddDamageHP = binaryReader.ReadUInt16();
        AddDamageSP = binaryReader.ReadUInt16();
        AddDamageMP = binaryReader.ReadUInt16();
        AbilityType1 = binaryReader.ReadByte();
        AbilityValue1 = binaryReader.ReadUInt16();
        AbilityType2 = binaryReader.ReadByte();
        AbilityValue2 = binaryReader.ReadUInt16();
        AbilityType3 = binaryReader.ReadByte();
        AbilityValue3 = binaryReader.ReadUInt16();

        if (episode >= Episode.EP6)
        {
            AbilityType4 = binaryReader.ReadByte();
            AbilityValue4 = binaryReader.ReadUInt16();
            AbilityType5 = binaryReader.ReadByte();
            AbilityValue5 = binaryReader.ReadUInt16();
            AbilityType6 = binaryReader.ReadByte();
            AbilityValue6 = binaryReader.ReadUInt16();
            AbilityType7 = binaryReader.ReadByte();
            AbilityValue7 = binaryReader.ReadUInt16();
            AbilityType8 = binaryReader.ReadByte();
            AbilityValue8 = binaryReader.ReadUInt16();
            AbilityType9 = binaryReader.ReadByte();
            AbilityValue9 = binaryReader.ReadUInt16();
            AbilityType10 = binaryReader.ReadByte();
            AbilityValue10 = binaryReader.ReadUInt16();
        }

        HealHP = binaryReader.ReadUInt16();
        HealSP = binaryReader.ReadUInt16();
        HealMP = binaryReader.ReadUInt16();
        TimeHealHP = binaryReader.ReadUInt16();
        TimeHealSP = binaryReader.ReadUInt16();
        TimeHealMP = binaryReader.ReadUInt16();
        DefenseType = binaryReader.ReadByte();
        DefenseValue = binaryReader.ReadByte();
        LimitHP = binaryReader.ReadByte();
        FixRange = binaryReader.ReadByte();
        ChangeType = binaryReader.ReadUInt16();
        ChangeLevel = binaryReader.ReadUInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var episode = binaryWriter.SerializationOptions.Episode;

        binaryWriter.WriteLengthPrefixedString(Name);
        binaryWriter.WriteLengthPrefixedString(Description);
        binaryWriter.Write(SkillLevel);
        binaryWriter.Write(Icon);
        binaryWriter.Write(Animation);

        if (episode >= Episode.EP6)
        {
            binaryWriter.Write(Effect);
        }

        binaryWriter.Write(ToggleType);
        binaryWriter.Write(Sound);
        binaryWriter.Write(RequiredLevel);
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
        binaryWriter.Write(TypeDetail);
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
        binaryWriter.Write(DamageHP);
        binaryWriter.Write(DamageSP);
        binaryWriter.Write(DamageMP);
        binaryWriter.Write(TimeDamageType);
        binaryWriter.Write(TimeDamageHP);
        binaryWriter.Write(TimeDamageSP);
        binaryWriter.Write(TimeDamageMP);
        binaryWriter.Write(AddDamageHP);
        binaryWriter.Write(AddDamageSP);
        binaryWriter.Write(AddDamageMP);
        binaryWriter.Write(AbilityType1);
        binaryWriter.Write(AbilityValue1);
        binaryWriter.Write(AbilityType2);
        binaryWriter.Write(AbilityValue2);
        binaryWriter.Write(AbilityType3);
        binaryWriter.Write(AbilityValue3);

        if (episode >= Episode.EP6)
        {
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
        }

        binaryWriter.Write(HealHP);
        binaryWriter.Write(HealSP);
        binaryWriter.Write(HealMP);
        binaryWriter.Write(TimeHealHP);
        binaryWriter.Write(TimeHealSP);
        binaryWriter.Write(TimeHealMP);
        binaryWriter.Write(DefenseType);
        binaryWriter.Write(DefenseValue);
        binaryWriter.Write(LimitHP);
        binaryWriter.Write(FixRange);
        binaryWriter.Write(ChangeType);
        binaryWriter.Write(ChangeLevel);
    }
}
