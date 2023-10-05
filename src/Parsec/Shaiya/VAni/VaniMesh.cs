using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Vani;

/// <summary>
/// Represents a .VANI file (Vertex ANImation)
/// </summary>
public sealed class VaniMesh : ISerializable
{
    /// <summary>
    /// Texture name of the .dds file
    /// </summary>
    public string TextureName { get; set; } = string.Empty;

    /// <summary>
    /// List of the 3d object's faces (polygons - triangles)
    /// </summary>
    public List<MeshFace> Faces { get; set; } = new();

    /// <summary>
    /// List of the 3d object's vertices
    /// </summary>
    public List<VaniVertex> Vertices { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        var frameCount = 0;

        if (binaryReader.SerializationOptions.ExtraOption is int frameCountOption)
        {
            frameCount = frameCountOption;
        }

        TextureName = binaryReader.ReadString();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
        Vertices = binaryReader.ReadList<VaniVertex>().ToList();

        for (var frame = 0; frame < frameCount; frame++)
        {
            foreach (var vertex in Vertices)
            {
                var vertexFrame = binaryReader.Read<VaniVertexFrame>();
                vertex.Frames.Add(vertexFrame);
            }
        }
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var frameCount = 0;

        if (binaryWriter.SerializationOptions.ExtraOption is int frameCountOption)
        {
            frameCount = frameCountOption;
        }

        binaryWriter.Write(TextureName);
        binaryWriter.Write(Faces.ToSerializable());
        binaryWriter.Write(Vertices.ToSerializable());

        for (var frame = 0; frame < frameCount; frame++)
        {
            foreach (var vertex in Vertices)
            {
                binaryWriter.Write(vertex.Frames[frame]);
            }
        }
    }
}
