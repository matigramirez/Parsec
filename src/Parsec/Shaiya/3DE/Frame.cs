using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DE
{
    public class Frame : IBinary
    {
        public int Keyframe { get; set; }
        // one translation per vertex
        public List<Translation> Translations { get; } = new();

        [JsonConstructor]
        public Frame()
        {
        }

        public Frame(SBinaryReader binaryReader, int vertexCount)
        {
            Keyframe = binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var translation = new Translation(binaryReader);
                Translations.Add(translation);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Keyframe.GetBytes());
            buffer.AddRange(Translations.GetBytes(false));
            return buffer.ToArray();
        }
    }
}
