using Xunit;

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
        string jsonPath = $"Shaiya/Seff/{fileName}.json";
        string newObjPath = $"Shaiya/Seff/new_{fileName}";

        var seff = Reader.ReadFromFile<Parsec.Shaiya.Seff.Seff>(filePath);
        seff.ExportJson(jsonPath);
        var seffFromJson = Reader.ReadFromJson<Parsec.Shaiya.Seff.Seff>(jsonPath);

        // Check bytes
        Assert.Equal(seff.GetBytes(), seffFromJson.GetBytes());

        seffFromJson.Write(newObjPath);
        var newSeff = Reader.ReadFromFile<Parsec.Shaiya.Seff.Seff>(newObjPath);

        // Check bytes
        Assert.Equal(seff.GetBytes(), newSeff.GetBytes());
    }
}
