using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

/// <summary>
/// Represents a .VANI file.
/// According to the game client, VAni files are called "SModelAnimation", but a better name for it
/// would probably be "Environmental Model with Animation"
/// </summary>
public sealed class VAniObject : IBinary
{
    [JsonConstructor]
    public VAniObject()
    {
    }

    public VAniObject(SBinaryReader binaryReader, int frameCount)
    {
        TextureName = binaryReader.ReadString();

        int faceCount = binaryReader.Read<int>();
        for (int i = 0; i < faceCount; i++)
            Faces.Add(new Face(binaryReader));

        int vertexCount = binaryReader.Read<int>();
        for (int i = 0; i < vertexCount; i++)
            Vertices.Add(new Vertex(binaryReader, frameCount));
    }

    /// <summary>
    /// Texture name of the .dds file
    /// </summary>
    public string TextureName { get; set; }

    /// <summary>
    /// List of the 3d object's faces (polygons - triangles)
    /// </summary>
    public List<Face> Faces { get; } = new();

    /// <summary>
    /// List of the 3d object's vertices
    /// </summary>
    public List<Vertex> Vertices { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(TextureName.GetLengthPrefixedBytes());
        buffer.AddRange(Faces.GetBytes());
        buffer.AddRange(Vertices.GetBytes());
        return buffer;
    }
}
