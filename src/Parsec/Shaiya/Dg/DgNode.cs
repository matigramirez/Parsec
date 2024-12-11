using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgNode : ISerializable
{
    // TODO: Check
    public Vector3 Center { get; set; }

    // TODO: Check
    public BoundingBox ViewBox { get; set; }

    // TODO: Check
    public BoundingBox CollisionBox { get; set; }

    public List<DgObject> Objects { get; set; } = new();

    public DgMeshCollisionType CollisionType { get; set; }

    public DgCollisionMesh CollisionMesh { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Center = binaryReader.Read<Vector3>();
        ViewBox = binaryReader.Read<BoundingBox>();
        CollisionBox = binaryReader.Read<BoundingBox>();

        Objects = binaryReader.ReadList<DgObject>().ToList();

        CollisionType = (DgMeshCollisionType)binaryReader.ReadInt32();

        if (CollisionType == DgMeshCollisionType.Collision)
        {
            // Read extra node info
            CollisionMesh = binaryReader.Read<DgCollisionMesh>();
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Center);
        binaryWriter.Write(ViewBox);
        binaryWriter.Write(CollisionBox);
        binaryWriter.Write(Objects.ToSerializable());
        binaryWriter.Write((int)CollisionType);

        if (CollisionType == DgMeshCollisionType.Collision)
        {
            binaryWriter.Write(CollisionMesh);
        }
    }
}
