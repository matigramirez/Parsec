using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3DE;

/// <summary>
/// Class that represents the .3DE file structure.
/// 3DE (3D Effect) files are textured meshes with vertex animations used for effects
/// </summary>
public sealed class _3DE : FileBase
{
    /// <summary>
    /// The mesh .dds texture
    /// </summary>
    public string Texture { get; set; }

    /// <summary>
    /// The mesh vertices
    /// </summary>
    public List<Vertex> Vertices { get; } = new();

    /// <summary>
    /// The mesh triangular faces
    /// </summary>
    public List<Face> Faces { get; } = new();

    /// <summary>
    /// The maximum animation keyframe
    /// </summary>
    public int MaxKeyframe { get; set; }

    /// <summary>
    /// List of animation frames
    /// </summary>
    public List<Frame> Frames { get; } = new();

    public override string Extension => "3DE";

    /// <summary>
    /// Reads the .3DE file from the file buffer. This format requires a manually defined Read method because of its "complexity" when
    /// dealing with the vertex translation frames.
    /// </summary>
    public override void Read(params object[] options)
    {
        Texture = _binaryReader.ReadString();

        int vertexCount = _binaryReader.Read<int>();
        for (int i = 0; i < vertexCount; i++)
            Vertices.Add(new Vertex(_binaryReader));

        int faceCount = _binaryReader.Read<int>();
        for (int i = 0; i < faceCount; i++)
            Faces.Add(new Face(_binaryReader));

        MaxKeyframe = _binaryReader.Read<int>();

        int frameCount = _binaryReader.Read<int>();
        for (int i = 0; i < frameCount; i++)
            Frames.Add(new Frame(_binaryReader, vertexCount));
    }

    /// <summary>
    /// Gets the file buffer. This format requires a manually defined GetBytes method because of its "complexity" when
    /// dealing with the vertex translation frames.
    /// </summary>
    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Texture.GetLengthPrefixedBytes());
        buffer.AddRange(Vertices.GetBytes());
        buffer.AddRange(Faces.GetBytes());
        buffer.AddRange(MaxKeyframe.GetBytes());
        buffer.AddRange(Frames.GetBytes());
        return buffer;
    }
}
