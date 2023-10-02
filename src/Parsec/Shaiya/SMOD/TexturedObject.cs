using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// A 3d mesh with a texture
/// </summary>
public sealed class TexturedObject : IBinary
{
    /// <summary>
    /// Name of the .tga texture file. Although they have the .tga extension, the client actually has .dds files, so they're very likely
    /// replacing the .tga extension with .dds when searching for the texture.
    /// </summary>
    public string TextureName { get; set; } = string.Empty;

    /// <summary>
    /// Mesh vertices
    /// </summary>
    public List<Vertex> Vertices { get; set; } = new();

    /// <summary>
    /// Mesh triangular faces
    /// </summary>
    public List<Face> Faces { get; set; } = new();

    [JsonConstructor]
    public TexturedObject()
    {
    }

    public TexturedObject(SBinaryReader binaryReader)
    {
        TextureName = binaryReader.ReadString();

        int vertexCount = binaryReader.Read<int>();
        for (int i = 0; i < vertexCount; i++)
            Vertices.Add(new Vertex(binaryReader));

        int faceCount = binaryReader.Read<int>();
        for (int i = 0; i < faceCount; i++)
            Faces.Add(new Face(binaryReader));
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(TextureName.GetLengthPrefixedBytes());
        buffer.AddRange(Vertices.GetBytes());
        buffer.AddRange(Faces.GetBytes());
        return buffer;
    }
}
