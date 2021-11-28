using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    /// <summary>
    /// Represents an area with monsters inside
    /// </summary>
    public class MonsterArea : IBinary
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

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Area.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Monsters.Count));

            foreach (var monster in Monsters)
            {
                buffer.AddRange(monster.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
