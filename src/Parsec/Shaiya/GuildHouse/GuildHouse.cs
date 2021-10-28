using System.Collections.Generic;

namespace Parsec.Shaiya.GUILDHOUSE
{
    public class GuildHouse : SData
    {
        public int Unknown { get; set; }
        public int HousePrice { get; set; }
        public int ServicePrice { get; set; }
        public List<NpcInfo> NpcInfoList { get; } = new();
        public List<int> NpcIds { get; } = new();

        public GuildHouse(string path) : base(path)
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
    }
}
