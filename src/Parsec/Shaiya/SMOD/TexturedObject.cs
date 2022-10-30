using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// A 3d mesh with a texture
/// </summary>
public sealed class TexturedObject
{
    /// <summary>
    /// Name of the .tga texture file. Although they have the .tga extension, the client actually has .dds files, so they're very likely
    /// replacing the .tga extension with .dds when searching for the texture.
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedString]
    public string TextureName { get; set; }

    /// <summary>
    /// Mesh vertices
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Vertex))]
    public List<Vertex> Vertices { get; set; } = new();

    /// <summary>
    /// Mesh triangular faces
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Face))]
    public List<Face> Faces { get; set; } = new();
}
