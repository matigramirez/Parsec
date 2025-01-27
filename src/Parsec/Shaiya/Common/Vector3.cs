using System.Text.Json.Serialization;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Represents a vector in a 3-dimensional space
/// </summary>
public struct Vector3 : ISerializable
{
    private float _x;

    private float _y;

    private float _z;

    /// <summary>
    /// 1st (first) element of the vector
    /// </summary>
    public float X
    {
        get => _x;
        set => _x = float.IsNaN(value) ? 0 : value;
    }

    /// <summary>
    /// 2nd (second) element of the vector
    /// </summary>
    public float Y
    {
        get => _y;
        set => _y = float.IsNaN(value) ? 0 : value;
    }

    /// <summary>
    /// 3rd (third) element of the vector
    /// </summary>
    public float Z
    {
        get => _z;
        set => _z = float.IsNaN(value) ? 0 : value;
    }

    public void Read(SBinaryReader binaryReader)
    {
        X = binaryReader.ReadSingle();
        Y = binaryReader.ReadSingle();
        Z = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(X);
        binaryWriter.Write(Y);
        binaryWriter.Write(Z);
    }

    [JsonIgnore]
    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

    public static Vector3 operator +(Vector3 vec1, Vector3 vec2) =>
        new()
        {
            X = vec1.X + vec2.X,
            Y = vec1.Y + vec2.Y,
            Z = vec1.Z + vec2.Z
        };

    public static Vector3 operator -(Vector3 vec1, Vector3 vec2) =>
        new()
        {
            X = vec1.X - vec2.X,
            Y = vec1.Y - vec2.Y,
            Z = vec1.Z - vec2.Z
        };
}
