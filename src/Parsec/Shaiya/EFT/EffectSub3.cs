using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EffectSub3 : IBinary
{
    [JsonConstructor]
    public EffectSub3()
    {
    }

    public EffectSub3(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.Read<float>();
        Unknown2 = binaryReader.Read<float>();
        Time = binaryReader.Read<float>();
    }

    public float Unknown1 { get; set; }
    public float Unknown2 { get; set; }
    public float Time { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        buffer.AddRange(Time.GetBytes());
        return buffer;
    }
}
