using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod
{
    public class TexturedObject : IBinary
    {
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

            buffer.AddRange(BitConverter.GetBytes(TextureName.Length + 1));
            buffer.AddRange(Encoding.ASCII.GetBytes(TextureName + '\0'));

            buffer.AddRange(BitConverter.GetBytes(Vertices.Count));

            foreach (var vertex in Vertices)
                buffer.AddRange(vertex.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Faces.Count));

            foreach (var face in Faces)
                buffer.AddRange(face.GetBytes());

            return buffer.ToArray();
        }
    }
}
