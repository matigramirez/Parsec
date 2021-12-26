using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class Sequence : IBinary
    {
        public string Name { get; set; }
        public int SceneCount { get; set; }
        public List<SeqScene> SeqScenes { get; } = new();

        [JsonConstructor]
        public Sequence()
        {
        }

        public Sequence(SBinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            SceneCount = binaryReader.Read<int>();

            for (int i = 0; i < SceneCount; i++)
            {
                var scene = new SeqScene(binaryReader);
                SeqScenes.Add(scene);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Name.Length + 1));
            buffer.AddRange(Encoding.ASCII.GetBytes(Name + '\0'));

            buffer.AddRange(BitConverter.GetBytes(SeqScenes.Count));

            foreach (var scene in SeqScenes)
                buffer.AddRange(scene.GetBytes());

            return buffer.ToArray();
        }
    }
}
