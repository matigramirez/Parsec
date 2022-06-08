using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SMOD
{
    public class Vertex
    {
        [ShaiyaProperty]
        public Vector3 Coordinates { get; set; }

        [ShaiyaProperty]
        public Vector3 Normal { get; set; }

        /// <summary>
        /// SMOD's don't have bones, that's why this value is always -1.
        /// </summary>
        [ShaiyaProperty]
        public int BoneId { get; set; } = -1;

        [ShaiyaProperty]
        public Vector2 UV { get; set; }
    }
}
