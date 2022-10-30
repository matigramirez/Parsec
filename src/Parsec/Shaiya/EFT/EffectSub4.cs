using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EffectSub4 : IBinary
{
    [JsonConstructor]
    public EffectSub4()
    {
    }

    public EffectSub4(SBinaryReader binaryReader)
    {
        Unknown = binaryReader.Read<int>();
    }

    public int Unknown { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options) => Unknown.GetBytes();
}
