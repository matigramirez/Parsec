using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni
{
    public class Vertex : IBinary
    {
        public List<VertexFrame> Frames { get; } = new();

        [JsonConstructor]
        public Vertex()
        {
        }

        public Vertex(SBinaryReader binaryReader, int frameCount)
        {
            for (int i = 0; i < frameCount; i++)
            {
                var frame = new VertexFrame(binaryReader);
                Frames.Add(frame);
            }
        }

        public byte[] GetBytes(params object[] options) => Frames.GetBytes();
    }
}
