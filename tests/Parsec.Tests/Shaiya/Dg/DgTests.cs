namespace Parsec.Tests.Shaiya.Dg;

public class DgTests
{
    [Theory]
    [InlineData("R1_Dun1_2F.dg")]
    [InlineData("r1_dun3.dg")]
    [InlineData("r1_dun3_01.dg")]
    [InlineData("r1_dun3_02.dg")]
    [InlineData("r1_dun3_boss.dg")]
    [InlineData("R1_Trade.dg")]
    [InlineData("R2_Dun1.dg")]
    public void DgMultipleReadWriteTest(string fileName)
    {
        var filePath = $"Shaiya/Dg/{fileName}";
        var outputPath = $"Shaiya/Dg/output_{fileName}";
        var jsonPath = $"Shaiya/Dg/{fileName}.json";

        var dg = ParsecReader.FromFile<Parsec.Shaiya.Dg.Dg>(filePath);
        dg.Write(outputPath);
        dg.WriteJson(jsonPath);

        var outputDg = ParsecReader.FromFile<Parsec.Shaiya.Dg.Dg>(outputPath);
        var dgFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Dg.Dg>(jsonPath);

        // Check bytes
        Assert.Equal(dg.GetBytes(), outputDg.GetBytes());
        Assert.Equal(dg.GetBytes(), dgFromJson.GetBytes());
    }
}
