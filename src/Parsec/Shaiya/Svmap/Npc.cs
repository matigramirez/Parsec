using System.Collections.Generic;

namespace Parsec.Shaiya.SVMAP
{
    public class Npc
    {
        public int Type { get; set; }
        public int NpcId { get; set; }
        public int LocationCount { get; set; }
        public List<NpcLocation> Locations { get; set; }
    }
}
