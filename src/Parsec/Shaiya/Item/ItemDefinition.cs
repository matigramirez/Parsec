using CsvHelper.Configuration.Attributes;
using Parsec.Common;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item;

public sealed class ItemDefinition : ISerializable
{
    [Index(2)]
    public string Name { get; set; } = string.Empty;

    [Index(3)]
    public string Description { get; set; } = string.Empty;

    [Index(0)]
    public byte ItemType { get; set; }

    [Index(1)]
    public byte ItemTypeId { get; set; }

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

    public ushort Unknown { get; set; }

    public byte ReqOg { get; set; }

    public byte ReqIg { get; set; }

    public ushort Range { get; set; }

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

    public uint Duration { get; set; }

    public byte ExtDuration { get; set; }

    public byte SecOption { get; set; }

    public byte OptionRate { get; set; }

    public byte BuyMethod { get; set; }

    public byte MaxLevel { get; set; }

    public byte Arg1 { get; set; }

    public byte Arg2 { get; set; }

    public byte Arg3 { get; set; }

    public byte Arg4 { get; set; }

    public byte Arg5 { get; set; }

    public uint Arg6 { get; set; }

    public uint Arg7 { get; set; }

    public uint Arg8 { get; set; }

    public uint Arg9 { get; set; }

    public uint Arg10 { get; set; }

    public uint Arg11 { get; set; }

    public uint Arg12 { get; set; }

    public uint Arg13 { get; set; }

    public uint Arg14 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        var episode = binaryReader.SerializationOptions.Episode;

        Name = binaryReader.ReadString();
        Description = binaryReader.ReadString();
        ItemType = binaryReader.ReadByte();
        ItemTypeId = binaryReader.ReadByte();
        Model = binaryReader.ReadByte();
        Icon = binaryReader.ReadByte();
        MinLevel = binaryReader.ReadUInt16();
        Country = binaryReader.ReadByte();
        AttackFighter = binaryReader.ReadByte();
        DefenseFighter = binaryReader.ReadByte();
        PatrolRogue = binaryReader.ReadByte();
        ShootRogue = binaryReader.ReadByte();
        AttackMage = binaryReader.ReadByte();
        DefenseMage = binaryReader.ReadByte();
        Grow = binaryReader.ReadByte();
        Type2 = binaryReader.ReadByte();
        Type3 = binaryReader.ReadByte();
        ReqStr = binaryReader.ReadUInt16();
        ReqDex = binaryReader.ReadUInt16();
        ReqRec = binaryReader.ReadUInt16();
        ReqInt = binaryReader.ReadUInt16();
        ReqWis = binaryReader.ReadUInt16();
        ReqLuc = binaryReader.ReadUInt16();

        if (episode >= Episode.EP6)
        {
            Unknown = binaryReader.ReadUInt16();
        }

        ReqVg = binaryReader.ReadUInt16();
        ReqOg = binaryReader.ReadByte();
        ReqIg = binaryReader.ReadByte();


        if (episode <= Episode.EP5)
        {
            Range = binaryReader.ReadByte();
        }
        else
        {
            Range = binaryReader.ReadUInt16();
        }

        AttackTime = binaryReader.ReadByte();
        Attrib = binaryReader.ReadByte();
        Special = binaryReader.ReadByte();
        Slot = binaryReader.ReadByte();
        Quality = binaryReader.ReadUInt16();
        Attack = binaryReader.ReadUInt16();
        AttackAdd = binaryReader.ReadUInt16();
        Def = binaryReader.ReadUInt16();
        Resist = binaryReader.ReadUInt16();
        Hp = binaryReader.ReadUInt16();
        Sp = binaryReader.ReadUInt16();
        Mp = binaryReader.ReadUInt16();
        Str = binaryReader.ReadUInt16();
        Dex = binaryReader.ReadUInt16();
        Rec = binaryReader.ReadUInt16();
        Int = binaryReader.ReadUInt16();
        Wis = binaryReader.ReadUInt16();
        Luc = binaryReader.ReadUInt16();
        Speed = binaryReader.ReadByte();
        Exp = binaryReader.ReadByte();
        BuyPrice = binaryReader.ReadUInt32();
        SellPrice = binaryReader.ReadUInt32();
        Grade = binaryReader.ReadUInt16();
        Drop = binaryReader.ReadUInt16();
        Server = binaryReader.ReadByte();
        Count = binaryReader.ReadByte();

        if (episode >= Episode.EP6)
        {
            Duration = binaryReader.ReadUInt32();
            ExtDuration = binaryReader.ReadByte();
            SecOption = binaryReader.ReadByte();
            OptionRate = binaryReader.ReadByte();
            BuyMethod = binaryReader.ReadByte();
            MaxLevel = binaryReader.ReadByte();

            Arg1 = binaryReader.ReadByte();
            Arg2 = binaryReader.ReadByte();
            Arg3 = binaryReader.ReadByte();
            Arg4 = binaryReader.ReadByte();
            Arg5 = binaryReader.ReadByte();

            Arg6 = binaryReader.ReadUInt32();
            Arg7 = binaryReader.ReadUInt32();
            Arg8 = binaryReader.ReadUInt32();
            Arg9 = binaryReader.ReadUInt32();
            Arg10 = binaryReader.ReadUInt32();
            Arg11 = binaryReader.ReadUInt32();
            Arg12 = binaryReader.ReadUInt32();
            Arg13 = binaryReader.ReadUInt32();
            Arg14 = binaryReader.ReadUInt32();
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var episode = binaryWriter.SerializationOptions.Episode;

        binaryWriter.Write(Name);
        binaryWriter.Write(Description);
        binaryWriter.Write(ItemType);
        binaryWriter.Write(ItemTypeId);
        binaryWriter.Write(Model);
        binaryWriter.Write(Icon);
        binaryWriter.Write(MinLevel);
        binaryWriter.Write(Country);
        binaryWriter.Write(AttackFighter);
        binaryWriter.Write(DefenseFighter);
        binaryWriter.Write(PatrolRogue);
        binaryWriter.Write(ShootRogue);
        binaryWriter.Write(AttackMage);
        binaryWriter.Write(DefenseMage);
        binaryWriter.Write(Grow);
        binaryWriter.Write(Type2);
        binaryWriter.Write(Type3);
        binaryWriter.Write(ReqStr);
        binaryWriter.Write(ReqDex);
        binaryWriter.Write(ReqRec);
        binaryWriter.Write(ReqInt);
        binaryWriter.Write(ReqWis);
        binaryWriter.Write(ReqLuc);

        if (episode >= Episode.EP6)
        {
            binaryWriter.Write(Unknown);
        }

        binaryWriter.Write(ReqVg);
        binaryWriter.Write(ReqOg);
        binaryWriter.Write(ReqIg);

        if (episode <= Episode.EP5)
        {
            binaryWriter.Write((byte)Range);
        }
        else
        {
            binaryWriter.Write(Range);
        }

        binaryWriter.Write(AttackTime);
        binaryWriter.Write(Attrib);
        binaryWriter.Write(Special);
        binaryWriter.Write(Slot);
        binaryWriter.Write(Quality);
        binaryWriter.Write(Attack);
        binaryWriter.Write(AttackAdd);
        binaryWriter.Write(Def);
        binaryWriter.Write(Resist);
        binaryWriter.Write(Hp);
        binaryWriter.Write(Sp);
        binaryWriter.Write(Mp);
        binaryWriter.Write(Str);
        binaryWriter.Write(Dex);
        binaryWriter.Write(Rec);
        binaryWriter.Write(Int);
        binaryWriter.Write(Wis);
        binaryWriter.Write(Luc);
        binaryWriter.Write(Speed);
        binaryWriter.Write(Exp);
        binaryWriter.Write(BuyPrice);
        binaryWriter.Write(SellPrice);
        binaryWriter.Write(Grade);
        binaryWriter.Write(Drop);
        binaryWriter.Write(Server);
        binaryWriter.Write(Count);

        if (episode >= Episode.EP6)
        {
            binaryWriter.Write(Duration);
            binaryWriter.Write(ExtDuration);
            binaryWriter.Write(SecOption);
            binaryWriter.Write(OptionRate);
            binaryWriter.Write(BuyMethod);
            binaryWriter.Write(MaxLevel);

            binaryWriter.Write(Arg1);
            binaryWriter.Write(Arg2);
            binaryWriter.Write(Arg3);
            binaryWriter.Write(Arg4);
            binaryWriter.Write(Arg5);

            binaryWriter.Write(Arg6);
            binaryWriter.Write(Arg7);
            binaryWriter.Write(Arg8);
            binaryWriter.Write(Arg9);
            binaryWriter.Write(Arg10);
            binaryWriter.Write(Arg11);
            binaryWriter.Write(Arg12);
            binaryWriter.Write(Arg13);
            binaryWriter.Write(Arg14);
        }
    }
}
