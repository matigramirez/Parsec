using System.Collections.Generic;
using System.Numerics;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = Parsec.Shaiya.Common.Vector3;

namespace Parsec.Shaiya.ANI
{
    public class BoneStep
    {
        public int BoneIndex { get; set; }

        public Matrix4 OriginalMatrix { get; set; }

        /// <summary>
        /// The transformation matrix for the initial position of the bone, obtained by inverting the original matrix read from the ani file
        /// </summary>
        public Matrix4 TransformationMatrix { get; set; }

        /// <summary>
        /// The scaling for the bone, obtained from the transformation matrix
        /// </summary>
        public Vector3 BoneScale { get; set; }

        /// <summary>
        /// The initial translation of the bone, obtained from the transformation matrix
        /// </summary>
        public Vector3 InitialTranslation { get; set; }

        /// <summary>
        /// The initial rotation of the bone, obtained from the transformation matrix
        /// </summary>
        public Quaternion InitialRotation { get; set; }
        public List<KeyframeRotation> KeyframeRotations { get; } = new();
        public List<KeyframeTranslation> KeyframeTranslations { get; } = new();

        public BoneStep(ShaiyaBinaryReader binaryReader)
        {
            BoneIndex = binaryReader.Read<int>();

            // Read original matrix
            OriginalMatrix = new Matrix4(binaryReader);

            // Invert original matrix to obtain transformation matrix
            Matrix4x4.Invert(OriginalMatrix.NumericMatrix, out var inverseMatrix);
            TransformationMatrix = new Matrix4(inverseMatrix);

            // Decompose the transformation matrix to obtain the scale, rotation and translation separately
            Matrix4x4.Decompose(inverseMatrix, out var scale, out var rotationQuaternion, out var translation);
            BoneScale = new Vector3(scale.X, scale.Y, scale.Z);
            InitialTranslation = new Vector3(translation.X, translation.Y, translation.Z);
            InitialRotation = rotationQuaternion;

            var keyframeRotationCount = binaryReader.Read<int>();

            for (int i = 0; i < keyframeRotationCount; i ++)
            {
                var keyframeRotation = new KeyframeRotation(binaryReader);
                KeyframeRotations.Add(keyframeRotation);
            }

            var keyframeTranslationCount = binaryReader.Read<int>();

            for (int i = 0; i < keyframeTranslationCount; i++)
            {
                var keyframeTranslation = new KeyframeTranslation(binaryReader);
                KeyframeTranslations.Add(keyframeTranslation);
            }
        }
    }
}
