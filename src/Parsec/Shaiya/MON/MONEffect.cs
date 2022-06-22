using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MON;

public class MONEffect : IBinary
{
    public int BoneId { get; set; }
    public int EffectId { get; set; }

    [JsonConstructor]
    public MONEffect()
    {
    }

    public MONEffect(SBinaryReader binaryReader)
    {
        BoneId = binaryReader.Read<int>();
        EffectId = binaryReader.Read<int>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(BoneId.GetBytes());
        buffer.AddRange(EffectId.GetBytes());
        return buffer;
    }
}
