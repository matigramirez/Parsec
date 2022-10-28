using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

public sealed class Vertex : IBinary
{
    [JsonConstructor]
    public Vertex()
    {
    }

    public Vertex(SBinaryReader binaryReader, int frameCount)
    {
        for (int i = 0; i < frameCount; i++)
        {
            var frame = new VertexFrame(binaryReader);
            Frames.Add(frame);
        }
    }

    public List<VertexFrame> Frames { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        foreach (var frame in Frames)
            buffer.AddRange(frame.GetBytes());
        return buffer;
    }
}
