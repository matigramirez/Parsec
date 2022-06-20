using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class SequenceRecord : IBinary
    {
        public int EffectId { get; set; }
        public float Time { get; set; }

        [JsonConstructor]
        public SequenceRecord()
        {
        }

        public SequenceRecord(SBinaryReader binaryReader)
        {
            EffectId = binaryReader.Read<int>();
            Time = binaryReader.Read<float>();
        }

        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(EffectId.GetBytes());
            buffer.AddRange(Time.GetBytes());
            return buffer;
        }
    }
}
