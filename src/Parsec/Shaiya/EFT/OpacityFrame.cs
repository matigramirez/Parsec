using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class OpacityFrame : IBinary
{
    [JsonConstructor]
    public OpacityFrame()
    {
    }

    public OpacityFrame(SBinaryReader binaryReader)
    {
        Opacity = binaryReader.Read<float>();
        Time = binaryReader.Read<float>();
    }

    public float Opacity { get; set; }
    public float Time { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Opacity.GetBytes());
        buffer.AddRange(Time.GetBytes());
        return buffer;
    }
}
