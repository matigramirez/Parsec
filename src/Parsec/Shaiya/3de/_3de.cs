using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3de;

/// <summary>
/// Class that represents the .3DE file structure.
/// 3DE (3D Effect) files are textured meshes with vertex animations used for effects
/// </summary>
public sealed class _3de : FileBase
{
    /// <summary>
    /// The mesh .dds texture
    /// </summary>
    public string Texture { get; set; } = string.Empty;

    /// <summary>
    /// The mesh vertices
    /// </summary>
    public List<_3deVertex> Vertices { get; set; } = new();

    /// <summary>
    /// The mesh triangular faces
    /// </summary>
    public List<MeshFace> Faces { get; set; } = new();

    /// <summary>
    /// The maximum animation keyframe
    /// </summary>
    public int MaxKeyframe { get; set; }

    /// <summary>
    /// List of animation frames
    /// </summary>
    public List<_3deFrame> Frames { get; set; } = new();

    public override string Extension => "3DE";

    /// <summary>
    /// Reads the .3DE file from the file buffer. This format requires a manually defined Read method because of its "complexity" when
    /// dealing with the vertex translation frames.
    /// </summary>
    protected override void Read(SBinaryReader binaryReader)
    {
        Texture = binaryReader.ReadString();
        Vertices = binaryReader.ReadList<_3deVertex>().ToList();
        Faces = binaryReader.ReadList<MeshFace>().ToList();
        MaxKeyframe = binaryReader.ReadInt32();

        // Frame instances expect the vertex count to be set as the ExtraOption on the serialization options
        binaryReader.SerializationOptions.ExtraOption = Vertices.Count;
        Frames = binaryReader.ReadList<_3deFrame>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        // Frame instances expect the vertex count to be set as the ExtraOption on the serialization options
        binaryWriter.SerializationOptions.ExtraOption = Vertices.Count;

        binaryWriter.WriteLengthPrefixedString(Texture);
        binaryWriter.Write(Vertices.ToSerializable());
        binaryWriter.Write(Faces.ToSerializable());
        binaryWriter.Write(MaxKeyframe);
        binaryWriter.Write(Frames.ToSerializable());
    }
}
