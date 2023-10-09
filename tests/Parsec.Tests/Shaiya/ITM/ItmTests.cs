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

        var itm = ParsecReader.FromFile<Parsec.Shaiya.Itm.Itm>(filePath);
        itm.WriteJson(jsonPath);
        var itmFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Itm.Itm>(jsonPath);

        // Check bytes
        Assert.Equal(itm.GetBytes(), itmFromJson.GetBytes());

        itmFromJson.Write(newObjPath);
        var newItm = ParsecReader.FromFile<Parsec.Shaiya.Itm.Itm>(newObjPath);

        // Check bytes
        Assert.Equal(itm.GetBytes(), newItm.GetBytes());
    }
}
