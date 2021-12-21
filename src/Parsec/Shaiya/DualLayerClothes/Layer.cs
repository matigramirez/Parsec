using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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

        public Layer(ShaiyaBinaryReader binaryReader)
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

            buffer.AddRange(BitConverter.GetBytes(Upper));
            buffer.AddRange(BitConverter.GetBytes(Hands));
            buffer.AddRange(BitConverter.GetBytes(Lower));
            buffer.AddRange(BitConverter.GetBytes(Feet));
            buffer.AddRange(BitConverter.GetBytes(Face));
            buffer.AddRange(BitConverter.GetBytes(Head));

            return buffer.ToArray();
        }
    }
}
