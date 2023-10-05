using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.Item;

public sealed class Item : SData.SData
{
    public List<ItemGroup> ItemGroups { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        ItemGroups = binaryReader.ReadList<ItemGroup>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ItemGroups.ToSerializable());
    }

    // TODO: Add csv support
    // /// <summary>
    // /// Reads the Item.SData format from a csv file
    // /// </summary>
    // /// <param name="csvPath">csv file path</param>
    // /// <param name="episode">The Item.SData format</param>
    // /// <param name="encoding">Item.SData encoding</param>
    // /// <returns><see cref="Item"/> instance</returns>
    // public static Item ReadFromCsv(string csvPath, Episode episode, Encoding? encoding = null)
    // {
    //     encoding ??= Encoding.ASCII;
    //
    //     // Create Item.SData instance
    //     var item = new Item { Episode = episode, Encoding = encoding };
    //
    //     // Read item definitions from csv
    //     using var reader = new StreamReader(csvPath, encoding);
    //     using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
    //     var itemDefinitions = csvReader.GetRecords<ItemDefinition>().ToList();
    //
    //     // Get max type from items
    //     item.MaxItemType = itemDefinitions.Max(x => x.Type);
    //
    //     // Add all items to item index
    //     var itemIndex = itemDefinitions.ToDictionary(itemDef => (itemDef.Type, itemDef.TypeId));
    //     item.ItemIndex = itemIndex;
    //
    //     // Create item types
    //     for (int i = 1; i <= item.MaxItemType; i++)
    //     {
    //         // Get items for this type
    //         var items = item.ItemIndex.Values.Where(x => x.Type == i).ToList();
    //
    //         int maxTypeId = items.Count == 0 ? 0 : items.Max(x => x.TypeId);
    //
    //         var type = new ItemType(i, maxTypeId, items);
    //         item.ItemTypes.Add(type);
    //     }
    //
    //     return item;
    // }
    //
    // /// <inheritdoc />
    // public void WriteCsv(string outputPath, Encoding? encoding = null)
    // {
    //     encoding ??= Encoding;
    //
    //     var items = ItemIndex.Values.ToList().ToList();
    //     using var writer = new StreamWriter(outputPath, false, encoding);
    //     using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
    //     csvWriter.WriteRecords(items);
    // }
}
