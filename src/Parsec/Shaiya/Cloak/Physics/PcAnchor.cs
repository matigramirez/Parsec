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
        IsActive = binaryReader.ReadUInt32() == 1;
        ClothVertex = binaryReader.ReadInt32();
        SkeletonBone = binaryReader.ReadInt32();
        BoneLocalPosition = binaryReader.Read<Vector3>();
        ValidatePosition();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        ValidatePosition();

        binaryWriter.Write(IsActive ? 1u : 0u);
        binaryWriter.Write(ClothVertex);
        binaryWriter.Write(SkeletonBone);
        binaryWriter.Write(BoneLocalPosition);
    }

    private void ValidatePosition()
    {
        if (float.IsNaN(BoneLocalPosition.X) || float.IsInfinity(BoneLocalPosition.X) ||
            float.IsNaN(BoneLocalPosition.Y) || float.IsInfinity(BoneLocalPosition.Y) ||
            float.IsNaN(BoneLocalPosition.Z) || float.IsInfinity(BoneLocalPosition.Z))
        {
            throw new InvalidDataException("A .PC anchor position must contain finite values.");
        }
    }
}
