using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    public class Portal
    {
        public Point3D Position { get; set; }
        public Faction Faction { get; set; }
        public short MinLevel { get; set; }
        public short MaxLevel { get; set; }
        public int DestinationMapId { get; set; }
        public Point3D DestinationPosition { get; set; }
    }
}
