using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3dc;

public sealed class _3dcBone : ISerializable
{
    /// <summary>
    /// The transformation matrix of this bone, which holds the starting position and rotation of the bone
    /// </summary>
    public Matrix4x4 Matrix { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Matrix = binaryReader.Read<Matrix4x4>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Matrix);
    }
}
