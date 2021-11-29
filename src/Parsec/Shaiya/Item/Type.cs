using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item
{
    public class Type : IBinary
    {
        public int MaxTypeId { get; set; }
        public List<ItemDefinition> ItemDefinitions { get; } = new();

        public Type(ShaiyaBinaryReader binaryReader)
        {
            MaxTypeId = binaryReader.Read<int>();

            for (int i = 0; i < MaxTypeId; i++)
            {
                var definition = new ItemDefinition(binaryReader);
                ItemDefinitions.Add(definition);
            }
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(MaxTypeId));

            foreach (var definition in ItemDefinitions)
            {
                buffer.AddRange(definition.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
