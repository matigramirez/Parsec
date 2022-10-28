using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item;

public sealed class ItemDefinitionEp5 : IBinary, IItemDefinition
{
    [JsonConstructor]
    public ItemDefinitionEp5()
    {
    }

    public ItemDefinitionEp5(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
        Description = binaryReader.ReadString();
        Type = binaryReader.Read<byte>();
        TypeId = binaryReader.Read<byte>();
        Model = binaryReader.Read<byte>();
        Icon = binaryReader.Read<byte>();
        MinLevel = binaryReader.Read<short>();
        Country = binaryReader.Read<byte>();
        AttackFighter = binaryReader.Read<byte>();
        DefenseFighter = binaryReader.Read<byte>();
        PatrolRogue = binaryReader.Read<byte>();
        ShootRogue = binaryReader.Read<byte>();
        AttackMage = binaryReader.Read<byte>();
        DefenseMage = binaryReader.Read<byte>();
        Grow = binaryReader.Read<byte>();
        Type2 = binaryReader.Read<byte>();
        Type3 = binaryReader.Read<byte>();
        ReqStr = binaryReader.Read<short>();
        ReqDex = binaryReader.Read<short>();
        ReqRec = binaryReader.Read<short>();
        ReqInt = binaryReader.Read<short>();
        ReqWis = binaryReader.Read<short>();
        ReqLuc = binaryReader.Read<short>();
        ReqVg = binaryReader.Read<short>();
        ReqOg = binaryReader.Read<byte>();
        ReqIg = binaryReader.Read<byte>();
        Range = binaryReader.Read<byte>();
        AttackTime = binaryReader.Read<byte>();
        Attrib = binaryReader.Read<byte>();
        Special = binaryReader.Read<byte>();
        Slot = binaryReader.Read<byte>();
        Quality = binaryReader.Read<short>();
        Attack = binaryReader.Read<short>();
        AttackAdd = binaryReader.Read<short>();
        Def = binaryReader.Read<short>();
        Resist = binaryReader.Read<short>();
        Str = binaryReader.Read<short>();
        Dex = binaryReader.Read<short>();
        Rec = binaryReader.Read<short>();
        Int = binaryReader.Read<short>();
        Wis = binaryReader.Read<short>();
        Luc = binaryReader.Read<short>();
        Hp = binaryReader.Read<short>();
        Sp = binaryReader.Read<short>();
        Mp = binaryReader.Read<short>();
        Speed = binaryReader.Read<byte>();
        Exp = binaryReader.Read<byte>();
        BuyPrice = binaryReader.Read<int>();
        SellPrice = binaryReader.Read<int>();
        Grade = binaryReader.Read<short>();
        Drop = binaryReader.Read<short>();
        Server = binaryReader.Read<byte>();
        Count = binaryReader.Read<byte>();
    }

    /// <summary>
    /// Order: 2. Changed because of CSV.
    /// </summary>
    public byte Type { get; set; }

    /// <summary>
    /// Order: 3. Changed because of CSV.
    /// </summary>
    public byte TypeId { get; set; }

    /// <summary>
    /// Order: 0. Changed because of CSV.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Order: 1. Changed because of CSV.
    /// </summary>
    public string Description { get; set; }

    public byte Model { get; set; }
    public byte Icon { get; set; }
    public short MinLevel { get; set; }
    public byte Country { get; set; }
    public byte AttackFighter { get; set; }
    public byte DefenseFighter { get; set; }
    public byte PatrolRogue { get; set; }
    public byte ShootRogue { get; set; }
    public byte AttackMage { get; set; }
    public byte DefenseMage { get; set; }
    public byte Grow { get; set; }
    public byte Type2 { get; set; }
    public byte Type3 { get; set; }
    public short ReqStr { get; set; }
    public short ReqDex { get; set; }
    public short ReqRec { get; set; }
    public short ReqInt { get; set; }
    public short ReqWis { get; set; }
    public short ReqLuc { get; set; }
    public short ReqVg { get; set; }
    public byte ReqOg { get; set; }
    public byte ReqIg { get; set; }
    public byte Range { get; set; }
    public byte AttackTime { get; set; }
    public byte Attrib { get; set; }
    public byte Special { get; set; }
    public byte Slot { get; set; }
    public short Quality { get; set; }
    public short Attack { get; set; }
    public short AttackAdd { get; set; }
    public short Def { get; set; }
    public short Resist { get; set; }
    public short Str { get; set; }
    public short Dex { get; set; }
    public short Rec { get; set; }
    public short Int { get; set; }
    public short Wis { get; set; }
    public short Luc { get; set; }
    public short Hp { get; set; }
    public short Sp { get; set; }
    public short Mp { get; set; }
    public byte Speed { get; set; }
    public byte Exp { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public short Grade { get; set; }
    public short Drop { get; set; }
    public byte Server { get; set; }
    public byte Count { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Name.GetLengthPrefixedBytes());
        buffer.AddRange(Description.GetLengthPrefixedBytes());
        buffer.Add(Type);
        buffer.Add(TypeId);
        buffer.Add(Model);
        buffer.Add(Icon);
        buffer.AddRange(MinLevel.GetBytes());
        buffer.Add(Country);
        buffer.Add(AttackFighter);
        buffer.Add(DefenseFighter);
        buffer.Add(PatrolRogue);
        buffer.Add(ShootRogue);
        buffer.Add(AttackMage);
        buffer.Add(DefenseMage);
        buffer.Add(Grow);
        buffer.Add(Type2);
        buffer.Add(Type3);
        buffer.AddRange(ReqStr.GetBytes());
        buffer.AddRange(ReqDex.GetBytes());
        buffer.AddRange(ReqRec.GetBytes());
        buffer.AddRange(ReqInt.GetBytes());
        buffer.AddRange(ReqWis.GetBytes());
        buffer.AddRange(ReqLuc.GetBytes());
        buffer.AddRange(ReqVg.GetBytes());
        buffer.Add(ReqOg);
        buffer.Add(ReqIg);
        buffer.Add(Range);
        buffer.Add(AttackTime);
        buffer.Add(Attrib);
        buffer.Add(Special);
        buffer.Add(Slot);
        buffer.AddRange(Quality.GetBytes());
        buffer.AddRange(Attack.GetBytes());
        buffer.AddRange(AttackAdd.GetBytes());
        buffer.AddRange(Def.GetBytes());
        buffer.AddRange(Resist.GetBytes());
        buffer.AddRange(Str.GetBytes());
        buffer.AddRange(Dex.GetBytes());
        buffer.AddRange(Rec.GetBytes());
        buffer.AddRange(Int.GetBytes());
        buffer.AddRange(Wis.GetBytes());
        buffer.AddRange(Luc.GetBytes());
        buffer.AddRange(Hp.GetBytes());
        buffer.AddRange(Sp.GetBytes());
        buffer.AddRange(Mp.GetBytes());
        buffer.Add(Speed);
        buffer.Add(Exp);
        buffer.AddRange(BuyPrice.GetBytes());
        buffer.AddRange(SellPrice.GetBytes());
        buffer.AddRange(Grade.GetBytes());
        buffer.AddRange(Drop.GetBytes());
        buffer.Add(Server);
        buffer.Add(Count);
        return buffer;
    }
}
