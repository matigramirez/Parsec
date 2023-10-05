using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3de;

public sealed class _3deFrame : ISerializable
{
    /// <summary>
    /// The frame's key.
    /// </summary>
    public int Keyframe { get; set; }

    /// <summary>
    /// The frame's vertex translations. There's one translation defined for each vertex.
    /// </summary>
    public List<_3deVertexFrame> VertexFrames { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        var vertexCount = 0;

        if (binaryReader.SerializationOptions.ExtraOption is int vertexCountOption)
        {
            vertexCount = vertexCountOption;
        }

        Keyframe = binaryReader.ReadInt32();
        VertexFrames = binaryReader.ReadList<_3deVertexFrame>(vertexCount).ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Keyframe);
        binaryWriter.Write(VertexFrames.ToSerializable(), false);
    }
}
