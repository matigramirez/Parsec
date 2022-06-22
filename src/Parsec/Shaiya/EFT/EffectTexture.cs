using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public class EffectTexture : IBinary
{
    public int Index { get; set; }
    public string Name { get; set; }

    [JsonConstructor]
    public EffectTexture()
    {
    }

    public EffectTexture(SBinaryReader binaryReader, int index)
    {
        Index = index;
        Name = binaryReader.ReadString();
    }

    public IEnumerable<byte> GetBytes(params object[] options) => Name.GetLengthPrefixedBytes();
}
