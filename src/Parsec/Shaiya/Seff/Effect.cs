using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.Seff
{
    public class Effect
    {
        public int Identifier { get; set; }
        public List<EffectInformation> EffectInformationList { get; } = new();

        [JsonConstructor]
        public Effect()
        {
        }

        public Effect(ShaiyaBinaryReader binaryReader, int format)
        {
            Identifier = binaryReader.Read<int>();

            var effectInfoCount = binaryReader.Read<int>();

            for (int i = 0; i < effectInfoCount; i++)
            {
                var effectInfo = new EffectInformation(binaryReader, format);
                EffectInformationList.Add(effectInfo);
            }
        }

        public byte[] GetBytes(int format)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Identifier));
            buffer.AddRange(BitConverter.GetBytes(EffectInformationList.Count));

            foreach (var effectInfo in EffectInformationList)
                buffer.AddRange(effectInfo.GetBytes(format));

            return buffer.ToArray();
        }
    }
}
