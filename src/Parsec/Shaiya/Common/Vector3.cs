using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Represents a vector in a 3-dimensional space
/// </summary>
public struct Vector3 : IBinary
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

    [JsonConstructor]
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3(SBinaryReader binaryReader)
    {
        X = binaryReader.Read<float>();
        Y = binaryReader.Read<float>();
        Z = binaryReader.Read<float>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(X.GetBytes());
        buffer.AddRange(Y.GetBytes());
        buffer.AddRange(Z.GetBytes());
        return buffer;
    }
}
