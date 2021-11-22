using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.SDATA;

namespace Parsec.Shaiya.GUILDHOUSE
{
    public class GuildHouse : SData, IJsonReadable
    {
        public int Unknown { get; set; }
        public int HousePrice { get; set; }
        public int ServicePrice { get; set; }
        public List<NpcInfo> NpcInfoList { get; } = new();
        public List<int> NpcIds { get; } = new();

        public GuildHouse(string path) : base(path)
        {
        }

        [JsonConstructor]
        public GuildHouse()
        {
        }

        public override void Read()
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

        public override void Write(string path)
        {
            // Create byte list which will contain the data
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Unknown));
            buffer.AddRange(BitConverter.GetBytes(HousePrice));
            buffer.AddRange(BitConverter.GetBytes(ServicePrice));

            foreach (var npcInfo in NpcInfoList)
            {
                buffer.AddRange(npcInfo.GetBytes());
            }

            foreach (int npcId in NpcIds)
            {
                buffer.AddRange(BitConverter.GetBytes(npcId));
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
