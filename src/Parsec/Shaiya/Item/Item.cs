﻿using System.Globalization;
using System.Text;
using CsvHelper;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.Item;

public sealed class Item : SData.SData, ICsv
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

    /// <summary>
    /// Reads the Item.SData format from a csv file
    /// </summary>
    /// <param name="csvPath">csv file path</param>
    /// <param name="episode">The Item.SData format</param>
    /// <param name="encoding">Item.SData encoding</param>
    /// <returns><see cref="Item"/> instance</returns>
    public static Item FromCsv(string csvPath, Episode episode, Encoding? encoding = null)
    {
        if (episode >= Episode.EP8)
        {
            throw new Exception("Item format is not supported for EP8 and above, use ItemData instead.");
        }

        encoding ??= Encoding.ASCII;

        // Read item definitions from csv
        using var reader = new StreamReader(csvPath, encoding);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var csvItemRecords = csvReader.GetRecords<ItemDefinition>().ToList();

        var groups = csvItemRecords.GroupBy(x => x.ItemType).ToList();
        var item = new Item { Episode = episode, Encoding = encoding };

        var maxGroupId = groups.Max(x => x.Key);

        for (var i = 1; i <= maxGroupId; i++)
        {
            var itemGroup = new ItemGroup();
            item.ItemGroups.Add(itemGroup);

            var group = groups.FirstOrDefault(x => x.Key == i);

            if (group != null)
            {
                itemGroup.ItemDefinitions = group.ToList();
            }
        }

        return item;
    }

    public void WriteCsv(string outputPath, Encoding? encoding = null)
    {
        encoding ??= Encoding;
        using var writer = new StreamWriter(outputPath, false, encoding);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        foreach (var itemGroup in ItemGroups)
        {
            csvWriter.WriteRecords(itemGroup.ItemDefinitions);
        }
    }
}
