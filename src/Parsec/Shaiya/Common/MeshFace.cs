using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Class that represents a mesh's triangular face (polygon). All faces in shaiya (3DC, 3DO, SMOD, VAni, etc.) are triangular.
/// </summary>
public sealed class MeshFace : ISerializable
{
    /// <summary>
    /// Index of the first vertex of the mesh
    /// </summary>
    public ushort VertexIndex1 { get; set; }

    /// <summary>
    /// Index of the second vertex of the mesh
    /// </summary>
    public ushort VertexIndex2 { get; set; }

    /// <summary>
    /// Index of the third vertex of the mesh
    /// </summary>
    public ushort VertexIndex3 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        VertexIndex1 = binaryReader.ReadUInt16();
        VertexIndex2 = binaryReader.ReadUInt16();
        VertexIndex3 = binaryReader.ReadUInt16();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(VertexIndex1);
        binaryWriter.Write(VertexIndex2);
        binaryWriter.Write(VertexIndex3);
    }
}
