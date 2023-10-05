namespace Parsec.Tests.Shaiya.ALT;

public class AltTests
{
    [Theory]
    [InlineData("demf_action.alt")]
    [InlineData("dewf_action.alt")]
    [InlineData("elmm_action.alt")]
    [InlineData("elmr_action.alt")]
    [InlineData("humf_action.alt")]
    [InlineData("humm_action.alt")]
    [InlineData("vimm_action.alt")]
    [InlineData("vimr_action.alt")]
    public void AltMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/ALT/{fileName}";
        string jsonPath = $"Shaiya/ALT/{fileName}.json";
        string newObjPath = $"Shaiya/ALT/new_{fileName}";

        var alt = Reader.ReadFromFile<Parsec.Shaiya.Alt.Alt>(filePath);
        alt.WriteJson(jsonPath);
        var altFromJson = Reader.ReadFromJsonFile<Parsec.Shaiya.Alt.Alt>(jsonPath);

        // Check bytes
        Assert.Equal(alt.GetBytes(), altFromJson.GetBytes());

        altFromJson.Write(newObjPath);
        var newAlt = Reader.ReadFromFile<Parsec.Shaiya.Alt.Alt>(newObjPath);

        // Check bytes
        Assert.Equal(alt.GetBytes(), newAlt.GetBytes());
    }
}
