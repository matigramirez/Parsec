using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SEFF
{
    public class EffectInformation : IBinary
    {
        public int Unknown1 { get; set; }
        public float Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public int Unknown4 { get; set; }
        public int Unknown5 { get; set; }
        public float Unknown6 { get; set; }
        public string Name { get; set; }
        public int[] RGB { get; set; } = new int[6];
        public Vector3 Coordinates { get; set; }
        public int Unknown7 { get; set; }

        [JsonConstructor]
        public EffectInformation()
        {
        }

        public EffectInformation(ShaiyaBinaryReader binaryReader)
        {
            Unknown1 = binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<float>();
            Unknown3 = binaryReader.Read<int>();
            Unknown4 = binaryReader.Read<int>();
            Unknown5 = binaryReader.Read<int>();
            Unknown6 = binaryReader.Read<float>();

            Name = binaryReader.ReadUnicodeString();

            for (int i = 0; i < 6; i++)
            {
                RGB[i] = binaryReader.Read<int>();
            }

            Coordinates = new Vector3(binaryReader);
            Unknown7 = binaryReader.Read<int>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Unknown1));
            buffer.AddRange(BitConverter.GetBytes(Unknown2));
            buffer.AddRange(BitConverter.GetBytes(Unknown3));
            buffer.AddRange(BitConverter.GetBytes(Unknown4));
            buffer.AddRange(BitConverter.GetBytes(Unknown5));
            buffer.AddRange(BitConverter.GetBytes(Unknown6));

            // Name Length + 1 for the string terminator
            buffer.AddRange(BitConverter.GetBytes(Name.Length));
            buffer.AddRange(Encoding.Unicode.GetBytes(Name));

            for (int i = 0; i < 6; i++)
            {
                buffer.AddRange(BitConverter.GetBytes(RGB[i]));
            }

            buffer.AddRange(Coordinates.GetBytes());
            buffer.AddRange(BitConverter.GetBytes(Unknown7));

            return buffer.ToArray();
        }
    }
}
