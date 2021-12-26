using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld
{
    public class Npc
    {
        public int Type { get; set; }
        public int TypeId { get; set; }
        public Vector3 Position { get; set; }
        public float Orientation { get; set; }
        public List<Vector3> PatrolPositions { get; } = new();

        public Npc(SBinaryReader binaryReader)
        {
            Type = binaryReader.Read<int>();
            TypeId = binaryReader.Read<int>();
            Position = new Vector3(binaryReader);
            Orientation = binaryReader.Read<float>();

            var patrolPositionCount = binaryReader.Read<int>();

            for (int i = 0; i < patrolPositionCount; i++)
            {
                var patrolPosition = new Vector3(binaryReader);
                PatrolPositions.Add(patrolPosition);
            }
        }
    }
}
