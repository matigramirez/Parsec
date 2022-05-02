using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DualLayerClothes
{
    public class Costume : IBinary
    {
        public short Index { get; set; }

        public List<Layer> Layers { get; } = new();

        [JsonConstructor]
        public Costume()
        {
        }

        public Costume(SBinaryReader binaryReader)
        {
            Index = binaryReader.Read<short>();

            var layer = new Layer(binaryReader);
            Layers.Add(layer);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Index.GetBytes());

            foreach (var layer in Layers)
                buffer.AddRange(layer.GetBytes());

            return buffer.ToArray();
        }
    }
}
