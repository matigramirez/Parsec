using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3DE;

public sealed class VertexFrame : IBinary
{
    [JsonConstructor]
    public VertexFrame()
    {
    }

    public VertexFrame(SBinaryReader binaryReader)
    {
        Coordinates = new Vector3(binaryReader);
        UV = new Vector2(binaryReader);
    }

    /// <summary>
    /// The vertex coordinates
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// The vertex UV mapping
    /// </summary>
    public Vector2 UV { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Coordinates.GetBytes());
        buffer.AddRange(UV.GetBytes());
        return buffer;
    }
}
