using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Represents a vector in a 4-dimensional space
/// </summary>
public struct Vector4 : IBinary
{
    /// <summary>
    /// 1st (first) element of the vector
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// 2nd (second) element of the vector
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// 3rd (third) element of the vector
    /// </summary>
    public float Z { get; set; }

    /// <summary>
    /// 4th (fourth) element of the vector
    /// </summary>
    public float W { get; set; }

    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public Vector4(SBinaryReader binaryReader)
    {
        X = binaryReader.Read<float>();
        Y = binaryReader.Read<float>();
        Z = binaryReader.Read<float>();
        W = binaryReader.Read<float>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(X.GetBytes());
        buffer.AddRange(Y.GetBytes());
        buffer.AddRange(Z.GetBytes());
        buffer.AddRange(W.GetBytes());
        return buffer;
    }
}
