using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class EFT : FileBase, IJsonReadable
    {
        public string Signature { get; set; }

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
            Signature = _binaryReader.ReadString(3);

            Format = Signature switch
            {
                "EFT" => EFTFormat.EFT,
                "EF2" => EFTFormat.EF2,
                "EF3" => EFTFormat.EF3,
                _     => EFTFormat.Unknown
            };

            var effectObjectCount = _binaryReader.Read<int>();

            for (int i = 0; i < effectObjectCount; i++)
            {
                var effectObject = new EffectObject(_binaryReader, i);
                Objects.Add(effectObject);
            }

            var textureCount = _binaryReader.Read<int>();

            for (int i = 0; i < textureCount; i++)
            {
                var texture = new EffectTexture(_binaryReader, i);
                Textures.Add(texture);
            }

            var effectCount = _binaryReader.Read<int>();

            for (int i = 0; i < effectCount; i++)
            {
                var effect = new Effect(_binaryReader, Format, i);
                Effects.Add(effect);
            }

            var sequenceCount = _binaryReader.Read<int>();

            for (int i = 0; i < sequenceCount; i++)
            {
                var sequence = new EffectSequence(_binaryReader);
                EffectSequences.Add(sequence);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Signature.GetBytes());

            buffer.AddRange(Objects.GetBytes());
            buffer.AddRange(Textures.GetBytes());

            Format = Signature switch
            {
                "EFT" => EFTFormat.EFT,
                "EF2" => EFTFormat.EF2,
                "EF3" => EFTFormat.EF3,
                _     => EFTFormat.Unknown
            };

            buffer.AddRange(Effects.Count.GetBytes());

            foreach (var effect in Effects)
                buffer.AddRange(effect.GetBytes(Format));

            buffer.AddRange(EffectSequences.GetBytes());
            return buffer.ToArray();
        }
    }
}
