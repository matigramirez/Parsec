using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Itm;

/// <summary>
/// Describes how an IT2 item mesh is attached to a character skeleton bone.
/// </summary>
public sealed class ItmBoneTransform : ISerializable
{
    public int Bone { get; set; }

    public Vector3 Position { get; set; }

    public Quaternion Rotation { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Bone = binaryReader.ReadInt32();
        Position = binaryReader.Read<Vector3>();
        Rotation = binaryReader.Read<Quaternion>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Bone);
        binaryWriter.Write(Position);
        binaryWriter.Write(Rotation);
    }
}
