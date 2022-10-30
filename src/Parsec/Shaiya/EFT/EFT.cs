using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT;

public sealed class EFT : FileBase
{
    [JsonIgnore]
    public EFTFormat Format { get; set; }

    public List<EffectObject> Objects { get; } = new();
    public List<EffectTexture> Textures { get; } = new();
    public List<Effect> Effects { get; } = new();
    public List<EffectSequence> EffectSequences { get; } = new();

    [JsonIgnore]
    public override string Extension => "EFT";

    public override void Read(params object[] options)
    {
        string signature = _binaryReader.ReadString(3);

        Format = signature switch
        {
            "EFT" => EFTFormat.EFT,
            "EF2" => EFTFormat.EF2,
            "EF3" => EFTFormat.EF3,
            _ => EFTFormat.Unknown
        };

        int effectObjectCount = _binaryReader.Read<int>();
        for (int i = 0; i < effectObjectCount; i++)
            Objects.Add(new EffectObject(_binaryReader, i));

        int textureCount = _binaryReader.Read<int>();
        for (int i = 0; i < textureCount; i++)
            Textures.Add(new EffectTexture(_binaryReader, i));

        int effectCount = _binaryReader.Read<int>();
        for (int i = 0; i < effectCount; i++)
            Effects.Add(new Effect(_binaryReader, Format, i));

        int sequenceCount = _binaryReader.Read<int>();
        for (int i = 0; i < sequenceCount; i++)
            EffectSequences.Add(new EffectSequence(_binaryReader));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Format.ToString().GetBytes());
        buffer.AddRange(Objects.GetBytes());
        buffer.AddRange(Textures.GetBytes());

        buffer.AddRange(Effects.Count.GetBytes());
        foreach (var effect in Effects)
            buffer.AddRange(effect.GetBytes(Format));

        buffer.AddRange(EffectSequences.GetBytes());
        return buffer;
    }
}
