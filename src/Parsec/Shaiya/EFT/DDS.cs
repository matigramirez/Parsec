using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class DDS : IBinary
    {
        public int Index { get; set; }

        [JsonConstructor]
        public DDS()
        {
        }

        public DDS(SBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
        }

        public byte[] GetBytes(params object[] options) => Index.GetBytes();
    }
}
