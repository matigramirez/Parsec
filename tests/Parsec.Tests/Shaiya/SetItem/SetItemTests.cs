using System.Linq;
using Parsec.Shaiya.SetItem;

namespace Parsec.Tests.Shaiya.SetItem;

public class SetItemTests
{
    [Fact]
    public void SetItemReadWriteTest()
    {
        const string filePath = "Shaiya/SetItem/SetItem.SData";
        const string outputPath = "Shaiya/SetItem/output_SetItem.SData";
        const string jsonPath = "Shaiya/SetItem/SetItem.SData.json";
        const string newFilePath = "Shaiya/SetItem/new_SetItem.SData";

        Parsec.Shaiya.SData.SData.DecryptFile(filePath, filePath);
        var setItem = ParsecReader.FromFile<Parsec.Shaiya.SetItem.SetItem>(filePath);
        setItem.Write(outputPath);
        setItem.WriteJson(jsonPath);

        var outputSetItem = ParsecReader.FromFile<Parsec.Shaiya.SetItem.SetItem>(outputPath);
        var setItemFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.SetItem.SetItem>(jsonPath);

        // Check bytes
        Assert.Equal(setItem.GetBytes(), outputSetItem.GetBytes());
        Assert.Equal(setItem.GetBytes(), setItemFromJson.GetBytes());

        setItemFromJson.Write(newFilePath);
        var newSeff = ParsecReader.FromFile<Parsec.Shaiya.SetItem.SetItem>(newFilePath);

        // Check bytes
        Assert.Equal(setItem.GetBytes(), newSeff.GetBytes());
    }

    [Fact]
    public void DbSetItemTest()
    {
        const string filePath = "Shaiya/SetItem/DBSetItemData.SData";
        const string outputPath = "Shaiya/SetItem/output_DBSetItemData.SData";
        const string jsonPath = "Shaiya/SetItem/DBSetItemData.SData.json";
        const string csvPath = "Shaiya/SetItem/DBSetItemData.SData.csv";

        var dbSetItem = ParsecReader.FromFile<DBSetItemData>(filePath);
        dbSetItem.Write(outputPath);
        dbSetItem.WriteJson(jsonPath);
        dbSetItem.WriteCsv(csvPath);

        var outputDbSetItem = ParsecReader.FromFile<DBSetItemData>(outputPath);
        var jsonDbSetItem = ParsecReader.FromJsonFile<DBSetItemData>(jsonPath);
        var csvSetItem = DBSetItemData.FromCsv<DBSetItemData>(csvPath);

        var expected = dbSetItem.GetBytes().ToList();
        Assert.Equal(expected, outputDbSetItem.GetBytes());
        Assert.Equal(expected, jsonDbSetItem.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvSetItem.GetBytes().Skip(128));
    }

    [Fact]
    public void DbSetItemTextTest()
    {
        const string filePath = "Shaiya/SetItem/DBSetItemText_USA.SData";
        const string outputPath = "Shaiya/SetItem/output_DBSetItemText_USA.SData";
        const string jsonPath = "Shaiya/SetItem/DBSetItemText_USA.SData.json";
        const string csvPath = "Shaiya/SetItem/DBSetItemText_USA.SData.csv";

        var setItemText = ParsecReader.FromFile<DBSetItemText>(filePath);
        setItemText.Write(outputPath);
        setItemText.WriteJson(jsonPath);
        setItemText.WriteCsv(csvPath);

        var outputSetItemText = ParsecReader.FromFile<DBSetItemText>(outputPath);
        var jsonSetItemText = ParsecReader.FromJsonFile<DBSetItemText>(jsonPath);
        var csvSetItemText = DBSetItemText.FromCsv<DBSetItemText>(csvPath);

        var expected = setItemText.GetBytes().ToList();
        Assert.Equal(expected, outputSetItemText.GetBytes());
        Assert.Equal(expected, jsonSetItemText.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvSetItemText.GetBytes().Skip(128));
    }
}
