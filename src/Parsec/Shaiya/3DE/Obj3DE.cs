using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DE
{
    public class Obj3DE : FileBase, IJsonReadable
    {
        public string Texture { get; set; }
        public List<Vertex> Vertices { get; } = new();
        public List<Face> Faces { get; } = new();
        public int MaxKeyframe { get; set; }
        public List<Frame> Frames { get; } = new();
        public override string Extension => "3DE";

        public override void Read(params object[] options)
        {
            Texture = _binaryReader.ReadString();

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

            MaxKeyframe = _binaryReader.Read<int>();

            var frameCount = _binaryReader.Read<int>();

            for (int i = 0; i < frameCount; i++)
            {
                var frame = new Frame(_binaryReader, vertexCount);
                Frames.Add(frame);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode? episode = null)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Texture.GetLengthPrefixedBytes());
            buffer.AddRange(Vertices.GetBytes());
            buffer.AddRange(Faces.GetBytes());
            buffer.AddRange(MaxKeyframe.GetBytes());
            buffer.AddRange(Frames.GetBytes());

            return buffer.ToArray();
        }
    }
}
