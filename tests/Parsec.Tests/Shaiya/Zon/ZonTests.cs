using Xunit;

namespace Parsec.Tests.Shaiya.Zon;

public class ZonTests
{
    [Theory]
    [InlineData("TacticsZone.zon")]
    public void ZonMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/Zon/{fileName}";
        string jsonPath = $"Shaiya/Zon/{fileName}.json";
        string newObjPath = $"Shaiya/Zon/new_{fileName}";

        var zon = Reader.ReadFromFile<Parsec.Shaiya.Zon.Zon>(filePath);
        zon.ExportJson(jsonPath);
        var zonFromJson = Reader.ReadFromJson<Parsec.Shaiya.Zon.Zon>(jsonPath);

        // Check bytes
        Assert.Equal(zon.GetBytes(), zonFromJson.GetBytes());

        zonFromJson.Write(newObjPath);
        var newZon = Reader.ReadFromFile<Parsec.Shaiya.Zon.Zon>(newObjPath);

        // Check bytes
        Assert.Equal(zon.GetBytes(), newZon.GetBytes());
    }
}
