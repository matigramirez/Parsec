using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Obj3DO
{
    public class Vertex
    {
        [ShaiyaProperty]
        public Vector3 Coordinates { get; set; }

        [ShaiyaProperty]
        public Vector3 Normal { get; set; }

        [ShaiyaProperty]
        public Vector2 UV { get; set; }
    }
}
