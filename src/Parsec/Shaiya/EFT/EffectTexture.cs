using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EffectTexture : IBinary
{
    [JsonConstructor]
    public EffectTexture()
    {
    }

    public EffectTexture(SBinaryReader binaryReader)
    {
        TextureId = binaryReader.Read<int>();
    }

    public int TextureId { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options) => TextureId.GetBytes();
}
