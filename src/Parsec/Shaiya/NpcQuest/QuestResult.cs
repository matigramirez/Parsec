using System;
using System.Collections.Generic;
using Parsec.Common;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NPCQUEST
{
    public class QuestResult : IBinary
    {
        public ushort NeedMobId { get; set; }
        public byte NeedMobCount { get; set; }
        public byte NeedItemId { get; set; }
        public byte NeedItemCount { get; set; }
        public uint NeedTime { get; set; }
        public ushort NeedHG { get; set; }
        public short NeedVG { get; set; }
        public byte NeedOG { get; set; }
        public uint Exp { get; set; }
        public uint Money { get; set; }
        public byte ItemType { get; set; }
        public byte ItemTypeId { get; set; }
        public ushort NextQuest { get; set; }

        public QuestResult(ShaiyaBinaryReader binaryReader, Format format)
        {
            NeedMobId = binaryReader.Read<ushort>();
            NeedMobCount = binaryReader.Read<byte>();
            NeedItemId = binaryReader.Read<byte>();
            NeedItemCount = binaryReader.Read<byte>();
            NeedTime = binaryReader.Read<uint>();
            NeedHG = binaryReader.Read<ushort>();
            NeedVG = binaryReader.Read<short>();
            NeedOG = binaryReader.Read<byte>();
            Exp = binaryReader.Read<uint>();
            Money = binaryReader.Read<uint>();
            ItemType = binaryReader.Read<byte>();
            ItemTypeId = binaryReader.Read<byte>();

            // Some extra values are read here for EP6+
            if (format > Format.EP5)
            {
                // This is not correct but it's something along these lines:
                // (the item count might be variable)

                // var itemCount = binaryReader.Read<byte>();
                // var itemType2 = binaryReader.Read<byte>();
                // var itemTypeId2 = binaryReader.Read<byte>();
                // var itemCount2 = binaryReader.Read<byte>();
                // var itemType3 = binaryReader.Read<byte>();
                // var itemTypeId3 = binaryReader.Read<byte>();
                // var itemCount3 = binaryReader.Read<byte>();
            }

            NextQuest = binaryReader.Read<ushort>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(NeedMobId));
            buffer.Add(NeedMobCount);
            buffer.Add(NeedItemId);
            buffer.Add(NeedItemCount);
            buffer.AddRange(BitConverter.GetBytes(NeedTime));
            buffer.AddRange(BitConverter.GetBytes(NeedHG));
            buffer.AddRange(BitConverter.GetBytes(NeedVG));
            buffer.Add(NeedOG);
            buffer.AddRange(BitConverter.GetBytes(Exp));
            buffer.AddRange(BitConverter.GetBytes(Money));
            buffer.Add(ItemType);
            buffer.Add(ItemTypeId);
            buffer.AddRange(BitConverter.GetBytes(NextQuest));

            return buffer.ToArray();
        }
    }
}
