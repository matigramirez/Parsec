using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3DE;

public sealed class Vertex : IBinary
{
    [JsonConstructor]
    public Vertex()
    {
    }

    public Vertex(SBinaryReader binaryReader)
    {
        Coordinates = new Vector3(binaryReader);
        BoneId = binaryReader.Read<int>();
        UV = new Vector2(binaryReader);
    }

    /// <summary>
    /// Vertex coordinates in the 3D space
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// 3DE's don't have vertex groups like 3DC's, that's why this value is always -1.
    /// </summary>
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// UV Texture mapping
    /// </summary>
    public Vector2 UV { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Coordinates.GetBytes());
        buffer.AddRange(BoneId.GetBytes());
        buffer.AddRange(UV.GetBytes());
        return buffer;
    }
}
