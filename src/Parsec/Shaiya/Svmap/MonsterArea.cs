using System.Collections.Generic;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    /// <summary>
    /// Represents an area with monsters inside
    /// </summary>
    public class MonsterArea
    {
        public Point3D LowerLimit { get; set; }
        public Point3D UpperLimit { get; set; }
        public int Count { get; set; }
        public List<Monster> Monsters { get; set; }
    }
}
