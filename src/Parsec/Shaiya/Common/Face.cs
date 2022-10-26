using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Class that represents a mesh's triangular face (polygon). All faces in shaiya (3DC, 3DO, SMOD, VAni, etc.) are triangular.
/// </summary>
public sealed class Face : IBinary
{
    [JsonConstructor]
    public Face()
    {
    }

    public Face(SBinaryReader binaryReader)
    {
        VertexIndex1 = binaryReader.Read<ushort>();
        VertexIndex2 = binaryReader.Read<ushort>();
        VertexIndex3 = binaryReader.Read<ushort>();
    }

    /// <summary>
    /// Index of the first vertex of the mesh
    /// </summary>
    [ShaiyaProperty]
    public ushort VertexIndex1 { get; set; }

    /// <summary>
    /// Index of the second vertex of the mesh
    /// </summary>
    [ShaiyaProperty]
    public ushort VertexIndex2 { get; set; }

    /// <summary>
    /// Index of the third vertex of the mesh
    /// </summary>
    [ShaiyaProperty]
    public ushort VertexIndex3 { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(VertexIndex1.GetBytes());
        buffer.AddRange(VertexIndex2.GetBytes());
        buffer.AddRange(VertexIndex3.GetBytes());
        return buffer;
    }
}
