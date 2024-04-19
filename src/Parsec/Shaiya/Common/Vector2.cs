using System.Text.Json.Serialization;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Represents a vector in a 2-dimensional space
/// </summary>
public class Vector2 : ISerializable
{
    /// <summary>
    /// 1st (first) element of the vector
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// 2nd (second) element of the vector
    /// </summary>
    public float Y { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        X = binaryReader.ReadSingle();
        Y = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(X);
        binaryWriter.Write(Y);
    }

    [JsonIgnore]
    public double Length => Math.Sqrt(X * X + Y * Y);

    public static Vector2 operator +(Vector2 vec1, Vector2 vec2) =>
        new()
        {
            X = vec1.X + vec2.X,
            Y = vec1.Y + vec2.Y
        };

    public static Vector2 operator -(Vector2 vec1, Vector2 vec2) =>
        new()
        {
            X = vec1.X - vec2.X,
            Y = vec1.Y - vec2.Y
        };
}
