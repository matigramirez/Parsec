using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.OBJ3DC;

namespace Parsec.Shaiya.Common
{
    public class Polygon
    {
        public ushort VertexIndex1 { get; set; }
        public Vertex3DC Vertex1 { get; set; }
        public ushort VertexIndex2 { get; set; }
        public Vertex3DC Vertex2 { get; set; }
        public ushort VertexIndex3 { get; set; }
        public Vertex3DC Vertex3 { get; set; }

        public Polygon(ShaiyaBinaryReader binaryReader)
        {
            VertexIndex1 = binaryReader.Read<ushort>();
            VertexIndex2 = binaryReader.Read<ushort>();
            VertexIndex3 = binaryReader.Read<ushort>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(VertexIndex1));
            buffer.AddRange(BitConverter.GetBytes(VertexIndex2));
            buffer.AddRange(BitConverter.GetBytes(VertexIndex3));
            return buffer.ToArray();
        }
    }
}
