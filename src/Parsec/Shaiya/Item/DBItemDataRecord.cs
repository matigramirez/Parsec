using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Item;

public sealed class DBItemDataRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long ItemType { get; set; }

    [ShaiyaProperty]
    public long ItemTypeId { get; set; }

    [ShaiyaProperty]
    public long Image { get; set; }

    [ShaiyaProperty]
    public long Icon { get; set; }

    [ShaiyaProperty]
    public long Level { get; set; }

    [ShaiyaProperty]
    public long Country { get; set; }

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
    public long Str { get; set; }

    [ShaiyaProperty]
    public long Dex { get; set; }

    [ShaiyaProperty]
    public long Rec { get; set; }

    [ShaiyaProperty]
    public long Int { get; set; }

    [ShaiyaProperty]
    public long Wis { get; set; }

    [ShaiyaProperty]
    public long Luc { get; set; }

    [ShaiyaProperty]
    public long Vg { get; set; }

    [ShaiyaProperty]
    public long Og { get; set; }

    [ShaiyaProperty]
    public long Ig { get; set; }

    [ShaiyaProperty]
    public long Range { get; set; }

    [ShaiyaProperty]
    public long AttackTime { get; set; }

    [ShaiyaProperty]
    public long Attrib { get; set; }

    [ShaiyaProperty]
    public long Special { get; set; }

    [ShaiyaProperty]
    public long Slot { get; set; }

    [ShaiyaProperty]
    public long Quality { get; set; }

    [ShaiyaProperty]
    public long Effect1 { get; set; }

    [ShaiyaProperty]
    public long Effect2 { get; set; }

    [ShaiyaProperty]
    public long Effect3 { get; set; }

    [ShaiyaProperty]
    public long Effect4 { get; set; }

    [ShaiyaProperty]
    public long ConstHp { get; set; }

    [ShaiyaProperty]
    public long ConstSp { get; set; }

    [ShaiyaProperty]
    public long ConstMp { get; set; }

    [ShaiyaProperty]
    public long ConstStr { get; set; }

    [ShaiyaProperty]
    public long ConstDex { get; set; }

    [ShaiyaProperty]
    public long ConstRec { get; set; }

    [ShaiyaProperty]
    public long ConstInt { get; set; }

    [ShaiyaProperty]
    public long ConstWis { get; set; }

    [ShaiyaProperty]
    public long ConstLuc { get; set; }

    [ShaiyaProperty]
    public long Speed { get; set; }

    [ShaiyaProperty]
    public long Exp { get; set; }

    [ShaiyaProperty]
    public long Buy { get; set; }

    [ShaiyaProperty]
    public long Sell { get; set; }

    [ShaiyaProperty]
    public long Grade { get; set; }

    [ShaiyaProperty]
    public long Drop { get; set; }

    [ShaiyaProperty]
    public long Server { get; set; }

    [ShaiyaProperty]
    public long Count { get; set; }

    [ShaiyaProperty]
    public long Duration { get; set; }

    [ShaiyaProperty]
    public long ExtDuration { get; set; }

    [ShaiyaProperty]
    public long SecOption { get; set; }

    [ShaiyaProperty]
    public long OptionRate { get; set; }

    [ShaiyaProperty]
    public long BuyMethod { get; set; }

    [ShaiyaProperty]
    public long MaxLevel { get; set; }

    [ShaiyaProperty]
    public long WeaponPart { get; set; }

    [ShaiyaProperty]
    public long DyeingType { get; set; }

    [ShaiyaProperty]
    public long Arg3 { get; set; }

    [ShaiyaProperty]
    public long Arg4 { get; set; }

    [ShaiyaProperty]
    public long UseConType { get; set; }

    [ShaiyaProperty]
    public long UseConVar { get; set; }

    [ShaiyaProperty]
    public long MoneyType { get; set; }

    [ShaiyaProperty]
    public long ItemSkill { get; set; }

    [ShaiyaProperty]
    public long ItemUpgrade { get; set; }

    [ShaiyaProperty]
    public long Arg10 { get; set; }

    [ShaiyaProperty]
    public long GeneCount { get; set; }

    [ShaiyaProperty]
    public long Arg12 { get; set; }

    [ShaiyaProperty]
    public long SpellBookExp { get; set; }

    [ShaiyaProperty]
    public long SpellBookDurability { get; set; }

    [ShaiyaProperty]
    public long CastTime { get; set; }
}
