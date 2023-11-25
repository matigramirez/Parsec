using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgCollisionMesh : ISerializable
{
    /// <summary>
    /// Vertices of the 3d object.
    /// </summary>
    public List<DgCollisionMeshVertex> Vertices { get; set; } = new();

    /// <summary>
    /// Triangular faces (polygons) of the 3d object.
    /// </summary>
    public List<MeshFace> Faces { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Vertices = binaryReader.ReadList<DgCollisionMeshVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
    }
}
