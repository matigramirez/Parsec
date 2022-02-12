using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class EffectSequence : IBinary
    {
        public string Name { get; set; }
        public List<SequenceRecord> Records { get; } = new();

        [JsonConstructor]
        public EffectSequence()
        {
        }

        public EffectSequence(SBinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            var repCount = binaryReader.Read<int>();

            for (int i = 0; i < repCount; i++)
            {
                var record = new SequenceRecord(binaryReader);
                Records.Add(record);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Name.GetLengthPrefixedBytes());
            buffer.AddRange(Records.GetBytes());
            return buffer.ToArray();
        }
    }
}
