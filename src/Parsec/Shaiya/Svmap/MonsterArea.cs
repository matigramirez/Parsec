using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    /// <summary>
    /// Represents an area with monsters inside
    /// </summary>
    public class MonsterArea
    {
        public CubicArea Area { get; set; }
        public List<Monster> Monsters { get; set; } = new();

        public MonsterArea(ShaiyaBinaryReader binaryReader)
        {
            Area = new CubicArea(binaryReader);

            var monsterCount = binaryReader.Read<int>();

            // Read monsters
            for (int i = 0; i < monsterCount; i++)
            {
                var monster = new Monster(binaryReader);
                Monsters.Add(monster);
            }
        }
    }
}
