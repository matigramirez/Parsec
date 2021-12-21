using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DO
{
    public class Obj3DO : FileBase, IJsonReadable
    {
        public string TextureName { get; set; }
        public List<Vertex> Vertices { get; } = new();
        public List<Face> Faces { get; } = new();

        [JsonIgnore]
        public override string Extension => "3DO";

        public override void Read(params object[] options)
        {
            TextureName = _binaryReader.ReadString();

            var vertexCount = _binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex(_binaryReader);
                Vertices.Add(vertex);
            }

            var faceCount = _binaryReader.Read<int>();

            for (int i = 0; i < faceCount; i++)
            {
                var face = new Face(_binaryReader);
                Faces.Add(face);
            }
        }

        public override byte[] GetBytes(params object[] options)
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
