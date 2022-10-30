using System.Globalization;
using CsvHelper;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.Item;

public sealed class Item : SData.SData, ICsv
{
    [JsonIgnore]
    public Dictionary<(byte type, byte typeId), IItemDefinition> ItemIndex = new();

    public int MaxType { get; set; }
    public List<Type> Types { get; } = new();

    /// <inheritdoc />
    public void ExportCsv(string outputPath)
    {
        switch (Episode)
        {
            case Episode.Unknown:
            case Episode.EP4:
            case Episode.EP5:
            default:
                {
                    var items = ItemIndex.Values.ToList().Cast<ItemDefinitionEp5>().ToList();
                    using var writer = new StreamWriter(outputPath);
                    using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    csvWriter.WriteRecords(items);
                    break;
                }
            case Episode.EP6:
            case Episode.EP7:
                {
                    var items = ItemIndex.Values.ToList().Cast<ItemDefinitionEp6>().ToList();
                    using var writer = new StreamWriter(outputPath);
                    using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                    csvWriter.WriteRecords(items);
                    break;
                }
            case Episode.EP8:
                throw new Exception("Episode 8 must use the DBItemData class.");
        }
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
    /// <param name="csvPath">csv file path</param>
    /// <param name="format">The Item.SData format</param>
    /// <returns><see cref="Item"/> instance</returns>
    public static Item ReadFromCsv(string csvPath, Episode format)
    {
        // Create Item.SData instance
        var item = new Item();

        var itemDefinitions = new List<IItemDefinition>();

        // Read all item definitions from csv file
        switch (format)
        {
            case Episode.EP4:
            case Episode.EP5:
            case Episode.Unknown:
            default:
                {
                    // Read item definitions from csv
                    using var reader = new StreamReader(csvPath);
                    using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                    var records = csvReader.GetRecords<ItemDefinitionEp5>().ToList();

                    // Cast item definitions to IItemDefinition since the FileIndex is generic for every format
                    itemDefinitions = records.Cast<IItemDefinition>().ToList();
                    break;
                }
            case Episode.EP6:
            case Episode.EP7:
                {
                    // Read item definitions from csv
                    using var reader = new StreamReader(csvPath);
                    using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                    var records = csvReader.GetRecords<ItemDefinitionEp6>().ToList();

                    // Cast item definitions to IItemDefinition since the FileIndex is generic for every format
                    itemDefinitions = records.Cast<IItemDefinition>().ToList();
                    break;
                }
            case Episode.EP8:
                throw new Exception("Episode 8 must use the DBItemData class.");
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

            int maxTypeId = items.Count == 0 ? 0 : items.Max(x => x.TypeId);

            var type = new Type(i, maxTypeId, items);
            item.Types.Add(type);
        }

        return item;
    }
}
