using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// A 3d object used in SMOD files to represent an object where players should collide.
/// </summary>
public sealed class CollisionObject : IBinary
{
    /// <summary>
    /// Vertices of the 3d object.
    /// </summary>
    public List<SimpleVertex> Vertices { get; set; } = new();

    /// <summary>
    /// Triangular faces (polygons) of the 3d object.
    /// </summary>
    public List<Face> Faces { get; set; } = new();

    [JsonConstructor]
    public CollisionObject()
    {
    }

    public CollisionObject(SBinaryReader binaryReader)
    {
        int vertexCount = binaryReader.Read<int>();
        for (int i = 0; i < vertexCount; i++)
            Vertices.Add(new SimpleVertex(binaryReader));

        int faceCount = binaryReader.Read<int>();
        for (int i = 0; i < faceCount; i++)
            Faces.Add(new Face(binaryReader));
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Vertices.GetBytes());
        buffer.AddRange(Faces.GetBytes());
        return buffer;
    }
}
