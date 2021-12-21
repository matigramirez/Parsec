using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DC
{
    /// <summary>
    /// Class that represents a Face (Polygon) used in 3DC files to form the mesh. It's composed by 3 vertices only, so polygons can only be triangles.
    /// </summary>
    public class Face : IBinary
    {
        /// <summary>
        /// The index of the first vertex
        /// </summary>
        public ushort VertexIndex1 { get; set; }

        /// <summary>
        /// The <see cref="Vertex"/> instance of the first vertex
        /// </summary>
        public Vertex Vertex1 { get; set; }

        /// <summary>
        /// The index of the second vertex
        /// </summary>
        public ushort VertexIndex2 { get; set; }

        /// <summary>
        /// The <see cref="Vertex"/> instance of the second vertex
        /// </summary>
        public Vertex Vertex2 { get; set; }

        /// <summary>
        /// The index of the third vertex
        /// </summary>
        public ushort VertexIndex3 { get; set; }

        /// <summary>
        /// The <see cref="Vertex"/> instance of the third vertex
        /// </summary>
        public Vertex Vertex3 { get; set; }

        public Face(ShaiyaBinaryReader binaryReader)
        {
            VertexIndex1 = binaryReader.Read<ushort>();
            VertexIndex2 = binaryReader.Read<ushort>();
            VertexIndex3 = binaryReader.Read<ushort>();
        }

        [JsonConstructor]
        public Face()
        {
        }

        /// <inheritdoc />
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
