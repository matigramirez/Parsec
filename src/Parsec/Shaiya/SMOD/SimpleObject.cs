using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SMOD
{
    public class SimpleObject : IBinary
    {
        public List<SimpleVertex> Vertices { get; } = new();
        public List<Face> Faces { get; } = new();

        [JsonConstructor]
        public SimpleObject()
        {
        }

        public SimpleObject(SBinaryReader binaryReader)
        {
            var vertexCount = binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new SimpleVertex(binaryReader);
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
            buffer.AddRange(Vertices.GetBytes());
            buffer.AddRange(Faces.GetBytes());
            return buffer.ToArray();
        }
    }
}
