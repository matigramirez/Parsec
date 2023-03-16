using Parsec.Attributes;
using Parsec.Common;

namespace Parsec.Shaiya.Skill;

public sealed class SkillRecord
{
    [ShaiyaProperty]
    [LengthPrefixedString]
    public string Name { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string Description { get; set; }

    /// <summary>
    /// Level of skill.
    /// </summary>
    [ShaiyaProperty]
    public byte SkillLevel { get; set; }

    /// <summary>
    /// Id of skill.
    /// </summary>
    [ShaiyaProperty]
    public short Id { get; set; }

    /// <summary>
    /// Skill animation.
    /// </summary>
    [ShaiyaProperty]
    public byte Animation { get; set; }

    /// <summary>
    /// Skill icon.
    /// </summary>
    [ShaiyaProperty]
    public int Icon { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte Effect { get; set; }

    /// <summary>
    /// Character required level.
    /// </summary>
    [ShaiyaProperty]
    public short RequiredLevel { get; set; }

    /// <summary>
    /// Which faction and profession can use this skill.
    /// </summary>
    [ShaiyaProperty]
    public byte Country { get; set; }

    /// <summary>
    /// Indicates if skill can be used by fighter.
    /// </summary>
    [ShaiyaProperty]
    public byte AttackFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by defender.
    /// </summary>
    [ShaiyaProperty]
    public byte DefenseFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by ranger.
    /// </summary>
    [ShaiyaProperty]
    public byte PatrolRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by archer.
    /// </summary>
    [ShaiyaProperty]
    public byte ShootRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by mage.
    /// </summary>
    [ShaiyaProperty]
    public byte AttackMage { get; set; }

    /// <summary>
    /// Indicates if skill can be used by priest.
    /// </summary>
    [ShaiyaProperty]
    public byte DefenseMage { get; set; }

    /// <summary>
    /// Skill can be used in basic/ultimate mode.
    /// </summary>
    [ShaiyaProperty]
    public byte Grow { get; set; }

    /// <summary>
    /// How many skill points are needed in order to learn this skill.
    /// </summary>
    [ShaiyaProperty]
    public byte Point { get; set; }

    /// <summary>
    /// Category of skill. E.g. combat or special.
    /// </summary>
    [ShaiyaProperty]
    public byte TypeShow { get; set; }

    /// <summary>
    /// Passive, physical, magic or shooting attack.
    /// </summary>
    [ShaiyaProperty]
    public byte TypeAttack { get; set; }

    /// <summary>
    /// Additional effect description.
    /// </summary>
    [ShaiyaProperty]
    public byte TypeEffect { get; set; }

    /// <summary>
    /// Type detail describes what skill does.
    /// </summary>
    [ShaiyaProperty]
    public short TypeDetail { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Sword.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon1 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Sword.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon2 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Axe.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon3 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Axe.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon4 { get; set; }

    /// <summary>
    /// Skill requires Double Sword.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon5 { get; set; }

    /// <summary>
    /// Skill requires Spear.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon6 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Blunt.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon7 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Blunt.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon8 { get; set; }

    /// <summary>
    /// Skill requires Reverse sword.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon9 { get; set; }

    /// <summary>
    /// Skill requires Dagger.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon10 { get; set; }

    /// <summary>
    /// Skill requires Javelin.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon11 { get; set; }

    /// <summary>
    /// Skill requires Staff.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon12 { get; set; }

    /// <summary>
    /// Skill requires Bow.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon13 { get; set; }

    /// <summary>
    /// Skill requires Crossbow.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon14 { get; set; }

    /// <summary>
    /// Skill requires Knuckle.
    /// </summary>
    [ShaiyaProperty]
    public byte NeedWeapon15 { get; set; }

    /// <summary>
    /// Skill requires shield.
    /// </summary>
    [ShaiyaProperty]
    public byte Shield { get; set; }

    /// <summary>
    /// How many stamina points requires the skill.
    /// </summary>
    [ShaiyaProperty]
    public short SP { get; set; }

    /// <summary>
    /// How many mana points requires the skill.
    /// </summary>
    [ShaiyaProperty]
    public short MP { get; set; }

    /// <summary>
    /// Cast time.
    /// </summary>
    [ShaiyaProperty]
    public byte ReadyTime { get; set; }

    /// <summary>
    /// Time after which skill can be used again.
    /// </summary>
    [ShaiyaProperty]
    public short ResetTime { get; set; }

    /// <summary>
    /// How many meters are needed in order to use the skill.
    /// </summary>
    [ShaiyaProperty]
    public byte AttackRange { get; set; }

    /// <summary>
    /// State type contains information about what bad influence debuff has on target.
    /// </summary>
    [ShaiyaProperty]
    public byte StateType { get; set; }

    /// <summary>
    /// None or fire/wind/earth/water.
    /// </summary>
    [ShaiyaProperty]
    public byte AttribType { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    [ShaiyaProperty]
    public short Disable { get; set; }

    /// <summary>
    /// Skill, that must be used before the skill.
    /// </summary>
    [ShaiyaProperty]
    public short PrevSkill { get; set; }

    /// <summary>
    /// SuccessType is always 0 for passive skills and 1 for other.
    /// </summary>
    [ShaiyaProperty]
    public byte SuccessType { get; set; }

    /// <summary>
    /// Success chance in %.
    /// </summary>
    [ShaiyaProperty]
    public byte SuccessValue { get; set; }

    /// <summary>
    /// What target is required for the skill.
    /// </summary>
    [ShaiyaProperty]
    public byte TargetType { get; set; }

    /// <summary>
    /// Skill will be applied within X meters.
    /// </summary>
    [ShaiyaProperty]
    public byte ApplyRange { get; set; }

    /// <summary>
    /// Used in multiple skill attacks.
    /// </summary>
    [ShaiyaProperty]
    public byte MultiAttack { get; set; }

    /// <summary>
    /// Time for example for buffs. This time shows how long the skill will be applied.
    /// </summary>
    [ShaiyaProperty]
    public short KeepTime { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>
    [ShaiyaProperty]
    public byte Weapon1 { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>
    [ShaiyaProperty]
    public byte Weapon2 { get; set; }

    /// <summary>
    /// Only for passive skills; passive skill speed modificator or passive attack power up.
    /// </summary>
    [ShaiyaProperty]
    public byte WeaponValue { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    [ShaiyaProperty]
    public byte Bag { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    [ShaiyaProperty]
    public short Arrow { get; set; }

    /// <summary>
    /// Damage type.
    /// </summary>
    [ShaiyaProperty]
    public byte DamageType { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    [ShaiyaProperty]
    public short DamageHP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    [ShaiyaProperty]
    public short DamageSP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>
    [ShaiyaProperty]
    public short DamageMP { get; set; }

    /// <summary>
    /// Time damage type.
    /// </summary>
    [ShaiyaProperty]
    public byte TimeDamageType { get; set; }

    /// <summary>
    /// Either fixed hp or % hp damage made over time.
    /// </summary>
    [ShaiyaProperty]
    public short TimeDamageHP { get; set; }

    /// <summary>
    /// Either fixed sp or % sp damage made over time.
    /// </summary>
    [ShaiyaProperty]
    public short TimeDamageSP { get; set; }

    /// <summary>
    /// Either fixed mp or % mp damage made over time.
    /// </summary>
    [ShaiyaProperty]
    public short TimeDamageMP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    [ShaiyaProperty]
    public short AddDamageHP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    [ShaiyaProperty]
    public short AddDamageSP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>
    [ShaiyaProperty]
    public short AddDamageMP { get; set; }

    [ShaiyaProperty]
    public byte AbilityType1 { get; set; }

    [ShaiyaProperty]
    public short AbilityValue1 { get; set; }

    [ShaiyaProperty]
    public byte AbilityType2 { get; set; }

    [ShaiyaProperty]
    public short AbilityValue2 { get; set; }

    [ShaiyaProperty]
    public byte AbilityType3 { get; set; }

    [ShaiyaProperty]
    public short AbilityValue3 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType4 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue4 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType5 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue5 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType6 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue6 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType7 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue7 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType8 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue8 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType9 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue9 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public byte AbilityType10 { get; set; }

    [ShaiyaProperty(MinEpisode = Episode.EP6)]
    public short AbilityValue10 { get; set; }

    /// <summary>
    /// How many health points can be healed.
    /// </summary>
    [ShaiyaProperty]
    public short HealHP { get; set; }

    /// <summary>
    /// How many stamina points can be healed.
    /// </summary>
    [ShaiyaProperty]
    public short HealSP { get; set; }

    /// <summary>
    /// How many mana points can be healed.
    /// </summary>
    [ShaiyaProperty]
    public short HealMP { get; set; }

    /// <summary>
    /// HP healed over time.
    /// </summary>
    [ShaiyaProperty]
    public short TimeHealHP { get; set; }

    /// <summary>
    /// SP healed over time.
    /// </summary>
    [ShaiyaProperty]
    public short TimeHealSP { get; set; }

    /// <summary>
    /// MP healed over time.
    /// </summary>
    [ShaiyaProperty]
    public short TimeHealMP { get; set; }

    /// <summary>
    /// For "Fleet Foot" it's value 2, which is block shoot attack for X %.
    /// For "Magic Veil" it's value 3, which is block X magic attacks.
    /// </summary>
    [ShaiyaProperty]
    public byte DefenseType { get; set; }

    /// <summary>
    /// When <see cref="DefenseType"/> is 2, it's % of blocked shoot attacks.
    /// When <see cref="DefenseType"/> is 3, it's block X magic attacks.
    /// </summary>
    [ShaiyaProperty]
    public byte DefenseValue { get; set; }

    /// <summary>
    /// % of hp, when this skill is activated.
    /// </summary>
    [ShaiyaProperty]
    public byte LimitHP { get; set; }

    /// <summary>
    /// How long the skill should be kept.
    /// </summary>
    [ShaiyaProperty]
    public byte FixRange { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    [ShaiyaProperty]
    public short ChangeType { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    [ShaiyaProperty]
    public short ChangeLevel { get; set; }
}
