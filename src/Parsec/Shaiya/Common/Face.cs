using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common
{
    public class Face : IBinary
    {
        public ushort VertexIndex1 { get; set; }
        public ushort VertexIndex2 { get; set; }
        public ushort VertexIndex3 { get; set; }

        [JsonConstructor]
        public Face()
        {
        }

        public Face(ShaiyaBinaryReader binaryReader)
        {
            VertexIndex1 = binaryReader.Read<ushort>();
            VertexIndex2 = binaryReader.Read<ushort>();
            VertexIndex3 = binaryReader.Read<ushort>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(VertexIndex1));
            buffer.AddRange(BitConverter.GetBytes(VertexIndex2));
            buffer.AddRange(BitConverter.GetBytes(VertexIndex3));
            return buffer.ToArray();
        }
    }
}
