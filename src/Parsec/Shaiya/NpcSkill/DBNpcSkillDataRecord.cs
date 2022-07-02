using Parsec.Attributes;
using Parsec.Shaiya.SData;
using Parsec.Shaiya.Skill;

namespace Parsec.Shaiya.NpcSkill;

public class DBNpcSkillDataRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long SkillId { get; set; }

    [ShaiyaProperty]
    public long SkillLevel { get; set; }

    [ShaiyaProperty]
    public long Image { get; set; }

    [ShaiyaProperty]
    public long Ani { get; set; }

    [ShaiyaProperty]
    public long Effect { get; set; }

    [ShaiyaProperty]
    public long ToggleType { get; set; }

    [ShaiyaProperty]
    public long Sound { get; set; }

    [ShaiyaProperty]
    public long Level { get; set; }

    [ShaiyaProperty]
    public UserFamily UserFamily { get; set; }

    [ShaiyaProperty]
    public long AttackFighter { get; set; }

    [ShaiyaProperty]
    public long DefenseFighter { get; set; }

    [ShaiyaProperty]
    public long PatrolRogue { get; set; }

    [ShaiyaProperty]
    public long ShootRogue { get; set; }

    [ShaiyaProperty]
    public long AttackMage { get; set; }

    [ShaiyaProperty]
    public long DefenseMage { get; set; }

    [ShaiyaProperty]
    public long Grow { get; set; }

    [ShaiyaProperty]
    public long Point { get; set; }

    [ShaiyaProperty]
    public TypeShow TypeShow { get; set; }

    [ShaiyaProperty]
    public TypeAttack TypeAttack { get; set; }

    [ShaiyaProperty]
    public TypeEffect TypeEffect { get; set; }

    [ShaiyaProperty]
    public TypeDetail TypeDetail { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon1 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon2 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon3 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon4 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon5 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon6 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon7 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon8 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon9 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon10 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon11 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon12 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon13 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon14 { get; set; }

    [ShaiyaProperty]
    public long NeedWeapon15 { get; set; }

    [ShaiyaProperty]
    public long NeedShield { get; set; }

    [ShaiyaProperty]
    public long SP { get; set; }

    [ShaiyaProperty]
    public long MP { get; set; }

    [ShaiyaProperty]
    public long ReadyTime { get; set; }

    [ShaiyaProperty]
    public long ResetTime { get; set; }

    [ShaiyaProperty]
    public long AttackRange { get; set; }

    [ShaiyaProperty]
    public StateType StateType { get; set; }

    [ShaiyaProperty]
    public Element Element { get; set; }

    [ShaiyaProperty]
    public long Disable { get; set; }

    [ShaiyaProperty]
    public long PrevSkill { get; set; }

    [ShaiyaProperty]
    public SuccessType SuccessType { get; set; }

    [ShaiyaProperty]
    public long SuccessValue { get; set; }

    [ShaiyaProperty]
    public TargetType TargetType { get; set; }

    [ShaiyaProperty]
    public long ApplyRange { get; set; }

    [ShaiyaProperty]
    public long MultiAttack { get; set; }

    [ShaiyaProperty]
    public long KeepTime { get; set; }

    [ShaiyaProperty]
    public long Weapon1 { get; set; }

    [ShaiyaProperty]
    public long Weapon2 { get; set; }

    [ShaiyaProperty]
    public long WeaponValue { get; set; }

    [ShaiyaProperty]
    public long Bag { get; set; }

    [ShaiyaProperty]
    public long Arrow { get; set; }

    [ShaiyaProperty]
    public DamageType DamageType { get; set; }

    [ShaiyaProperty]
    public long DamageHP { get; set; }

    [ShaiyaProperty]
    public long DamageSP { get; set; }

    [ShaiyaProperty]
    public long DamageMP { get; set; }

    [ShaiyaProperty]
    public TimeDamageType TimeDamageType { get; set; }

    [ShaiyaProperty]
    public long TimeDamageHP { get; set; }

    [ShaiyaProperty]
    public long TimeDamageSP { get; set; }

    [ShaiyaProperty]
    public long TimeDamageMP { get; set; }

    [ShaiyaProperty]
    public long AddDamageHP { get; set; }

    [ShaiyaProperty]
    public long AddDamageSP { get; set; }

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

    [ShaiyaProperty]
    public long HealHP { get; set; }

    [ShaiyaProperty]
    public long HealSP { get; set; }

    [ShaiyaProperty]
    public long HealMP { get; set; }

    [ShaiyaProperty]
    public long TimeHealHP { get; set; }

    [ShaiyaProperty]
    public long TimeHealSP { get; set; }

    [ShaiyaProperty]
    public long TimeHealMP { get; set; }

    [ShaiyaProperty]
    public long DefenceType { get; set; }

    [ShaiyaProperty]
    public long DefenceValue { get; set; }

    [ShaiyaProperty]
    public long LimitHP { get; set; }

    [ShaiyaProperty]
    public Duration FixRange { get; set; }

    [ShaiyaProperty]
    public long ChangeType { get; set; }

    [ShaiyaProperty]
    public long ChangeLevel { get; set; }
}
