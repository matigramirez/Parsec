using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class DDS
    {
        public int Index { get; set; }

        [JsonConstructor]
        public DDS()
        {
        }

        public DDS(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Index));

            return buffer.ToArray();
        }
    }
}
