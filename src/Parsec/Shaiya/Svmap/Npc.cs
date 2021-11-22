using System.Collections.Generic;
using Parsec.Readers;

namespace Parsec.Shaiya.SVMAP
{
    public class Npc
    {
        public int Type { get; set; }
        public int NpcId { get; set; }
        public List<NpcLocation> Locations { get; set; } = new();

        public Npc(ShaiyaBinaryReader binaryReader)
        {
            Type = binaryReader.Read<int>();
            NpcId = binaryReader.Read<int>();

            var locationCount = binaryReader.Read<int>();

            for (int i = 0; i < locationCount; i++)
            {
                var npcLocation = new NpcLocation(binaryReader);
                Locations.Add(npcLocation);
            }
        }
    }
}
