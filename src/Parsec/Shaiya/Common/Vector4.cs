using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Represents a vector in a 4-dimensional space
/// </summary>
public struct Vector4 : ISerializable
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

    public void Read(SBinaryReader binaryReader)
    {
        X = binaryReader.ReadSingle();
        Y = binaryReader.ReadSingle();
        Z = binaryReader.ReadSingle();
        W = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(X);
        binaryWriter.Write(Y);
        binaryWriter.Write(Z);
        binaryWriter.Write(W);
    }
}
