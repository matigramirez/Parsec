using System.Text;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Item;

public sealed class ItemType : IBinary
{
    public int Id { get; set; }

    public int MaxTypeId { get; set; }

    public List<ItemDefinition> ItemDefinitions { get; } = new();

    [JsonConstructor]
    public ItemType()
    {
    }

    public ItemType(int id, int maxTypeId, IEnumerable<ItemDefinition> itemDefinitions)
    {
        Id = id;
        MaxTypeId = maxTypeId;
        ItemDefinitions = itemDefinitions.ToList();
    }

    public ItemType(SBinaryReader binaryReader, int id, Episode episode, IDictionary<(byte type, byte typeId), ItemDefinition> itemIndex)
    {
        Id = id;
        MaxTypeId = binaryReader.Read<int>();

        for (int i = 0; i < MaxTypeId; i++)
        {
            var itemDefinition = new ItemDefinition(binaryReader, episode);
            ItemDefinitions.Add(itemDefinition);
            itemIndex.Add((itemDefinition.Type, itemDefinition.TypeId), itemDefinition);
        }
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;
        var encoding = Encoding.ASCII;

        if (options.Length > 0 && options[0] is Episode episodeOption)
        {
            episode = episodeOption;
        }

        if (options.Length > 1 && options[1] is Encoding encodingOption)
        {
            encoding = encodingOption;
        }

        var buffer = new List<byte>();
        buffer.AddRange(MaxTypeId.GetBytes());

        foreach (var itemDefinition in ItemDefinitions)
        {
            buffer.AddRange(itemDefinition.GetBytes(episode, encoding));
        }

        return buffer;
    }
}
