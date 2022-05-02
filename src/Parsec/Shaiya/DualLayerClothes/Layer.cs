using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DualLayerClothes
{
    public class Layer : IBinary
    {
        public short Upper { get; set; }
        public short Hands { get; set; }
        public short Lower { get; set; }
        public short Feet { get; set; }
        public short Face { get; set; }
        public short Head { get; set; }

        [JsonConstructor]
        public Layer()
        {
        }

        public Layer(SBinaryReader binaryReader)
        {
            Upper = binaryReader.Read<short>();
            Hands = binaryReader.Read<short>();
            Lower = binaryReader.Read<short>();
            Feet = binaryReader.Read<short>();
            Face = binaryReader.Read<short>();
            Head = binaryReader.Read<short>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Upper.GetBytes());
            buffer.AddRange(Hands.GetBytes());
            buffer.AddRange(Lower.GetBytes());
            buffer.AddRange(Feet.GetBytes());
            buffer.AddRange(Face.GetBytes());
            buffer.AddRange(Head.GetBytes());

            return buffer.ToArray();
        }
    }
}
