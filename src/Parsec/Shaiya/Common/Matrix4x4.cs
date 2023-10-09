using Newtonsoft.Json;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// A structure encapsulating a 4x4 matrix.
/// </summary>
public struct Matrix4x4 : ISerializable
{
    /// <summary>
    /// The matrix's data serialized into an array of float arrays
    /// </summary>
    public float[,] Data
    {
        get => new float[4, 4] { { M11, M12, M13, M14 }, { M21, M22, M23, M24 }, { M31, M32, M33, M34 }, { M41, M42, M43, M44 } };
        set
        {
            if (value.Length < 16)
                throw new ArgumentException("Matrix4x4.Data: Array must be of length 16");

            M11 = value[0, 0];
            M12 = value[0, 1];
            M13 = value[0, 2];
            M14 = value[0, 3];
            M21 = value[1, 0];
            M22 = value[1, 1];
            M23 = value[1, 2];
            M24 = value[1, 3];
            M31 = value[2, 0];
            M32 = value[2, 1];
            M33 = value[2, 2];
            M34 = value[2, 3];
            M41 = value[3, 0];
            M42 = value[3, 1];
            M43 = value[3, 2];
            M44 = value[3, 3];
        }
    }

    /// <summary>
    /// Value at row 1, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M11;

    /// <summary>
    /// Value at row 1, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M12;

    /// <summary>
    /// Value at row 1, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M13;

    /// <summary>
    /// Value at row 1, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M14;

    /// <summary>
    /// Value at row 2, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M21;

    /// <summary>
    /// Value at row 2, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M22;

    /// <summary>
    /// Value at row 2, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M23;

    /// <summary>
    /// Value at row 2, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M24;

    /// <summary>
    /// Value at row 3, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M31;

    /// <summary>
    /// Value at row 3, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M32;

    /// <summary>
    /// Value at row 3, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M33;

    /// <summary>
    /// Value at row 3, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M34;

    /// <summary>
    /// Value at row 4, column 1 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M41;

    /// <summary>
    /// Value at row 4, column 2 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M42;

    /// <summary>
    /// Value at row 4, column 3 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M43;

    /// <summary>
    /// Value at row 4, column 4 of the matrix.
    /// </summary>
    [JsonIgnore]
    public float M44;

    /// <summary>
    /// Constructs a Matrix4x4 from the given components.
    /// </summary>
    public Matrix4x4(
        float m11,
        float m12,
        float m13,
        float m14,
        float m21,
        float m22,
        float m23,
        float m24,
        float m31,
        float m32,
        float m33,
        float m34,
        float m41,
        float m42,
        float m43,
        float m44
    )
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M14 = m14;

        M21 = m21;
        M22 = m22;
        M23 = m23;
        M24 = m24;

        M31 = m31;
        M32 = m32;
        M33 = m33;
        M34 = m34;

        M41 = m41;
        M42 = m42;
        M43 = m43;
        M44 = m44;
    }

    public void Read(SBinaryReader binaryReader)
    {
        M11 = binaryReader.ReadSingle();
        M21 = binaryReader.ReadSingle();
        M31 = binaryReader.ReadSingle();
        M41 = binaryReader.ReadSingle();
        M12 = binaryReader.ReadSingle();
        M22 = binaryReader.ReadSingle();
        M32 = binaryReader.ReadSingle();
        M42 = binaryReader.ReadSingle();
        M13 = binaryReader.ReadSingle();
        M23 = binaryReader.ReadSingle();
        M33 = binaryReader.ReadSingle();
        M43 = binaryReader.ReadSingle();
        M14 = binaryReader.ReadSingle();
        M24 = binaryReader.ReadSingle();
        M34 = binaryReader.ReadSingle();
        M44 = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(M11);
        binaryWriter.Write(M21);
        binaryWriter.Write(M31);
        binaryWriter.Write(M41);
        binaryWriter.Write(M12);
        binaryWriter.Write(M22);
        binaryWriter.Write(M32);
        binaryWriter.Write(M42);
        binaryWriter.Write(M13);
        binaryWriter.Write(M23);
        binaryWriter.Write(M33);
        binaryWriter.Write(M43);
        binaryWriter.Write(M14);
        binaryWriter.Write(M24);
        binaryWriter.Write(M34);
        binaryWriter.Write(M44);
    }
}
