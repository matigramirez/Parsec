using System.Numerics;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = Parsec.Shaiya.Common.Vector3;

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
        public Matrix4 TransformationMatrix { get; set; }

        /// <summary>
        /// The initial translation <see cref="Common.Vector3"/> obtained from the <see cref="TransformationMatrix"/>
        /// </summary>
        public Vector3 Translation { get; set; }

        /// <summary>
        /// The initial rotation <see cref="System.Numerics.Quaternion"/> of the bone obtained from the <see cref="TransformationMatrix"/>
        /// </summary>
        public Quaternion Rotation { get; set; }

        /// <summary>
        /// The initial scale in the 3 directions as a <see cref="Vector3"/> obtained from the <see cref="TransformationMatrix"/>
        /// </summary>
        public Vector3 Scale { get; set; }

        public Bone(int boneIndex, SBinaryReader binaryReader)
        {
            BoneIndex = boneIndex;

            // Parse original matrix
            TransformationMatrix = new Matrix4(binaryReader);

            // Decompose the transformation matrix to obtain the scale, rotation and translation separately
            Matrix4x4.Decompose(TransformationMatrix.NumericMatrix, out var scale, out var rotationQuaternion,
                                out var translation);

            Scale = new Vector3(scale.X, scale.Y, scale.Z);
            Translation = new Vector3(translation.X, translation.Y, translation.Z);
            Rotation = rotationQuaternion;
        }

        [JsonConstructor]
        public Bone()
        {
        }

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options) => TransformationMatrix.GetBytes();
    }
}
