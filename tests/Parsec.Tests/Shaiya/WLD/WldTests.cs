namespace Parsec.Tests.Shaiya.WLD;

public class WldTests
{
    [Theory]
    [InlineData("0.wld")]
    [InlineData("1.wld")]
    [InlineData("2.wld")]
    [InlineData("3.wld")]
    [InlineData("4.wld")]
    [InlineData("42.wld")]
    public void WldMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/WLD/{fileName}";
        string outputPath = $"Shaiya/WLD/output_{fileName}";
        string jsonPath = $"Shaiya/WLD/{fileName}.json";
        string newObjPath = $"Shaiya/WLD/new_{fileName}";

        var wld = ParsecReader.ReadFromFile<Parsec.Shaiya.Wld.Wld>(filePath);
        wld.Write(outputPath);
        wld.WriteJson(jsonPath);

        var outputWld = ParsecReader.ReadFromFile<Parsec.Shaiya.Wld.Wld>(outputPath);
        var wldFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.Wld.Wld>(jsonPath);

        // Check bytes
        Assert.Equal(wld.GetBytes(), outputWld.GetBytes());
        Assert.Equal(wld.GetBytes(), wldFromJson.GetBytes());

        wldFromJson.Write(newObjPath);
        var newWld = ParsecReader.ReadFromFile<Parsec.Shaiya.Wld.Wld>(newObjPath);

        // Check bytes
        Assert.Equal(wld.GetBytes(), newWld.GetBytes());
    }
}
