using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni;

public sealed class VaniVertex : IBinary
{
    public List<VaniVertexFrame> Frames { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        foreach (var frame in Frames)
            buffer.AddRange(frame.GetBytes());
        return buffer;
    }
}
