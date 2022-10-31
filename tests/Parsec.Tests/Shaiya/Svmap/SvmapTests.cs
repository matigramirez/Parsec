namespace Parsec.Tests.Shaiya.Svmap;

public class SvmapTests
{
    [Theory]
    [InlineData("0.svmap")]
    [InlineData("1.svmap")]
    [InlineData("2.svmap")]
    [InlineData("9.svmap")]
    [InlineData("42.svmap")]
    [InlineData("45.svmap")]
    [InlineData("47.svmap")]
    [InlineData("52.svmap")]
    [InlineData("66.svmap")]
    [InlineData("71.svmap")]
    public void SmodMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/Svmap/{fileName}";
        string jsonPath = $"Shaiya/Svmap/{fileName}.json";
        string newObjPath = $"Shaiya/Svmap/new_{fileName}";

        var smod = Reader.ReadFromFile<Parsec.Shaiya.Svmap.Svmap>(filePath);
        smod.ExportJson(jsonPath);
        var smodFromJson = Reader.ReadFromJson<Parsec.Shaiya.Svmap.Svmap>(jsonPath);

        // Check bytes
        Assert.Equal(smod.GetBytes(), smodFromJson.GetBytes());

        smodFromJson.Write(newObjPath);
        var newSmod = Reader.ReadFromFile<Parsec.Shaiya.Svmap.Svmap>(newObjPath);

        // Check bytes
        Assert.Equal(smod.GetBytes(), newSmod.GetBytes());
    }
}
