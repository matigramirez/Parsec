using System.Text.Json.Serialization;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3do;

/// <summary>
/// Class that represents a .3DO which is used for weapons and shields. This format doesn't contain bones, it's just a mesh with a texture.
/// </summary>
public sealed class _3do : FileBase
{
    public string TextureName { get; set; } = string.Empty;

    public List<_3doVertex> Vertices { get; set; } = new();

    public List<MeshFace> Faces { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        TextureName = binaryReader.ReadString();
        Vertices = binaryReader.ReadList<_3doVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(TextureName, includeStringTerminator: false);
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
    }
}
