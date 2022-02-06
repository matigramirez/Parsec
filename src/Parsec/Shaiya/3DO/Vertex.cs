using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DO
{
    public class Vertex : IBinary
    {
        public Vector3 Coordinates { get; set; }
        public Vector3 Normal { get; set; }
        public Vector2 UV { get; set; }

        [JsonConstructor]
        public Vertex()
        {
        }

        public Vertex(SBinaryReader binaryReader)
        {
            Coordinates = new Vector3(binaryReader);
            Normal = new Vector3(binaryReader);
            UV = new Vector2(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Coordinates.GetBytes());
            buffer.AddRange(Normal.GetBytes());
            buffer.AddRange(UV.GetBytes());
            return buffer.ToArray();
        }
    }
}
