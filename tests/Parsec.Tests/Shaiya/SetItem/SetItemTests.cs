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
        var setItem = ParsecReader.ReadFromFile<Parsec.Shaiya.SetItem.SetItem>(filePath);
        setItem.Write(outputPath);
        setItem.WriteJson(jsonPath);

        var outputSetItem = ParsecReader.ReadFromFile<Parsec.Shaiya.SetItem.SetItem>(outputPath);
        var setItemFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.SetItem.SetItem>(jsonPath);

        // Check bytes
        Assert.Equal(setItem.GetBytes(), outputSetItem.GetBytes());
        Assert.Equal(setItem.GetBytes(), setItemFromJson.GetBytes());

        setItemFromJson.Write(newFilePath);
        var newSeff = ParsecReader.ReadFromFile<Parsec.Shaiya.SetItem.SetItem>(newFilePath);

        // Check bytes
        Assert.Equal(setItem.GetBytes(), newSeff.GetBytes());
    }
}
