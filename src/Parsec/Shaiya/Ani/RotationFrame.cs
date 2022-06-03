using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Ani
{
    public class RotationFrame
    {
        [ShaiyaProperty]
        public int Keyframe { get; set; }

        [ShaiyaProperty]
        public Quaternion Quaternion { get; set; }

        [JsonConstructor]
        public RotationFrame()
        {
        }

        public RotationFrame(SBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Quaternion = new Quaternion(binaryReader);
        }
    }
}
