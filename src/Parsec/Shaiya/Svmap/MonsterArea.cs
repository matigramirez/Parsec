using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    /// <summary>
    /// Represents an area with monsters inside
    /// </summary>
    public class MonsterArea : IBinary
    {
        public BoundingBox Area { get; set; }
        public List<Monster> Monsters { get; set; } = new();

        [JsonConstructor]
        public MonsterArea()
        {
        }
        
        public MonsterArea(SBinaryReader binaryReader)
        {
            Area = new BoundingBox(binaryReader);

            var monsterCount = binaryReader.Read<int>();

            // Read monsters
            for (int i = 0; i < monsterCount; i++)
            {
                var monster = new Monster(binaryReader);
                Monsters.Add(monster);
            }
        }

        public byte[] GetBytes(params object[] options)
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
