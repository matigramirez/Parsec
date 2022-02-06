using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DE
{
    public class Translation : IBinary
    {
        public Vector3 Vector { get; set; }
        public Vector2 UV { get; set; }

        [JsonConstructor]
        public Translation()
        {
        }

        public Translation(SBinaryReader binaryReader)
        {
            Vector = new Vector3(binaryReader);
            UV = new Vector2(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Vector.GetBytes());
            buffer.AddRange(UV.GetBytes());
            return buffer.ToArray();
        }
    }
}
