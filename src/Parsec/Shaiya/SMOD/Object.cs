using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod
{
    public class Object : IBinary
    {
        public List<Vector3> Vertices { get; } = new();
        public List<Face> Faces { get; } = new();

        [JsonConstructor]
        public Object()
        {
        }

        public Object(ShaiyaBinaryReader binaryReader)
        {
            var vertexCount = binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vector3(binaryReader);
                Vertices.Add(vertex);
            }

            var faceCount = binaryReader.Read<int>();

            for (int i = 0; i < faceCount; i++)
            {
                var face = new Face(binaryReader);
                Faces.Add(face);
            }
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
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
