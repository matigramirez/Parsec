using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class Rotation : IBinary
    {
        public Quaternion Quaternion { get; set; }
        public float Time { get; set; }

        [JsonConstructor]
        public Rotation()
        {
        }

        public Rotation(SBinaryReader binaryReader)
        {
            Quaternion = new Quaternion(binaryReader);
            Time = binaryReader.Read<float>();
        }

        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Quaternion.GetBytes());
            buffer.AddRange(Time.GetBytes());
            return buffer;
        }
    }
}
