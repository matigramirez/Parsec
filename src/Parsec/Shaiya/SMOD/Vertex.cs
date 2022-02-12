using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD
{
    public class Vertex : IBinary
    {
        public Vector3 Coordinates { get; set; }
        public Vector3 Normal { get; set; }

        /// <summary>
        /// SMOD's don't have bones, that's why this value is always -1.
        /// </summary>
        public int BoneId { get; set; } = -1;
        public Vector2 UV { get; set; }

        [JsonConstructor]
        public Vertex()
        {
        }

        public Vertex(SBinaryReader binaryReader)
        {
            Coordinates = new Vector3(binaryReader);
            Normal = new Vector3(binaryReader);
            BoneId = binaryReader.Read<int>();
            UV = new Vector2(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Coordinates.GetBytes());
            buffer.AddRange(Normal.GetBytes());
            buffer.AddRange(BoneId.GetBytes());
            buffer.AddRange(UV.GetBytes());
            return buffer.ToArray();
        }
    }
}
