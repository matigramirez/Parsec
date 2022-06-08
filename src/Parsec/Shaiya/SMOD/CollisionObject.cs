using System.Collections.Generic;
using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SMOD
{
    public class CollisionObject
    {
        [ShaiyaProperty]
        [LengthPrefixedList(typeof(SimpleVertex))]
        public List<SimpleVertex> Vertices { get; set; } = new();

        [ShaiyaProperty]
        [LengthPrefixedList(typeof(Face))]
        public List<Face> Faces { get; set; } = new();
    }
}
