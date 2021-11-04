using System.Numerics;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Quaternion = System.Numerics.Quaternion;
using Vector3 = Parsec.Shaiya.Common.Vector3;

namespace Parsec.Shaiya.OBJ3DC
{
    public class Bone3DC
    {
        public Matrix4 OriginalMatrix { get; set; }
        public Matrix4 TransformationMatrix { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 Translation { get; set; }
        public Quaternion RotationQuaternion { get; set; }

        public Bone3DC(ShaiyaBinaryReader binaryReader)
        {
            // Parse original matrix
            OriginalMatrix = new Matrix4(binaryReader);

            // Obtain transformation matrix by inverting the original matrix
            Matrix4x4.Invert(OriginalMatrix.NumericMatrix, out var inverseMatrix);
            TransformationMatrix = new Matrix4(inverseMatrix);

            // Decompose the transformation matrix to obtain the scale, rotation and translation separately
            Matrix4x4.Decompose(inverseMatrix, out var scale, out var rotationQuaternion, out var translation);
            Scale = new Vector3(scale.X, scale.Y, scale.Z);
            Translation = new Vector3(translation.X, translation.Y, translation.Z);
            RotationQuaternion = rotationQuaternion;
        }
    }
}