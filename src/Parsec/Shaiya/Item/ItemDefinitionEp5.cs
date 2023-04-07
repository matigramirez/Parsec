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
        MinLevel = binaryReader.Read<ushort>();
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
        ReqStr = binaryReader.Read<ushort>();
        ReqDex = binaryReader.Read<ushort>();
        ReqRec = binaryReader.Read<ushort>();
        ReqInt = binaryReader.Read<ushort>();
        ReqWis = binaryReader.Read<ushort>();
        ReqLuc = binaryReader.Read<ushort>();
        ReqVg = binaryReader.Read<ushort>();
        ReqOg = binaryReader.Read<byte>();
        ReqIg = binaryReader.Read<byte>();
        Range = binaryReader.Read<byte>();
        AttackTime = binaryReader.Read<byte>();
        Attrib = binaryReader.Read<byte>();
        Special = binaryReader.Read<byte>();
        Slot = binaryReader.Read<byte>();
        Quality = binaryReader.Read<ushort>();
        Attack = binaryReader.Read<ushort>();
        AttackAdd = binaryReader.Read<ushort>();
        Def = binaryReader.Read<ushort>();
        Resist = binaryReader.Read<ushort>();
        Hp = binaryReader.Read<ushort>();
        Sp = binaryReader.Read<ushort>();
        Mp = binaryReader.Read<ushort>();
        Str = binaryReader.Read<ushort>();
        Dex = binaryReader.Read<ushort>();
        Rec = binaryReader.Read<ushort>();
        Int = binaryReader.Read<ushort>();
        Wis = binaryReader.Read<ushort>();
        Luc = binaryReader.Read<ushort>();
        Speed = binaryReader.Read<byte>();
        Exp = binaryReader.Read<byte>();
        BuyPrice = binaryReader.Read<uint>();
        SellPrice = binaryReader.Read<uint>();
        Grade = binaryReader.Read<ushort>();
        Drop = binaryReader.Read<ushort>();
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
    public ushort MinLevel { get; set; }
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
    public ushort ReqStr { get; set; }
    public ushort ReqDex { get; set; }
    public ushort ReqRec { get; set; }
    public ushort ReqInt { get; set; }
    public ushort ReqWis { get; set; }
    public ushort ReqLuc { get; set; }
    public ushort ReqVg { get; set; }
    public byte ReqOg { get; set; }
    public byte ReqIg { get; set; }
    public byte Range { get; set; }
    public byte AttackTime { get; set; }
    public byte Attrib { get; set; }
    public byte Special { get; set; }
    public byte Slot { get; set; }
    public ushort Quality { get; set; }
    public ushort Attack { get; set; }
    public ushort AttackAdd { get; set; }
    public ushort Def { get; set; }
    public ushort Resist { get; set; }
    public ushort Hp { get; set; }
    public ushort Sp { get; set; }
    public ushort Mp { get; set; }
    public ushort Str { get; set; }
    public ushort Dex { get; set; }
    public ushort Rec { get; set; }
    public ushort Int { get; set; }
    public ushort Wis { get; set; }
    public ushort Luc { get; set; }
    public byte Speed { get; set; }
    public byte Exp { get; set; }
    public uint BuyPrice { get; set; }
    public uint SellPrice { get; set; }
    public ushort Grade { get; set; }
    public ushort Drop { get; set; }
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
        buffer.AddRange(Hp.GetBytes());
        buffer.AddRange(Sp.GetBytes());
        buffer.AddRange(Mp.GetBytes());
        buffer.AddRange(Str.GetBytes());
        buffer.AddRange(Dex.GetBytes());
        buffer.AddRange(Rec.GetBytes());
        buffer.AddRange(Int.GetBytes());
        buffer.AddRange(Wis.GetBytes());
        buffer.AddRange(Luc.GetBytes());
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
