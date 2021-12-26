using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld
{
    /// <summary>
    /// Represents a spawn area in the world
    /// </summary>
    public class SpawnArea
    {
        /// <summary>
        /// Almost always 1
        /// </summary>
        public int Unknown_1 { get; set; }

        /// <summary>
        /// The spawn area
        /// </summary>
        public CubicArea Area { get; set; }

        /// <summary>
        /// Almost always 0
        /// </summary>
        public int Unknown_2 { get; set; }

        /// <summary>
        /// Faction which uses this spawn area
        /// </summary>
        public Faction Faction { get; set; }

        /// <summary>
        /// Almost always 0
        /// </summary>
        public int Unknown_3 { get; set; }

        public SpawnArea(SBinaryReader binaryReader)
        {
            Unknown_1 = binaryReader.Read<int>();
            Area = new CubicArea(binaryReader);
            Unknown_2 = binaryReader.Read<int>();
            Faction = (Faction)binaryReader.Read<int>();
            Unknown_3 = binaryReader.Read<int>();
        }
    }
}
