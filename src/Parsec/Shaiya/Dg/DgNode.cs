using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgNode : ISerializable
{
    private const int NodeChildCount = 8;

    public Vector3 Center { get; set; }

    public BoundingBox ViewBox { get; set; }

    public BoundingBox CollisionBox { get; set; }

    public List<DgObject> Objects { get; set; } = new();

    public DgMeshCollisionType CollisionType { get; set; }

    public DgCollisionMesh CollisionMesh { get; set; } = new();

    public List<DgNode> ChildNodes { get; set; } = new();

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

        for (var i = 0; i < NodeChildCount; i++)
        {
            var value = binaryReader.ReadInt32();

            if (value > 0)
            {
                var node = binaryReader.Read<DgNode>();
                ChildNodes.Add(node);
            }
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

        for (var i = 0; i < NodeChildCount; i++)
        {
            if (ChildNodes.Count > i)
            {
                binaryWriter.Write(1);
                binaryWriter.Write(ChildNodes[i]);
            }
            else
            {
                binaryWriter.Write(0);
            }
        }
    }
}
