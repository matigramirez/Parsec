using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod;

/// <summary>
/// A 3d object used in SMOD files to represent an object where players should collide.
/// </summary>
public sealed class SmodCollisionMesh : ISerializable
{
    /// <summary>
    /// Vertices of the 3d object.
    /// </summary>
    public List<SmodCollisionMeshVertex> Vertices { get; set; } = new();

    /// <summary>
    /// Triangular faces (polygons) of the 3d object.
    /// </summary>
    public List<MeshFace> Faces { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Vertices = binaryReader.ReadList<SmodCollisionMeshVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
    }
}
