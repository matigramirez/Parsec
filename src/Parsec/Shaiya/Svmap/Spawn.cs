using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    public class Spawn
    {
        public int Unknown1 { get; set; }
        public Faction Faction { get; set; }
        public int Unknown2 { get; set; }
        public CubicArea Area { get; set; }

        public Spawn(ShaiyaBinaryReader binaryReader)
        {
            Unknown1 = binaryReader.Read<int>();
            Faction = (Faction)binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<int>();
            Area = new CubicArea(binaryReader);
        }
    }
}
