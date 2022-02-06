using System.Collections.Generic;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item
{
    public class ItemDefinition : IBinary
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Type { get; set; }
        public byte TypeId { get; set; }
        public byte Model { get; set; }
        public byte Icon { get; set; }
        public short Level { get; set; }
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
        public int ReqLuc { get; set; }
        public short ReqVg { get; set; }
        public byte ReqOg { get; set; }
        public byte ReqIg { get; set; }
        public short Range { get; set; }
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

        public int UnknownInt1 { get; set; }

        public byte UnknownByte1 { get; set; }
        public byte UnknownByte2 { get; set; }
        public byte UnknownByte3 { get; set; }
        public byte UnknownByte4 { get; set; }
        public byte UnknownByte5 { get; set; }
        public byte UnknownByte6 { get; set; }
        public byte UnknownByte7 { get; set; }
        public byte UnknownByte8 { get; set; }
        public byte UnknownByte9 { get; set; }
        public byte UnknownByte10 { get; set; }

        public int UnknownInt2 { get; set; }
        public int UnknownInt3 { get; set; }
        public int UnknownInt4 { get; set; }
        public int UnknownInt5 { get; set; }
        public int UnknownInt6 { get; set; }
        public int UnknownInt7 { get; set; }
        public int UnknownInt8 { get; set; }
        public int UnknownInt9 { get; set; }
        public int UnknownInt10 { get; set; }

        public ItemDefinition(SBinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            Description = binaryReader.ReadString();
            Type = binaryReader.Read<byte>();
            TypeId = binaryReader.Read<byte>();
            Model = binaryReader.Read<byte>();
            Icon = binaryReader.Read<byte>();
            Level = binaryReader.Read<short>();
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
            ReqLuc = binaryReader.Read<int>();
            ReqVg = binaryReader.Read<short>();
            ReqOg = binaryReader.Read<byte>();
            ReqIg = binaryReader.Read<byte>();
            Range = binaryReader.Read<short>();
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
            Mp = binaryReader.Read<short>();
            Sp = binaryReader.Read<short>();
            Speed = binaryReader.Read<byte>();
            Exp = binaryReader.Read<byte>();
            BuyPrice = binaryReader.Read<int>();
            SellPrice = binaryReader.Read<int>();
            Grade = binaryReader.Read<short>();
            Drop = binaryReader.Read<short>();
            Server = binaryReader.Read<byte>();
            Count = binaryReader.Read<byte>();

            // Read unknown fields
            UnknownInt1 = binaryReader.Read<int>();

            UnknownByte1 = binaryReader.Read<byte>();
            UnknownByte2 = binaryReader.Read<byte>();
            UnknownByte3 = binaryReader.Read<byte>();
            UnknownByte4 = binaryReader.Read<byte>();
            UnknownByte5 = binaryReader.Read<byte>();
            UnknownByte6 = binaryReader.Read<byte>();
            UnknownByte7 = binaryReader.Read<byte>();
            UnknownByte8 = binaryReader.Read<byte>();
            UnknownByte9 = binaryReader.Read<byte>();
            UnknownByte10 = binaryReader.Read<byte>();

            UnknownInt2 = binaryReader.Read<int>();
            UnknownInt3 = binaryReader.Read<int>();
            UnknownInt4 = binaryReader.Read<int>();
            UnknownInt5 = binaryReader.Read<int>();
            UnknownInt6 = binaryReader.Read<int>();
            UnknownInt7 = binaryReader.Read<int>();
            UnknownInt8 = binaryReader.Read<int>();
            UnknownInt9 = binaryReader.Read<int>();
            UnknownInt10 = binaryReader.Read<int>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Name.GetLengthPrefixedBytes());
            buffer.AddRange(Description.GetLengthPrefixedBytes());
            buffer.Add(Type);
            buffer.Add(TypeId);
            buffer.Add(Model);
            buffer.Add(Icon);
            buffer.AddRange(Level.GetBytes());
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
            buffer.AddRange(Range.GetBytes());
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

            buffer.AddRange(UnknownInt1.GetBytes());
            buffer.Add(UnknownByte1);
            buffer.Add(UnknownByte2);
            buffer.Add(UnknownByte3);
            buffer.Add(UnknownByte4);
            buffer.Add(UnknownByte5);
            buffer.Add(UnknownByte6);
            buffer.Add(UnknownByte7);
            buffer.Add(UnknownByte8);
            buffer.Add(UnknownByte9);
            buffer.Add(UnknownByte10);
            buffer.AddRange(UnknownInt2.GetBytes());
            buffer.AddRange(UnknownInt3.GetBytes());
            buffer.AddRange(UnknownInt4.GetBytes());
            buffer.AddRange(UnknownInt5.GetBytes());
            buffer.AddRange(UnknownInt6.GetBytes());
            buffer.AddRange(UnknownInt7.GetBytes());
            buffer.AddRange(UnknownInt8.GetBytes());
            buffer.AddRange(UnknownInt9.GetBytes());
            buffer.AddRange(UnknownInt10.GetBytes());

            return buffer.ToArray();
        }
    }
}
