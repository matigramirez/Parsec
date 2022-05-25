using System;
using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.GuildHouse
{
    public class GuildHouse : SData.SData, IJsonReadable
    {
        public int Unknown { get; set; }
        public int HousePrice { get; set; }
        public int ServicePrice { get; set; }
        public List<NpcInfo> NpcInfoList { get; } = new();
        public List<int> NpcIds { get; } = new();

        public override void Read(params object[] options)
        {
            Unknown = _binaryReader.Read<int>();
            HousePrice = _binaryReader.Read<int>();
            ServicePrice = _binaryReader.Read<int>();

            for (int i = 0; i < 36; i++)
            {
                var npcInfo = new NpcInfo(_binaryReader);
                NpcInfoList.Add(npcInfo);
            }

            for (int i = 0; i < 24; i++)
            {
                var id = _binaryReader.Read<int>();
                NpcIds.Add(id);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode? episode = null)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Unknown.GetBytes());
            buffer.AddRange(HousePrice.GetBytes());
            buffer.AddRange(ServicePrice.GetBytes());

            foreach (var npcInfo in NpcInfoList)
                buffer.AddRange(npcInfo.GetBytes());

            foreach (var npcId in NpcIds)
                buffer.AddRange(npcId.GetBytes());

            return buffer.ToArray();
        }
    }
}
