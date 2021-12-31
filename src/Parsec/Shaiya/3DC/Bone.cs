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

        /// <summary>
        /// The initial translation <see cref="Common.Vector3"/> obtained from the <see cref="Matrix"/>
        /// </summary>
        public Vector3 Translation { get; set; }

        /// <summary>
        /// The initial rotation <see cref="System.Numerics.Quaternion"/> of the bone obtained from the <see cref="Matrix"/>
        /// </summary>
        public Quaternion Rotation { get; set; }

        public Bone(int boneIndex, SBinaryReader binaryReader)
        {
            BoneIndex = boneIndex;

            // Read the matrix
            Matrix = new Matrix4x4(binaryReader);

            Translation = Matrix.Translation;
            Rotation = Matrix.Rotation;
        }

        [JsonConstructor]
        public Bone()
        {
        }

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options) => Matrix.GetBytes();
    }
}
