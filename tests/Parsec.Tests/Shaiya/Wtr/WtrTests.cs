namespace Parsec.Tests.Shaiya.Wtr;

public class WtrTests
{
    [Theory]
    [InlineData("A2.wtr")]
    [InlineData("B1_new.wtr")]
    [InlineData("B1_Water.wtr")]
    [InlineData("B8.wtr")]
    [InlineData("B8TEST.wtr")]
    [InlineData("World.wtr")]
    public void WtrMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/Wtr/{fileName}";
        string jsonPath = $"Shaiya/Wtr/{fileName}.json";
        string newObjPath = $"Shaiya/Wtr/new_{fileName}";

        var wtr = Reader.ReadFromFile<Parsec.Shaiya.Wtr.Wtr>(filePath);
        wtr.ExportJson(jsonPath);
        var wtrFromJson = Reader.ReadFromJson<Parsec.Shaiya.Wtr.Wtr>(jsonPath);

        // Check bytes
        Assert.Equal(wtr.GetBytes(), wtrFromJson.GetBytes());

        wtrFromJson.Write(newObjPath);
        var newWtr = Reader.ReadFromFile<Parsec.Shaiya.Wtr.Wtr>(newObjPath);

        // Check bytes
        Assert.Equal(wtr.GetBytes(), newWtr.GetBytes());
    }
}
