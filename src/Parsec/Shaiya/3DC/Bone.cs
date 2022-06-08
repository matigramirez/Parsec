using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Obj3DC
{
    public class Bone
    {
        /// <summary>
        /// The transformation matrix of this bone, which holds the starting position and rotation of the bone
        /// </summary>
        [ShaiyaProperty]
        public Matrix4x4 Matrix { get; set; }
    }
}
