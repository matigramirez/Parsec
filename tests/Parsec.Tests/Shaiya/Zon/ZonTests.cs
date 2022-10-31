namespace Parsec.Tests.Shaiya.Zon;

public class ZonTests
{
    [Theory]
    [InlineData("TacticsZone.zon")]
    public void ZonMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/Zon/{fileName}";
        string outputPath = $"Shaiya/Zon/output_{fileName}";
        string jsonPath = $"Shaiya/Zon/{fileName}.json";
        string newObjPath = $"Shaiya/Zon/new_{fileName}";

        var zon = Reader.ReadFromFile<Parsec.Shaiya.Zon.Zon>(filePath);

        // Since record descriptions use different encodings for the Description string, the Zon -> JSON -> Zon conversion
        // will always modify the Description
        foreach (var record in zon.Records)
            record.Description = "TestDescription";

        zon.Write(outputPath);
        zon.ExportJson(jsonPath);

        var outputZon = Reader.ReadFromFile<Parsec.Shaiya.Zon.Zon>(outputPath);
        var zonFromJson = Reader.ReadFromJson<Parsec.Shaiya.Zon.Zon>(jsonPath);

        // Check bytes
        Assert.Equal(zon.GetBytes(), outputZon.GetBytes());
        Assert.Equal(zon.GetBytes(), zonFromJson.GetBytes());

        zonFromJson.Write(newObjPath);
        var newZon = Reader.ReadFromFile<Parsec.Shaiya.Zon.Zon>(newObjPath);

        // Check bytes
        Assert.Equal(zon.GetBytes(), newZon.GetBytes());
    }
}
