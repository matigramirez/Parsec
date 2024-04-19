using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// A structure encapsulating a four-dimensional vector (x,y,z,w),
/// which is used to efficiently rotate an object about the (x,y,z) vector by the angle theta, where w = cos(theta/2).
/// </summary>
public class Quaternion : ISerializable
{
    /// <summary>
    /// Specifies the X-value of the vector component of the Quaternion.
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// Specifies the Y-value of the vector component of the Quaternion.
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// Specifies the Z-value of the vector component of the Quaternion.
    /// </summary>
    public float Z { get; set; }

    /// <summary>
    /// Specifies the rotation component of the Quaternion.
    /// </summary>
    public float W { get; set; }

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
