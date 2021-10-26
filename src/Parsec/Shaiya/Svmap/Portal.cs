using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    public class Portal
    {
        public Vector3 Position { get; set; }
        public Faction Faction { get; set; }
        public short MinLevel { get; set; }
        public short MaxLevel { get; set; }
        public int DestinationMapId { get; set; }
        public Vector3 DestinationPosition { get; set; }
    }
}
