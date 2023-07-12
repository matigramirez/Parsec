using System.Linq;

namespace Parsec.Tests.Shaiya.KillStatus;

public class KillStatusTests
{
    [Fact]
    public void KillStatusTest()
    {
        const string filePath = "Shaiya/KillStatus/KillStatus.SData";
        const string outputPath = "Shaiya/KillStatus/KillStatus.output.SData";
        const string jsonPath = "Shaiya/KillStatus/KillStatus.json";

        var killStatus = Reader.ReadFromFile<Parsec.Shaiya.KillStatus.KillStatus>(filePath);
        killStatus.Write(outputPath);
        killStatus.ExportJson(jsonPath);

        var killStatusData = Reader.ReadFromFile<Parsec.Shaiya.KillStatus.KillStatus>(outputPath);
        var killStatusJson = Reader.ReadFromJsonFile<Parsec.Shaiya.KillStatus.KillStatus>(jsonPath);

        var expected = killStatus.GetBytes().ToList();
        Assert.Equal(expected, killStatusData.GetBytes());
        Assert.Equal(expected, killStatusJson.GetBytes());
    }
}
