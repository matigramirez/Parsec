using Parsec.Readers;
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

        public Portal(ShaiyaBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
            Faction = (Faction)binaryReader.Read<int>();
            MinLevel = binaryReader.Read<short>();
            MaxLevel = binaryReader.Read<short>();
            DestinationMapId = binaryReader.Read<int>();
            DestinationPosition = new Vector3(binaryReader);
        }
    }
}
