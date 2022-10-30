using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

public sealed class VertexFrame : IBinary
{
    [JsonConstructor]
    public VertexFrame()
    {
    }

    public VertexFrame(SBinaryReader binaryReader)
    {
        Coordinates = new Vector3(binaryReader);
        Normal = new Vector3(binaryReader);
        BoneId = binaryReader.Read<int>();
        UV = new Vector2(binaryReader);
    }

    /// <summary>
    /// The vertex coordinates in the 3d space
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// The vertex normal
    /// </summary>
    public Vector3 Normal { get; set; }

    /// <summary>
    /// VAni's don't have bones, that's why this value is always -1.
    /// </summary>
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// Texture mapping
    /// </summary>
    public Vector2 UV { get; set; }

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
