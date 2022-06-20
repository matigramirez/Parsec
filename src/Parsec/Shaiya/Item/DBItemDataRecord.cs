using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Item;

public class DBItemDataRecord : IBinarySDataRecord
{
    public long ItemType { get; set; }
    public long ItemTypeId { get; set; }
    public long Image { get; set; }
    public long Icon { get; set; }
    public long Level { get; set; }
    public long Country { get; set; }
    public long AttackFighter { get; set; }
    public long DefenseFighter { get; set; }
    public long PatrolRogue { get; set; }
    public long ShootRogue { get; set; }
    public long AttackMage { get; set; }
    public long DefenseMage { get; set; }
    public long Grow { get; set; }
    public long Str { get; set; }
    public long Dex { get; set; }
    public long Rec { get; set; }
    public long Int { get; set; }
    public long Wis { get; set; }
    public long Luc { get; set; }
    public long Vg { get; set; }
    public long Og { get; set; }
    public long Ig { get; set; }
    public long Range { get; set; }
    public long AttackTime { get; set; }
    public long Attrib { get; set; }
    public long Special { get; set; }
    public long Slot { get; set; }
    public long Quality { get; set; }
    public long Effect1 { get; set; }
    public long Effect2 { get; set; }
    public long Effect3 { get; set; }
    public long Effect4 { get; set; }
    public long ConstHp { get; set; }
    public long ConstSp { get; set; }
    public long ConstMp { get; set; }
    public long ConstStr { get; set; }
    public long ConstDex { get; set; }
    public long ConstRec { get; set; }
    public long ConstInt { get; set; }
    public long ConstWis { get; set; }
    public long ConstLuc { get; set; }
    public long Speed { get; set; }
    public long Exp { get; set; }
    public long Buy { get; set; }
    public long Sell { get; set; }
    public long Grade { get; set; }
    public long Drop { get; set; }
    public long Server { get; set; }
    public long Count { get; set; }
    public long Duration { get; set; }
    public long ExtDuration { get; set; }
    public long SecOption { get; set; }
    public long OptionRate { get; set; }
    public long BuyMethod { get; set; }
    public long MaxLevel { get; set; }
    public long WeaponPart { get; set; }
    public long DyeingType { get; set; }
    public long Arg3 { get; set; }
    public long Arg4 { get; set; }
    public long UseConType { get; set; }
    public long UseConVar { get; set; }
    public long MoneyType { get; set; }
    public long ItemSkill { get; set; }
    public long ItemUpgrade { get; set; }
    public long Arg10 { get; set; }
    public long GeneCount { get; set; }
    public long Arg12 { get; set; }
    public long SpellBookExp { get; set; }
    public long SpellBookDurability { get; set; }
    public long CastTime { get; set; }

    public void Read(SBinaryReader binaryReader, params object[] options)
    {
        ItemType = binaryReader.Read<long>();
        ItemTypeId = binaryReader.Read<long>();
        Image = binaryReader.Read<long>();
        Icon = binaryReader.Read<long>();
        Level = binaryReader.Read<long>();
        Country = binaryReader.Read<long>();
        AttackFighter = binaryReader.Read<long>();
        DefenseFighter = binaryReader.Read<long>();
        PatrolRogue = binaryReader.Read<long>();
        ShootRogue = binaryReader.Read<long>();
        AttackMage = binaryReader.Read<long>();
        DefenseMage = binaryReader.Read<long>();
        Grow = binaryReader.Read<long>();
        Str = binaryReader.Read<long>();
        Dex = binaryReader.Read<long>();
        Rec = binaryReader.Read<long>();
        Int = binaryReader.Read<long>();
        Wis = binaryReader.Read<long>();
        Luc = binaryReader.Read<long>();
        Vg = binaryReader.Read<long>();
        Og = binaryReader.Read<long>();
        Ig = binaryReader.Read<long>();
        Range = binaryReader.Read<long>();
        AttackTime = binaryReader.Read<long>();
        Attrib = binaryReader.Read<long>();
        Special = binaryReader.Read<long>();
        Slot = binaryReader.Read<long>();
        Quality = binaryReader.Read<long>();
        Effect1 = binaryReader.Read<long>();
        Effect2 = binaryReader.Read<long>();
        Effect3 = binaryReader.Read<long>();
        Effect4 = binaryReader.Read<long>();
        ConstHp = binaryReader.Read<long>();
        ConstSp = binaryReader.Read<long>();
        ConstMp = binaryReader.Read<long>();
        ConstStr = binaryReader.Read<long>();
        ConstDex = binaryReader.Read<long>();
        ConstRec = binaryReader.Read<long>();
        ConstInt = binaryReader.Read<long>();
        ConstWis = binaryReader.Read<long>();
        ConstLuc = binaryReader.Read<long>();
        Speed = binaryReader.Read<long>();
        Exp = binaryReader.Read<long>();
        Buy = binaryReader.Read<long>();
        Sell = binaryReader.Read<long>();
        Grade = binaryReader.Read<long>();
        Drop = binaryReader.Read<long>();
        Server = binaryReader.Read<long>();
        Count = binaryReader.Read<long>();
        Duration = binaryReader.Read<long>();
        ExtDuration = binaryReader.Read<long>();
        SecOption = binaryReader.Read<long>();
        OptionRate = binaryReader.Read<long>();
        BuyMethod = binaryReader.Read<long>();
        MaxLevel = binaryReader.Read<long>();
        WeaponPart = binaryReader.Read<long>();
        DyeingType = binaryReader.Read<long>();
        Arg3 = binaryReader.Read<long>();
        Arg4 = binaryReader.Read<long>();
        UseConType = binaryReader.Read<long>();
        UseConVar = binaryReader.Read<long>();
        MoneyType = binaryReader.Read<long>();
        ItemSkill = binaryReader.Read<long>();
        ItemUpgrade = binaryReader.Read<long>();
        Arg10 = binaryReader.Read<long>();
        GeneCount = binaryReader.Read<long>();
        Arg12 = binaryReader.Read<long>();
        SpellBookExp = binaryReader.Read<long>();
        SpellBookDurability = binaryReader.Read<long>();
        CastTime = binaryReader.Read<long>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(ItemType.GetBytes());
        buffer.AddRange(ItemTypeId.GetBytes());
        buffer.AddRange(Image.GetBytes());
        buffer.AddRange(Icon.GetBytes());
        buffer.AddRange(Level.GetBytes());
        buffer.AddRange(Country.GetBytes());
        buffer.AddRange(AttackFighter.GetBytes());
        buffer.AddRange(DefenseFighter.GetBytes());
        buffer.AddRange(PatrolRogue.GetBytes());
        buffer.AddRange(ShootRogue.GetBytes());
        buffer.AddRange(AttackMage.GetBytes());
        buffer.AddRange(DefenseMage.GetBytes());
        buffer.AddRange(Grow.GetBytes());
        buffer.AddRange(Str.GetBytes());
        buffer.AddRange(Dex.GetBytes());
        buffer.AddRange(Rec.GetBytes());
        buffer.AddRange(Int.GetBytes());
        buffer.AddRange(Wis.GetBytes());
        buffer.AddRange(Luc.GetBytes());
        buffer.AddRange(Vg.GetBytes());
        buffer.AddRange(Og.GetBytes());
        buffer.AddRange(Ig.GetBytes());
        buffer.AddRange(Range.GetBytes());
        buffer.AddRange(AttackTime.GetBytes());
        buffer.AddRange(Attrib.GetBytes());
        buffer.AddRange(Special.GetBytes());
        buffer.AddRange(Slot.GetBytes());
        buffer.AddRange(Quality.GetBytes());
        buffer.AddRange(Effect1.GetBytes());
        buffer.AddRange(Effect2.GetBytes());
        buffer.AddRange(Effect3.GetBytes());
        buffer.AddRange(Effect4.GetBytes());
        buffer.AddRange(ConstHp.GetBytes());
        buffer.AddRange(ConstSp.GetBytes());
        buffer.AddRange(ConstMp.GetBytes());
        buffer.AddRange(ConstStr.GetBytes());
        buffer.AddRange(ConstDex.GetBytes());
        buffer.AddRange(ConstRec.GetBytes());
        buffer.AddRange(ConstInt.GetBytes());
        buffer.AddRange(ConstWis.GetBytes());
        buffer.AddRange(ConstLuc.GetBytes());
        buffer.AddRange(Speed.GetBytes());
        buffer.AddRange(Exp.GetBytes());
        buffer.AddRange(Buy.GetBytes());
        buffer.AddRange(Sell.GetBytes());
        buffer.AddRange(Grade.GetBytes());
        buffer.AddRange(Drop.GetBytes());
        buffer.AddRange(Server.GetBytes());
        buffer.AddRange(Count.GetBytes());
        buffer.AddRange(Duration.GetBytes());
        buffer.AddRange(ExtDuration.GetBytes());
        buffer.AddRange(SecOption.GetBytes());
        buffer.AddRange(OptionRate.GetBytes());
        buffer.AddRange(BuyMethod.GetBytes());
        buffer.AddRange(MaxLevel.GetBytes());
        buffer.AddRange(WeaponPart.GetBytes());
        buffer.AddRange(DyeingType.GetBytes());
        buffer.AddRange(Arg3.GetBytes());
        buffer.AddRange(Arg4.GetBytes());
        buffer.AddRange(UseConType.GetBytes());
        buffer.AddRange(UseConVar.GetBytes());
        buffer.AddRange(MoneyType.GetBytes());
        buffer.AddRange(ItemSkill.GetBytes());
        buffer.AddRange(ItemUpgrade.GetBytes());
        buffer.AddRange(Arg10.GetBytes());
        buffer.AddRange(GeneCount.GetBytes());
        buffer.AddRange(Arg12.GetBytes());
        buffer.AddRange(SpellBookExp.GetBytes());
        buffer.AddRange(SpellBookDurability.GetBytes());
        buffer.AddRange(CastTime.GetBytes());
        return buffer;
    }
}
