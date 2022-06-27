using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Skill;

public class DBSkillDataRecord : IBinarySDataRecord
{
    /// <summary>
    /// Id of skill.
    /// </summary>

    [ShaiyaProperty]
    public long SkillId { get; set; }

    /// <summary>
    /// Level of skill.
    /// </summary>

    [ShaiyaProperty]
    public long SkillLevel { get; set; }

    /// <summary>
    /// Skill icon.
    /// </summary>

    [ShaiyaProperty]
    public long Image { get; set; }

    /// <summary>
    /// Skill animation.
    /// </summary>

    [ShaiyaProperty]
    public long Ani { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long Effect { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long ToggleType { get; set; }

    /// <summary>
    /// Skill sound effect.
    /// </summary>

    [ShaiyaProperty]
    public long Sound { get; set; }

    /// <summary>
    /// Character required level.
    /// </summary>

    [ShaiyaProperty]
    public long Level { get; set; }

    /// <summary>
    /// Which faction and profession can use this skill.
    /// </summary>

    [ShaiyaProperty]
    public UserFamily UserFamily { get; set; }

    /// <summary>
    /// Indicates if skill can be used by fighter.
    /// </summary>

    [ShaiyaProperty]
    public long AttackFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by defender.
    /// </summary>

    [ShaiyaProperty]
    public long DefenseFighter { get; set; }

    /// <summary>
    /// Indicates if skill can be used by ranger.
    /// </summary>

    [ShaiyaProperty]
    public long PatrolRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by archer.
    /// </summary>

    [ShaiyaProperty]
    public long ShootRogue { get; set; }

    /// <summary>
    /// Indicates if skill can be used by mage.
    /// </summary>

    [ShaiyaProperty]
    public long AttackMage { get; set; }

    /// <summary>
    /// Indicates if skill can be used by priest.
    /// </summary>

    [ShaiyaProperty]
    public long DefenseMage { get; set; }

    /// <summary>
    /// Skill can be used in basic/ultimate mode.
    /// </summary>

    [ShaiyaProperty]
    public long Grow { get; set; }

    /// <summary>
    /// How many skill points are needed in order to learn this skill.
    /// </summary>

    [ShaiyaProperty]
    public long Point { get; set; }

    /// <summary>
    /// Category of skill. E.g. combat or special.
    /// </summary>

    [ShaiyaProperty]
    public TypeShow TypeShow { get; set; }

    /// <summary>
    /// Passive, physical, magic or shooting attack.
    /// </summary>

    [ShaiyaProperty]
    public TypeAttack TypeAttack { get; set; }

    /// <summary>
    /// Additional effect description.
    /// </summary>

    [ShaiyaProperty]
    public TypeEffect TypeEffect { get; set; }

    /// <summary>
    /// Type detail describes what skill does.
    /// </summary>

    [ShaiyaProperty]
    public TypeDetail TypeDetail { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Sword.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon1 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Sword.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon2 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Axe.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon3 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Axe.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon4 { get; set; }

    /// <summary>
    /// Skill requires Double Sword.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon5 { get; set; }

    /// <summary>
    /// Skill requires Spear.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon6 { get; set; }

    /// <summary>
    /// Skill requires 1 Handed Blunt.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon7 { get; set; }

    /// <summary>
    /// Skill requires 2 Handed Blunt.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon8 { get; set; }

    /// <summary>
    /// Skill requires Reverse sword.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon9 { get; set; }

    /// <summary>
    /// Skill requires Dagger.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon10 { get; set; }

    /// <summary>
    /// Skill requires Javelin.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon11 { get; set; }

    /// <summary>
    /// Skill requires Staff.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon12 { get; set; }

    /// <summary>
    /// Skill requires Bow.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon13 { get; set; }

    /// <summary>
    /// Skill requires Crossbow.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon14 { get; set; }

    /// <summary>
    /// Skill requires Knuckle.
    /// </summary>

    [ShaiyaProperty]
    public long NeedWeapon15 { get; set; }

    /// <summary>
    /// Skill requires shield.
    /// </summary>

    [ShaiyaProperty]
    public long NeedShield { get; set; }

    /// <summary>
    /// How many stamina points requires the skill.
    /// </summary>

    [ShaiyaProperty]
    public long SP { get; set; }

    /// <summary>
    /// How many mana points requires the skill.
    /// </summary>

    [ShaiyaProperty]
    public long MP { get; set; }

    /// <summary>
    /// Cast time.
    /// </summary>

    [ShaiyaProperty]
    public long ReadyTime { get; set; }

    /// <summary>
    /// Time after which skill can be used again.
    /// </summary>

    [ShaiyaProperty]
    public long ResetTime { get; set; }

    /// <summary>
    /// How many meters are needed in order to use the skill.
    /// </summary>

    [ShaiyaProperty]
    public long AttackRange { get; set; }

    /// <summary>
    /// State type contains information about what bad influence debuff has on target.
    /// </summary>

    [ShaiyaProperty]
    public StateType StateType { get; set; }

    /// <summary>
    /// None or fire/wind/earth/water.
    /// </summary>

    [ShaiyaProperty]
    public Element Element { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long Disable { get; set; }

    /// <summary>
    /// Skill, that must be used before the skill.
    /// </summary>

    [ShaiyaProperty]
    public long PrevSkill { get; set; }

    /// <summary>
    /// SuccessType is always 0 for passive skills and 1 for other.
    /// </summary>

    [ShaiyaProperty]
    public SuccessType SuccessType { get; set; }

    /// <summary>
    /// Success chance in %.
    /// </summary>

    [ShaiyaProperty]
    public long SuccessValue { get; set; }

    /// <summary>
    /// What target is required for the skill.
    /// </summary>

    [ShaiyaProperty]
    public TargetType TargetType { get; set; }

    /// <summary>
    /// Skill will be applied within X meters.
    /// </summary>

    [ShaiyaProperty]
    public long ApplyRange { get; set; }

    /// <summary>
    /// Used in multiple skill attacks.
    /// </summary>

    [ShaiyaProperty]
    public long MultiAttack { get; set; }

    /// <summary>
    /// Time for example for buffs. This time shows how long the skill will be applied.
    /// </summary>

    [ShaiyaProperty]
    public long KeepTime { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>

    [ShaiyaProperty]
    public long Weapon1 { get; set; }

    /// <summary>
    /// Only for passive skills; Weapon type to which passive skill speed modificator can be applied.
    /// </summary>

    [ShaiyaProperty]
    public long Weapon2 { get; set; }

    /// <summary>
    /// Only for passive skills; passive skill speed modificator or passive attack power up.
    /// </summary>

    [ShaiyaProperty]
    public long WeaponValue { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long Bag { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long Arrow { get; set; }

    /// <summary>
    /// Damage type.
    /// </summary>

    [ShaiyaProperty]
    public DamageType DamageType { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>

    [ShaiyaProperty]
    public long DamageHP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>

    [ShaiyaProperty]
    public long DamageSP { get; set; }

    /// <summary>
    /// Const damage used, when skill makes fixed damage.
    /// </summary>

    [ShaiyaProperty]
    public long DamageMP { get; set; }

    /// <summary>
    /// Time damage type.
    /// </summary>

    [ShaiyaProperty]
    public TimeDamageType TimeDamageType { get; set; }

    /// <summary>
    /// Either fixed hp or % hp damage made over time.
    /// </summary>

    [ShaiyaProperty]
    public long TimeDamageHP { get; set; }

    /// <summary>
    /// Either fixed sp or % sp damage made over time.
    /// </summary>

    [ShaiyaProperty]
    public long TimeDamageSP { get; set; }

    /// <summary>
    /// Either fixed mp or % mp damage made over time.
    /// </summary>

    [ShaiyaProperty]
    public long TimeDamageMP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>

    [ShaiyaProperty]
    public long AddDamageHP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>

    [ShaiyaProperty]
    public long AddDamageSP { get; set; }

    /// <summary>
    /// Const skill damage, that is added to damage made of stats.
    /// </summary>

    [ShaiyaProperty]
    public long AddDamageMP { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType1 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue1 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType2 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue2 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType3 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue3 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType4 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue4 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType5 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue5 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType6 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue6 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType7 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue7 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType8 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue8 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType9 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue9 { get; set; }

    [ShaiyaProperty]
    public AbilityType AbilityType10 { get; set; }

    [ShaiyaProperty]
    public long AbilityValue10 { get; set; }

    /// <summary>
    /// How many health points can be healed.
    /// </summary>

    [ShaiyaProperty]
    public long HealHP { get; set; }

    /// <summary>
    /// How many stamina points can be healed.
    /// </summary>

    [ShaiyaProperty]
    public long HealSP { get; set; }

    /// <summary>
    /// How many mana points can be healed.
    /// </summary>

    [ShaiyaProperty]
    public long HealMP { get; set; }

    /// <summary>
    /// HP healed over time.
    /// </summary>

    [ShaiyaProperty]
    public long TimeHealHP { get; set; }

    /// <summary>
    /// SP healed over time.
    /// </summary>

    [ShaiyaProperty]
    public long TimeHealSP { get; set; }

    /// <summary>
    /// MP healed over time.
    /// </summary>

    [ShaiyaProperty]
    public long TimeHealMP { get; set; }

    /// <summary>
    /// For "Fleet Foot" it's value 2, which is block shoot attack for X %.
    /// For "Magic Veil" it's value 3, which is block X magic attacks.
    /// </summary>

    [ShaiyaProperty]
    public long DefenceType { get; set; }

    /// <summary>
    /// When <see cref="DefenceType"/> is 2, it's % of blocked shoot attacks.
    /// When <see cref="DefenceType"/> is 3, it's block X magic attacks.
    /// </summary>

    [ShaiyaProperty]
    public long DefenceValue { get; set; }

    /// <summary>
    /// % of hp, when this skill is activated.
    /// </summary>

    [ShaiyaProperty]
    public long LimitHP { get; set; }

    /// <summary>
    /// How long the skill should be kept.
    /// </summary>

    [ShaiyaProperty]
    public Duration FixRange { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long ChangeType { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long ChangeLevel { get; set; }

    /// <summary>
    /// ?
    /// </summary>

    [ShaiyaProperty]
    public long TacticZoneBound { get; set; }
}
