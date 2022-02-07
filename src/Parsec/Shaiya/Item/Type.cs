using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item
{
    public class Type : IBinary
    {
        public int MaxTypeId { get; set; }
        public List<ItemDefinition> ItemDefinitions { get; } = new();

        [JsonConstructor]
        public Type()
        {
        }

        public Type(int maxTypeId, IEnumerable<ItemDefinition> itemDefinitions)
        {
            MaxTypeId = maxTypeId;
            ItemDefinitions = itemDefinitions.ToList();
        }

        public Type(SBinaryReader binaryReader, IDictionary<(byte type, byte typeId), ItemDefinition> itemIndex)
        {
            MaxTypeId = binaryReader.Read<int>();

            for (int i = 0; i < MaxTypeId; i++)
            {
                var item = new ItemDefinition(binaryReader);
                ItemDefinitions.Add(item);
                itemIndex.Add((item.Type, item.TypeId), item);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(MaxTypeId.GetBytes());

            foreach (var definition in ItemDefinitions)
            {
                buffer.AddRange(definition.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
