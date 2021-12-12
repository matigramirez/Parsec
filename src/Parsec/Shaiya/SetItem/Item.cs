using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem
{
    public class Item : IBinary
    {
        public short Type { get; set; }
        public short TypeId { get; set; }

        [JsonConstructor]
        public Item()
        {
        }

        public Item(ShaiyaBinaryReader binaryReader)
        {
            Type = binaryReader.Read<short>();
            TypeId = binaryReader.Read<short>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Type));
            buffer.AddRange(BitConverter.GetBytes(TypeId));
            return buffer.ToArray();
        }
    }
}
