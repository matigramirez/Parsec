using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using ServiceStack;

namespace Parsec.Shaiya.Item;

public sealed class Item : SData.SData, IJsonReadable, ICsv
{
    [JsonIgnore]
    public Dictionary<(byte type, byte typeId), IItemDefinition> ItemIndex = new();

    public int MaxType { get; set; }
    public List<Type> Types { get; } = new();

    /// <inheritdoc />
    public void ExportCSV(string path)
    {
        string csv;

        switch (Episode)
        {
            case Episode.EP5:
            default:
                csv = ItemIndex.Values.ToList().ConvertTo<List<ItemDefinitionEp5>>().ToCsv();
                break;
            case Episode.EP6:
                csv = ItemIndex.Values.ToList().ConvertTo<List<ItemDefinitionEp6>>().ToCsv();
                break;
        }

        FileHelper.WriteFile(path, csv.GetBytes());
    }

    public override void Read(params object[] options)
    {
        Episode = Episode.EP5;

        if (options.Length > 0)
            Episode = (Episode)options[0];

        MaxType = _binaryReader.Read<int>();

        for (int i = 0; i < MaxType; i++)
        {
            var type = new Type(_binaryReader, i + 1, Episode, ItemIndex);
            Types.Add(type);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();

        buffer.AddRange(MaxType.GetBytes());

        for (int i = 1; i <= MaxType; i++)
        {
            var type = Types.SingleOrDefault(t => t.Id == i);

            // When type isn't part of the item, its MaxTypeId = 0 must be written to the file anyways
            if (type == null)
            {
                buffer.AddRange(0.GetBytes());
                continue;
            }

            buffer.AddRange(type.GetBytes(episode));
        }

        return buffer;
    }

    /// <summary>
    /// Reads the Item.SData format from a csv file
    /// </summary>
    /// <param name="path">csv file path</param>
    /// <param name="format">The Item.SData format</param>
    /// <returns><see cref="Item"/> instance</returns>
    public static Item ReadFromCSV(string path, Episode format)
    {
        // Create Item.SData instance
        var item = new Item();

        var itemDefinitions = new List<IItemDefinition>();

        // Read all item definitions from csv file
        switch (format)
        {
            case Episode.EP5:
            default:
                {
                    // Read item definitions from csv
                    var itemEp5Definitions = File.ReadAllText(path).FromCsv<List<ItemDefinitionEp5>>();

                    // Cast item definitions to IItemDefinition since the FileIndex is generic for every format
                    itemDefinitions = itemEp5Definitions.Cast<IItemDefinition>().ToList();
                    break;
                }
            case Episode.EP6:
                {
                    // Read item definitions from csv
                    var itemEp6Definitions = File.ReadAllText(path).FromCsv<List<ItemDefinitionEp6>>();

                    // Cast item definitions to IItemDefinition since the FileIndex is generic for every format
                    itemDefinitions = itemEp6Definitions.Cast<IItemDefinition>().ToList();
                    break;
                }
        }

        // Get max type from items
        item.MaxType = itemDefinitions.Max(x => x.Type);

        // Add all items to item index
        var itemIndex = itemDefinitions.ToDictionary(itemDef => (itemDef.Type, itemDef.TypeId));
        item.ItemIndex = itemIndex;

        // Create item types
        for (int i = 1; i <= item.MaxType; i++)
        {
            // Get items for this type
            var items = item.ItemIndex.Values.Where(x => x.Type == i).ToList();

            var maxTypeId = items.Count == 0 ? 0 : items.Max(x => x.TypeId);

            var type = new Type(i, maxTypeId, items);
            item.Types.Add(type);
        }

        return item;
    }
}
