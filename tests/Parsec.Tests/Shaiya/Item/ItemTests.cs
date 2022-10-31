using Parsec.Common;

namespace Parsec.Tests.Shaiya.Item;

public class ItemTests
{
    [Fact]
    public void ItemEp5CsvTest()
    {
        const string filePath = "Shaiya/Item/ItemEp5.SData";
        const string csvPath = "Shaiya/Item/ItemEp5.SData.csv";

        var item = Reader.ReadFromFile<Parsec.Shaiya.Item.Item>(filePath, Episode.EP5);
        item.ExportCsv(csvPath);
        var itemFromCsv = Parsec.Shaiya.Item.Item.ReadFromCsv(csvPath, Episode.EP5);
        Assert.Equal(item.GetBytes(Episode.EP5), itemFromCsv.GetBytes(Episode.EP5));
    }

    [Fact]
    public void ItemEp6CsvTest()
    {
        const string filePath = "Shaiya/Item/ItemEp6.SData";
        const string csvPath = "Shaiya/Item/ItemEp6.SData.csv";

        var item = Reader.ReadFromFile<Parsec.Shaiya.Item.Item>(filePath, Episode.EP6);
        item.ExportCsv(csvPath);
        var itemFromCsv = Parsec.Shaiya.Item.Item.ReadFromCsv(csvPath, Episode.EP6);
        Assert.Equal(item.GetBytes(Episode.EP6), itemFromCsv.GetBytes(Episode.EP6));
    }
}
