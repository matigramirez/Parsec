using Xunit;

namespace Parsec.Tests.Shaiya.ITM;

public class ItmTests
{
    [Theory]
    [InlineData("01.ITM")]
    [InlineData("04.ITM")]
    [InlineData("05.ITM")]
    [InlineData("08.ITM")]
    [InlineData("10.ITM")]
    [InlineData("13.ITM")]
    [InlineData("19.ITM")]
    public void ItmMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/ITM/{fileName}";
        string jsonPath = $"Shaiya/ITM/{fileName}.json";
        string newObjPath = $"Shaiya/ITM/new_{fileName}";

        var itm = Reader.ReadFromFile<Parsec.Shaiya.ITM.ITM>(filePath);
        itm.ExportJson(jsonPath);
        var itmFromJson = Reader.ReadFromJson<Parsec.Shaiya.ITM.ITM>(jsonPath);

        // Check bytes
        Assert.Equal(itm.GetBytes(), itmFromJson.GetBytes());

        itmFromJson.Write(newObjPath);
        var newItm = Reader.ReadFromFile<Parsec.Shaiya.ITM.ITM>(newObjPath);

        // Check bytes
        Assert.Equal(itm.GetBytes(), newItm.GetBytes());
    }
}
