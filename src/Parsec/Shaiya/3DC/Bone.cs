using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DC
{
    public class Bone : IBinary
    {
        /// <summary>
        /// The index of this bone in the skeleton
        /// </summary>
        public int BoneIndex { get; set; }

        /// <summary>
        /// The transformation matrix of this bone, which holds the starting position and rotation of the bone
        /// </summary>
        public Matrix4x4 Matrix { get; set; }

        public Bone(SBinaryReader binaryReader, int boneIndex)
        {
            BoneIndex = boneIndex;

            // Read the matrix
            Matrix = new Matrix4x4(binaryReader);
        }

        [JsonConstructor]
        public Bone()
        {
        }

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options) => Matrix.GetBytes();
    }
}
