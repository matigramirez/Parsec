using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.DUALLAYERCLOTHES
{
    public class Layer
    {
        public short Upper { get; set; }
        public short Hands { get; set; }
        public short Lower { get; set; }
        public short Feet { get; set; }
        [JsonIgnore]
        public short Face { get; set; }
        public short Head { get; set; }

        public Layer()
        {
        }

        public Layer(ShaiyaBinaryReader binaryReader)
        {
            Upper = binaryReader.Read<short>();
            Hands = binaryReader.Read<short>();
            Lower = binaryReader.Read<short>();
            Feet = binaryReader.Read<short>();
            Face = binaryReader.Read<short>();
            Head = binaryReader.Read<short>();
        }
    }
}
