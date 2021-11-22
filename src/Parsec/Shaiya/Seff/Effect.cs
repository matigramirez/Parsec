using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SEFF
{
    public class Effect : IBinary
    {
        public int Identifier { get; set; }
        public List<EffectInformation> EffectInformationList { get; } = new();

        [JsonConstructor]
        public Effect()
        {
        }

        public Effect(ShaiyaBinaryReader binaryReader)
        {
            Identifier = binaryReader.Read<int>();

            var effectInfoCount = binaryReader.Read<int>();

            for (int i = 0; i < effectInfoCount; i++)
            {
                var effectInfo = new EffectInformation(binaryReader);
                EffectInformationList.Add(effectInfo);
            }
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Identifier));
            buffer.AddRange(BitConverter.GetBytes(EffectInformationList.Count));

            foreach (var effectInfo in EffectInformationList)
            {
                buffer.AddRange(effectInfo.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
