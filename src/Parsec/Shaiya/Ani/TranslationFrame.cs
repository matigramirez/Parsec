using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Ani
{
    public class TranslationFrame
    {
        [ShaiyaProperty]
        public int Keyframe { get; set; }

        [ShaiyaProperty]
        public Vector3 Vector { get; set; }

        [JsonConstructor]
        public TranslationFrame()
        {
        }

        public TranslationFrame(SBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Vector = new Vector3(binaryReader);
        }
    }
}
