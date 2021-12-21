using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.GuildHouse
{
    public class NpcInfo : IBinary
    {
        public byte PriceRate { get; set; }
        public byte NpcLvl { get; set; }
        public byte RapiceMixPercentRate { get; set; }
        public byte RapiceMixDecreRate { get; set; }
        public byte MinRank { get; set; }
        public short Icon { get; set; }
        public short SysMsgId { get; set; }
        public short UpPrice { get; set; }
        public short ServicePrice { get; set; }
        public byte NpcType { get; set; }
        public byte Group { get; set; }

        [JsonConstructor]
        public NpcInfo()
        {
        }

        public NpcInfo(ShaiyaBinaryReader binaryReader)
        {
            PriceRate = binaryReader.Read<byte>();
            NpcLvl = binaryReader.Read<byte>();
            RapiceMixPercentRate = binaryReader.Read<byte>();
            RapiceMixDecreRate = binaryReader.Read<byte>();
            MinRank = binaryReader.Read<byte>();
            Icon = binaryReader.Read<short>();
            SysMsgId = binaryReader.Read<short>();
            UpPrice = binaryReader.Read<short>();
            ServicePrice = binaryReader.Read<short>();
            NpcType = binaryReader.Read<byte>();
            Group = binaryReader.Read<byte>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.Add(PriceRate);
            buffer.Add(NpcLvl);
            buffer.Add(RapiceMixPercentRate);
            buffer.Add(RapiceMixDecreRate);
            buffer.Add(MinRank);
            buffer.AddRange(BitConverter.GetBytes(Icon));
            buffer.AddRange(BitConverter.GetBytes(SysMsgId));
            buffer.AddRange(BitConverter.GetBytes(UpPrice));
            buffer.AddRange(BitConverter.GetBytes(ServicePrice));
            buffer.Add(NpcType);
            buffer.Add(Group);

            return buffer.ToArray();
        }
    }
}
