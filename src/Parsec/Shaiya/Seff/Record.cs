using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.Seff
{
    public class Record
    {
        public int Id { get; set; }
        public List<Effect> Effects { get; } = new();

        [JsonConstructor]
        public Record()
        {
        }

        public Record(SBinaryReader binaryReader, int format)
        {
            Id = binaryReader.Read<int>();

            var effectCount = binaryReader.Read<int>();

            for (int i = 0; i < effectCount; i++)
            {
                var effect = new Effect(binaryReader, format);
                Effects.Add(effect);
            }
        }

        public byte[] GetBytes(int format)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Id));
            buffer.AddRange(BitConverter.GetBytes(Effects.Count));

            foreach (var effectInfo in Effects)
                buffer.AddRange(effectInfo.GetBytes(format));

            return buffer.ToArray();
        }
    }
}
