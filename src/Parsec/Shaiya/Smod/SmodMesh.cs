using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod;

/// <summary>
/// A 3d mesh with a texture
/// </summary>
public sealed class SmodMesh : ISerializable
{
    /// <summary>
    /// Name of the .tga texture file. Although they have the .tga extension, the client actually has .dds files, so they're very likely
    /// replacing the .tga extension with .dds when searching for the texture.
    /// </summary>
    public string TextureName { get; set; } = string.Empty;

    /// <summary>
    /// Mesh vertices
    /// </summary>
    public List<SmodVertex> Vertices { get; set; } = new();

    /// <summary>
    /// Mesh triangular faces
    /// </summary>
    public List<MeshFace> Faces { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        TextureName = binaryReader.ReadString();
        Vertices = binaryReader.ReadList<SmodVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(TextureName);
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
    }
}
