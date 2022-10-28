using Xunit;

namespace Parsec.Tests.Shaiya.ALT;

public class AltTests
{
    [Theory]
    [InlineData("demf_action.ALT")]
    [InlineData("dewf_action.ALT")]
    [InlineData("elmm_action.ALT")]
    [InlineData("elmr_action.ALT")]
    [InlineData("humf_action.ALT")]
    [InlineData("humm_action.ALT")]
    [InlineData("vimm_action.ALT")]
    [InlineData("vimr_action.ALT")]
    public void AltMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/ALT/{fileName}";
        string jsonPath = $"Shaiya/ALT/{fileName}.json";
        string newObjPath = $"Shaiya/ALT/new_{fileName}";

        var alt = Reader.ReadFromFile<Parsec.Shaiya.ALT.ALT>(filePath);
        alt.ExportJson(jsonPath);
        var altFromJson = Reader.ReadFromJson<Parsec.Shaiya.ALT.ALT>(jsonPath);

        // Check bytes
        Assert.Equal(alt.GetBytes(), altFromJson.GetBytes());

        altFromJson.Write(newObjPath);
        var newAlt = Reader.ReadFromFile<Parsec.Shaiya.ALT.ALT>(newObjPath);

        // Check bytes
        Assert.Equal(alt.GetBytes(), newAlt.GetBytes());
    }
}
