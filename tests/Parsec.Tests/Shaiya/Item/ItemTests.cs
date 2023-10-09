using System.Linq;
using Parsec.Common;
using Parsec.Shaiya.Item;

namespace Parsec.Tests.Shaiya.Item;

public class ItemTests
{
    [Fact]
    public void ItemEp5CsvTest()
    {
        const string filePath = "Shaiya/Item/ItemEp5.SData";
        const string csvPath = "Shaiya/Item/ItemEp5.SData.csv";

        var item = ParsecReader.FromFile<Parsec.Shaiya.Item.Item>(filePath);
        item.WriteCsv(csvPath);
        var itemFromCsv = Parsec.Shaiya.Item.Item.FromCsv(csvPath, Episode.EP5);

        Assert.Equal(item.GetBytes(), itemFromCsv.GetBytes());
    }

    [Fact]
    public void ItemEp6CsvTest()
    {
        const string filePath = "Shaiya/Item/ItemEp6.SData";
        const string csvPath = "Shaiya/Item/ItemEp6.SData.csv";

        var item = ParsecReader.FromFile<Parsec.Shaiya.Item.Item>(filePath, Episode.EP6);
        item.WriteCsv(csvPath);
        var itemFromCsv = Parsec.Shaiya.Item.Item.FromCsv(csvPath, Episode.EP6);
        Assert.Equal(item.GetBytes(Episode.EP6), itemFromCsv.GetBytes(Episode.EP6));
    }

    [Fact]
    public void ItemEp6Csv_EncodingTest()
    {
        const string filePath = "Shaiya/Item/ItemEp6_1251.SData";
        const string csvPath = "Shaiya/Item/ItemEp6_1252.SData.csv";

        var encoding = TestEncodings.Encoding1251;
        var item = ParsecReader.FromFile<Parsec.Shaiya.Item.Item>(filePath, Episode.EP6, encoding);
        item.WriteCsv(csvPath, encoding);
        var itemFromCsv = Parsec.Shaiya.Item.Item.FromCsv(csvPath, Episode.EP6, encoding);
        Assert.Equal(item.GetBytes(Episode.EP6), itemFromCsv.GetBytes(Episode.EP6));
    }

    [Fact]
    public void DbItemTest()
    {
        const string filePath = "Shaiya/Item/DBItemData.SData";
        const string outputPath = "Shaiya/Item/output_DBItemData.SData";
        const string jsonPath = "Shaiya/Item/DBItemData.SData.json";
        const string csvPath = "Shaiya/Item/DBItemData.SData.csv";

        var dbItem = ParsecReader.FromFile<DBItemData>(filePath);
        dbItem.Write(outputPath);
        dbItem.WriteJson(jsonPath);
        dbItem.WriteCsv(csvPath);

        var outputDbItem = ParsecReader.FromFile<DBItemData>(outputPath);
        var jsonDbItem = ParsecReader.FromJsonFile<DBItemData>(jsonPath);
        var csvItem = DBItemData.FromCsv<DBItemData>(csvPath);

        var expected = dbItem.GetBytes().ToList();
        Assert.Equal(expected, outputDbItem.GetBytes());
        Assert.Equal(expected, jsonDbItem.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvItem.GetBytes().Skip(128));
    }

    [Fact]
    public void DbItemTextTest()
    {
        const string filePath = "Shaiya/Item/DBItemText_USA.SData";
        const string outputPath = "Shaiya/Item/output_DBItemText_USA.SData";
        const string jsonPath = "Shaiya/Item/DBItemText_USA.SData.json";
        const string csvPath = "Shaiya/Item/DBItemText_USA.SData.csv";

        var itemText = ParsecReader.FromFile<DBItemText>(filePath);
        itemText.Write(outputPath);
        itemText.WriteJson(jsonPath);
        itemText.WriteCsv(csvPath);

        var outputItemText = ParsecReader.FromFile<DBItemText>(outputPath);
        var jsonItemText = ParsecReader.FromJsonFile<DBItemText>(jsonPath);
        var csvItemText = DBItemText.FromCsv<DBItemText>(csvPath);

        var expected = itemText.GetBytes().ToList();
        Assert.Equal(expected, outputItemText.GetBytes());
        Assert.Equal(expected, jsonItemText.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvItemText.GetBytes().Skip(128));
    }
}
