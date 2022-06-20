using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Represents a vector in a 2-dimensional space
/// </summary>
public struct Vector2 : IBinary
{
    /// <summary>
    /// 1st (first) element of the vector
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// 2nd (second) element of the vector
    /// </summary>
    public float Y { get; set; }

    public Vector2(SBinaryReader binaryReader)
    {
        X = binaryReader.Read<float>();
        Y = binaryReader.Read<float>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(X.GetBytes());
        buffer.AddRange(Y.GetBytes());
        return buffer;
    }
}
