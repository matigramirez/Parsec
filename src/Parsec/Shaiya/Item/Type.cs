using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item;

public sealed class Type : IBinary
{
    [JsonConstructor]
    public Type()
    {
    }

    public Type(int id, int maxTypeId, IEnumerable<IItemDefinition> itemDefinitions)
    {
        Id = id;
        MaxTypeId = maxTypeId;
        ItemDefinitions = itemDefinitions.ToList();
    }

    public Type(SBinaryReader binaryReader, int id, Episode episode, IDictionary<(byte type, byte typeId), IItemDefinition> itemIndex)
    {
        Id = id;
        MaxTypeId = binaryReader.Read<int>();

        for (int i = 0; i < MaxTypeId; i++)
        {
            switch (episode)
            {
                case Episode.EP5:
                default:
                    var itemEp5 = new ItemDefinitionEp5(binaryReader);
                    ItemDefinitions.Add(itemEp5);
                    itemIndex.Add((itemEp5.Type, itemEp5.TypeId), itemEp5);
                    break;
                case Episode.EP6:
                    var itemEp6 = new ItemDefinitionEp6(binaryReader);
                    ItemDefinitions.Add(itemEp6);
                    itemIndex.Add((itemEp6.Type, itemEp6.TypeId), itemEp6);
                    break;
            }
        }
    }

    public int Id { get; set; }
    public int MaxTypeId { get; set; }
    public List<IItemDefinition> ItemDefinitions { get; } = new();

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var format = Episode.EP5;

        if (options.Length > 0)
            format = (Episode)options[0];

        var buffer = new List<byte>();

        buffer.AddRange(MaxTypeId.GetBytes());

        foreach (var itemDefinition in ItemDefinitions)
        {
            // Add item definitions based on format
            switch (format)
            {
                case Episode.EP5:
                default:
                    buffer.AddRange(((ItemDefinitionEp5)itemDefinition).GetBytes());
                    break;
                case Episode.EP6:
                    buffer.AddRange(((ItemDefinitionEp6)itemDefinition).GetBytes());
                    break;
            }
        }

        return buffer;
    }
}
