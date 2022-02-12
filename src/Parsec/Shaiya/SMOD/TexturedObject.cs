using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD
{
    public class TexturedObject : IBinary
    {
        /// <summary>
        /// Name of the .tga texture file
        /// </summary>
        public string TextureName { get; set; }
        public List<Vertex> Vertices { get; } = new();
        public List<Face> Faces { get; } = new();

        [JsonConstructor]
        public TexturedObject()
        {
        }

        public TexturedObject(SBinaryReader binaryReader)
        {
            TextureName = binaryReader.ReadString();

            var vertexCount = binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex(binaryReader);
                Vertices.Add(vertex);
            }

            var faceCount = binaryReader.Read<int>();

            for (int i = 0; i < faceCount; i++)
            {
                var face = new Face(binaryReader);
                Faces.Add(face);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(TextureName.GetLengthPrefixedBytes());
            buffer.AddRange(Vertices.GetBytes());
            buffer.AddRange(Faces.GetBytes());
            return buffer.ToArray();
        }
    }
}
