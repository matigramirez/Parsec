using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class SeqScene
    {
        public int Scene { get; set; }
        public float Delay { get; set; }

        [JsonConstructor]
        public SeqScene()
        {
        }

        public SeqScene(ShaiyaBinaryReader binaryReader)
        {
            Scene = binaryReader.Read<int>();
            Delay = binaryReader.Read<float>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Scene));
            buffer.AddRange(BitConverter.GetBytes(Delay));

            return buffer.ToArray();
        }
    }
}
