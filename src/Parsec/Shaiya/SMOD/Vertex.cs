using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// Represents a vertex used in an SMOD mesh
/// </summary>
public sealed class Vertex : IBinary
{
    /// <summary>
    /// Vertex coordinates in the 3D space
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// Vertex normal used for lighting
    /// </summary>
    public Vector3 Normal { get; set; }

    /// <summary>
    /// SMODs don't have bones, that's why this value is always -1.
    /// </summary>
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// Texture mapping
    /// </summary>
    public Vector2 UV { get; set; }

    [JsonConstructor]
    public Vertex()
    {
    }

    public Vertex(SBinaryReader binaryReader)
    {
        Coordinates = new Vector3(binaryReader);
        Normal = new Vector3(binaryReader);
        BoneId = binaryReader.Read<int>();
        UV = new Vector2(binaryReader);
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Coordinates.GetBytes());
        buffer.AddRange(Normal.GetBytes());
        buffer.AddRange(BoneId.GetBytes());
        buffer.AddRange(UV.GetBytes());
        return buffer;
    }
}
