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

        var mon = ParsecReader.FromFile<Parsec.Shaiya.Mon.Mon>(filePath);

        mon.Write(outputPath);
        mon.WriteJson(jsonPath);

        var outputMon = ParsecReader.FromFile<Parsec.Shaiya.Mon.Mon>(outputPath);
        var monFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Mon.Mon>(jsonPath);

        // Check bytes
        Assert.Equal(mon.GetBytes(), outputMon.GetBytes());
        Assert.Equal(mon.GetBytes(), monFromJson.GetBytes());

        monFromJson.Write(newObjPath);
        var newMon = ParsecReader.FromFile<Parsec.Shaiya.Mon.Mon>(newObjPath);

        // Check bytes
        Assert.Equal(mon.GetBytes(), newMon.GetBytes());
    }
}
