using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.Physics;

/// <summary>
/// Binds a flexible-mesh vertex to a bone in the rigid mesh's skeleton.
/// </summary>
public sealed class PcAnchor : ISerializable
{
    public bool IsActive { get; set; }

    public int ClothVertex { get; set; }

    public int SkeletonBone { get; set; }

    public Vector3 BoneLocalPosition { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        IsActive = binaryReader.ReadUInt32() != 0;
        ClothVertex = binaryReader.ReadInt32();
        SkeletonBone = binaryReader.ReadInt32();
        BoneLocalPosition = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(IsActive ? 1u : 0u);
        binaryWriter.Write(ClothVertex);
        binaryWriter.Write(SkeletonBone);
        binaryWriter.Write(BoneLocalPosition);
    }
}
