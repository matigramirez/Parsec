using Xunit;

namespace Parsec.Tests.Shaiya.MON;

public class MonTests
{
    [Theory]
    [InlineData("monster.MON")]
    [InlineData("NPC.MON")]
    [InlineData("Vehicle_De_01.MON")]
    [InlineData("Vehicle_El_01.MON")]
    [InlineData("Vehicle_Hu_01.MON")]
    [InlineData("Vehicle_Vi_01.MON")]
    [InlineData("Wing.MON")]
    public void MonMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/MON/{fileName}";
        string outputPath = $"Shaiya/MON/output_{fileName}";
        string jsonPath = $"Shaiya/MON/{fileName}.json";
        string newObjPath = $"Shaiya/MON/new_{fileName}";

        var mon = Reader.ReadFromFile<Parsec.Shaiya.MON.MON>(filePath);

        mon.Write(outputPath);
        mon.ExportJson(jsonPath);

        var outputMon = Reader.ReadFromFile<Parsec.Shaiya.MON.MON>(outputPath);
        var monFromJson = Reader.ReadFromJson<Parsec.Shaiya.MON.MON>(jsonPath);

        // Check bytes
        Assert.Equal(mon.GetBytes(), outputMon.GetBytes());
        Assert.Equal(mon.GetBytes(), monFromJson.GetBytes());

        monFromJson.Write(newObjPath);
        var newMon = Reader.ReadFromFile<Parsec.Shaiya.MON.MON>(newObjPath);

        // Check bytes
        Assert.Equal(mon.GetBytes(), newMon.GetBytes());
    }
}
