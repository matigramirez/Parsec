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
        public List<IItemDefinition> ItemDefinitions { get; } = new();

        [JsonConstructor]
        public Type()
        {
        }

        public Type(int maxTypeId, IEnumerable<IItemDefinition> itemDefinitions)
        {
            MaxTypeId = maxTypeId;
            ItemDefinitions = itemDefinitions.ToList();
        }

        public Type(
            SBinaryReader binaryReader,
            ItemFormat format,
            IDictionary<(byte type, byte typeId), IItemDefinition> itemIndex
        )
        {
            MaxTypeId = binaryReader.Read<int>();

            for (int i = 0; i < MaxTypeId; i++)
            {
                switch (format)
                {
                    case ItemFormat.EP5:
                    default:
                        var itemEp5 = new ItemDefinitionEp5(binaryReader);
                        ItemDefinitions.Add(itemEp5);
                        itemIndex.Add((itemEp5.Type, itemEp5.TypeId), itemEp5);
                        break;
                    case ItemFormat.EP6:
                        var itemEp6 = new ItemDefinitionEp6(binaryReader);
                        ItemDefinitions.Add(itemEp6);
                        itemIndex.Add((itemEp6.Type, itemEp6.TypeId), itemEp6);
                        break;
                }
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var format = ItemFormat.EP5;

            if (options.Length > 0)
                format = (ItemFormat)options[0];

            var buffer = new List<byte>();

            buffer.AddRange(MaxTypeId.GetBytes());

            foreach (var itemDefinition in ItemDefinitions)
            {
                // Add item definitions based on format
                switch (format)
                {
                    case ItemFormat.EP5:
                    default:
                        buffer.AddRange(((ItemDefinitionEp5)itemDefinition).GetBytes());
                        break;
                    case ItemFormat.EP6:
                        buffer.AddRange(((ItemDefinitionEp6)itemDefinition).GetBytes());
                        break;
                }
            }

            return buffer.ToArray();
        }
    }
}
