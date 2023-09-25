using System.Linq;

namespace Parsec.Tests.Shaiya.KillStatus;

public class KillStatusTests
{
    [Fact]
    public void KillStatusTest()
    {
        const string filePath = "Shaiya/KillStatus/KillStatus.SData";
        const string outputPath = "Shaiya/KillStatus/KillStatus.output.SData";
        const string jsonPath = "Shaiya/KillStatus/KillStatus.SData.json";
        var obj = Reader.ReadFromFile<Parsec.Shaiya.KillStatus.KillStatus>(filePath);
        obj.Write(outputPath);
        obj.WriteJson(jsonPath);

        var outputObj = Reader.ReadFromFile<Parsec.Shaiya.KillStatus.KillStatus>(outputPath);
        var jsonObj = Reader.ReadFromJsonFile<Parsec.Shaiya.KillStatus.KillStatus>(jsonPath);

        var expected = obj.GetBytes().ToList();
        Assert.Equal(expected, outputObj.GetBytes());
        Assert.Equal(expected, jsonObj.GetBytes());
    }
}
