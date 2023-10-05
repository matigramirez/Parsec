using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Item;

public sealed class DBItemDataRecord : IBinarySDataRecord
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

    public void Read(SBinaryReader binaryReader)
    {
        ItemType = binaryReader.ReadInt64();
        ItemTypeId = binaryReader.ReadInt64();
        Image = binaryReader.ReadInt64();
        Icon = binaryReader.ReadInt64();
        Level = binaryReader.ReadInt64();
        Country = binaryReader.ReadInt64();
        AttackFighter = binaryReader.ReadInt64();
        DefenseFighter = binaryReader.ReadInt64();
        PatrolRogue = binaryReader.ReadInt64();
        ShootRogue = binaryReader.ReadInt64();
        AttackMage = binaryReader.ReadInt64();
        DefenseMage = binaryReader.ReadInt64();
        Grow = binaryReader.ReadInt64();
        Str = binaryReader.ReadInt64();
        Dex = binaryReader.ReadInt64();
        Rec = binaryReader.ReadInt64();
        Int = binaryReader.ReadInt64();
        Wis = binaryReader.ReadInt64();
        Luc = binaryReader.ReadInt64();
        Vg = binaryReader.ReadInt64();
        Og = binaryReader.ReadInt64();
        Ig = binaryReader.ReadInt64();
        Range = binaryReader.ReadInt64();
        AttackTime = binaryReader.ReadInt64();
        Attrib = binaryReader.ReadInt64();
        Special = binaryReader.ReadInt64();
        Slot = binaryReader.ReadInt64();
        Quality = binaryReader.ReadInt64();
        Effect1 = binaryReader.ReadInt64();
        Effect2 = binaryReader.ReadInt64();
        Effect3 = binaryReader.ReadInt64();
        Effect4 = binaryReader.ReadInt64();
        ConstHp = binaryReader.ReadInt64();
        ConstSp = binaryReader.ReadInt64();
        ConstMp = binaryReader.ReadInt64();
        ConstStr = binaryReader.ReadInt64();
        ConstDex = binaryReader.ReadInt64();
        ConstRec = binaryReader.ReadInt64();
        ConstInt = binaryReader.ReadInt64();
        ConstWis = binaryReader.ReadInt64();
        ConstLuc = binaryReader.ReadInt64();
        Speed = binaryReader.ReadInt64();
        Exp = binaryReader.ReadInt64();
        Buy = binaryReader.ReadInt64();
        Sell = binaryReader.ReadInt64();
        Grade = binaryReader.ReadInt64();
        Drop = binaryReader.ReadInt64();
        Server = binaryReader.ReadInt64();
        Count = binaryReader.ReadInt64();
        Duration = binaryReader.ReadInt64();
        ExtDuration = binaryReader.ReadInt64();
        SecOption = binaryReader.ReadInt64();
        OptionRate = binaryReader.ReadInt64();
        BuyMethod = binaryReader.ReadInt64();
        MaxLevel = binaryReader.ReadInt64();
        WeaponPart = binaryReader.ReadInt64();
        DyeingType = binaryReader.ReadInt64();
        Arg3 = binaryReader.ReadInt64();
        Arg4 = binaryReader.ReadInt64();
        UseConType = binaryReader.ReadInt64();
        UseConVar = binaryReader.ReadInt64();
        MoneyType = binaryReader.ReadInt64();
        ItemSkill = binaryReader.ReadInt64();
        ItemUpgrade = binaryReader.ReadInt64();
        Arg10 = binaryReader.ReadInt64();
        GeneCount = binaryReader.ReadInt64();
        Arg12 = binaryReader.ReadInt64();
        SpellBookExp = binaryReader.ReadInt64();
        SpellBookDurability = binaryReader.ReadInt64();
        CastTime = binaryReader.ReadInt64();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ItemType);
        binaryWriter.Write(ItemTypeId);
        binaryWriter.Write(Image);
        binaryWriter.Write(Icon);
        binaryWriter.Write(Level);
        binaryWriter.Write(Country);
        binaryWriter.Write(AttackFighter);
        binaryWriter.Write(DefenseFighter);
        binaryWriter.Write(PatrolRogue);
        binaryWriter.Write(ShootRogue);
        binaryWriter.Write(AttackMage);
        binaryWriter.Write(DefenseMage);
        binaryWriter.Write(Grow);
        binaryWriter.Write(Str);
        binaryWriter.Write(Dex);
        binaryWriter.Write(Rec);
        binaryWriter.Write(Int);
        binaryWriter.Write(Wis);
        binaryWriter.Write(Luc);
        binaryWriter.Write(Vg);
        binaryWriter.Write(Og);
        binaryWriter.Write(Ig);
        binaryWriter.Write(Range);
        binaryWriter.Write(AttackTime);
        binaryWriter.Write(Attrib);
        binaryWriter.Write(Special);
        binaryWriter.Write(Slot);
        binaryWriter.Write(Quality);
        binaryWriter.Write(Effect1);
        binaryWriter.Write(Effect2);
        binaryWriter.Write(Effect3);
        binaryWriter.Write(Effect4);
        binaryWriter.Write(ConstHp);
        binaryWriter.Write(ConstSp);
        binaryWriter.Write(ConstMp);
        binaryWriter.Write(ConstStr);
        binaryWriter.Write(ConstDex);
        binaryWriter.Write(ConstRec);
        binaryWriter.Write(ConstInt);
        binaryWriter.Write(ConstWis);
        binaryWriter.Write(ConstLuc);
        binaryWriter.Write(Speed);
        binaryWriter.Write(Exp);
        binaryWriter.Write(Buy);
        binaryWriter.Write(Sell);
        binaryWriter.Write(Grade);
        binaryWriter.Write(Drop);
        binaryWriter.Write(Server);
        binaryWriter.Write(Count);
        binaryWriter.Write(Duration);
        binaryWriter.Write(ExtDuration);
        binaryWriter.Write(SecOption);
        binaryWriter.Write(OptionRate);
        binaryWriter.Write(BuyMethod);
        binaryWriter.Write(MaxLevel);
        binaryWriter.Write(WeaponPart);
        binaryWriter.Write(DyeingType);
        binaryWriter.Write(Arg3);
        binaryWriter.Write(Arg4);
        binaryWriter.Write(UseConType);
        binaryWriter.Write(UseConVar);
        binaryWriter.Write(MoneyType);
        binaryWriter.Write(ItemSkill);
        binaryWriter.Write(ItemUpgrade);
        binaryWriter.Write(Arg10);
        binaryWriter.Write(GeneCount);
        binaryWriter.Write(Arg12);
        binaryWriter.Write(SpellBookExp);
        binaryWriter.Write(SpellBookDurability);
        binaryWriter.Write(CastTime);
    }
}
