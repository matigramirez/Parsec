using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class EffectSub4 : IBinary
    {
        public int Unknown { get; set; }

        [JsonConstructor]
        public EffectSub4()
        {
        }

        public EffectSub4(SBinaryReader binaryReader)
        {
            Unknown = binaryReader.Read<int>();
        }

        public IEnumerable<byte> GetBytes(params object[] options) => Unknown.GetBytes();
    }
}
