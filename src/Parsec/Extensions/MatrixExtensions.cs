using System.Numerics;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Extensions
{
    public static class MatrixExtensions
    {
        public static void ReadTransformationMatrix(SBinaryReader binaryReader, out Matrix4x4 matrix)
        {
            matrix = new Matrix4x4
            {
                M11 = binaryReader.Read<float>(),
                M21 = binaryReader.Read<float>(),
                M31 = binaryReader.Read<float>(),
                M41 = binaryReader.Read<float>(),
                M12 = binaryReader.Read<float>(),
                M22 = binaryReader.Read<float>(),
                M32 = binaryReader.Read<float>(),
                M42 = binaryReader.Read<float>(),
                M13 = binaryReader.Read<float>(),
                M23 = binaryReader.Read<float>(),
                M33 = binaryReader.Read<float>(),
                M43 = binaryReader.Read<float>(),
                M14 = binaryReader.Read<float>(),
                M24 = binaryReader.Read<float>(),
                M34 = binaryReader.Read<float>(),
                M44 = binaryReader.Read<float>(),
            };
        }

        public static void ConvertToMatrix4(this Matrix4x4 numericMatrix, out Matrix4 matrix)
        {
            var row1 = new float[]
            {
                numericMatrix.M11, numericMatrix.M12, numericMatrix.M13, numericMatrix.M14
            };
            var row2 = new float[]
            {
                numericMatrix.M21, numericMatrix.M22, numericMatrix.M23, numericMatrix.M24
            };
            var row3 = new float[]
            {
                numericMatrix.M31, numericMatrix.M32, numericMatrix.M33, numericMatrix.M34
            };
            var row4 = new float[]
            {
                numericMatrix.M41, numericMatrix.M42, numericMatrix.M43, numericMatrix.M44
            };

            matrix = new Matrix4(row1, row2, row3, row4);
        }
    }
}
