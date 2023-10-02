using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

/// <summary>
/// Represents a .VANI file (Vertex ANImation)
/// </summary>
public sealed class VAniObject : IBinary
{
    /// <summary>
    /// Texture name of the .dds file
    /// </summary>
    public string TextureName { get; set; } = string.Empty;

    /// <summary>
    /// List of the 3d object's faces (polygons - triangles)
    /// </summary>
    public List<Face> Faces { get; } = new();

    /// <summary>
    /// List of the 3d object's vertices
    /// </summary>
    public List<VaniVertex> Vertices { get; } = new();

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
        {
            var vertex = new VaniVertex();
            Vertices.Add(vertex);
        }

        for (int frame = 0; frame < frameCount; frame++)
        {
            foreach (var vertex in Vertices)
            {
                var vertexFrame = new VaniVertexFrame(binaryReader);
                vertex.Frames.Add(vertexFrame);
            }
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        int frameCount = 0;
        if (options[0] is int frameCountOption)
            frameCount = frameCountOption;

        var buffer = new List<byte>();
        buffer.AddRange(TextureName.GetLengthPrefixedBytes());
        buffer.AddRange(Faces.GetBytes());
        buffer.AddRange(Vertices.Count.GetBytes());

        for (int frame = 0; frame < frameCount; frame++)
        {
            foreach (var vertex in Vertices)
            {
                buffer.AddRange(vertex.Frames[frame].GetBytes());
            }
        }

        return buffer;
    }
}
