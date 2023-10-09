namespace Parsec.Tests.Shaiya.Seff;

public class SeffTests
{
    [Theory]
    [InlineData("2009_03_18.Seff")]
    [InlineData("EventEffect.Seff")]
    [InlineData("Login_cloud.Seff")]
    [InlineData("weapon.Seff")]
    [InlineData("Weather.Seff")]
    public void SeffMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/Seff/{fileName}";
        string outputPath = $"Shaiya/Seff/output_{fileName}";
        string jsonPath = $"Shaiya/Seff/{fileName}.json";
        string newFilePath = $"Shaiya/Seff/new_{fileName}";

        var seff = ParsecReader.FromFile<Parsec.Shaiya.Seff.Seff>(filePath);
        seff.Write(outputPath);
        seff.WriteJson(jsonPath);

        var outputSeff = ParsecReader.FromFile<Parsec.Shaiya.Seff.Seff>(outputPath);
        var seffFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Seff.Seff>(jsonPath);

        // Check bytes
        Assert.Equal(seff.GetBytes(), outputSeff.GetBytes());
        Assert.Equal(seff.GetBytes(), seffFromJson.GetBytes());

        seffFromJson.Write(newFilePath);
        var newSeff = ParsecReader.FromFile<Parsec.Shaiya.Seff.Seff>(newFilePath);

        // Check bytes
        Assert.Equal(seff.GetBytes(), newSeff.GetBytes());

        // Checksum files
        Assert.Equal(FileHash.Checksum(filePath), FileHash.Checksum(outputPath));
        Assert.Equal(FileHash.Checksum(filePath), FileHash.Checksum(newFilePath));
    }
}
