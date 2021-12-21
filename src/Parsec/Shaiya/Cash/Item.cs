using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cash
{
    public class Item : IBinary
    {
        public int ItemId { get; set; }
        public byte Count { get; set; }

        [JsonConstructor]
        public Item()
        {
        }

        public Item(ShaiyaBinaryReader binaryReader)
        {
            ItemId = binaryReader.Read<int>();
            Count = binaryReader.Read<byte>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(ItemId));
            buffer.Add(Count);
            return buffer.ToArray();
        }
    }
}
