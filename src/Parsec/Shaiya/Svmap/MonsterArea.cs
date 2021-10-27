using System.Collections.Generic;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    /// <summary>
    /// Represents an area with monsters inside
    /// </summary>
    public class MonsterArea
    {
        public CubicArea Area { get; set; }
        public List<Monster> Monsters { get; set; }
    }
}
