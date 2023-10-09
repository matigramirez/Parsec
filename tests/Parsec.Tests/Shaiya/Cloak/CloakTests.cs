namespace Parsec.Tests.Shaiya.Cloak;

public class CloakTests
{
    [Theory]
    [InlineData("CLOTH_TEXTHRE_DE.CTL")]
    [InlineData("CLOTH_TEXTHRE_EL.CTL")]
    [InlineData("CLOTH_TEXTHRE_HU.CTL")]
    [InlineData("CLOTH_TEXTHRE_VI.CTL")]
    public void CtlReadWriteTest(string fileName)
    {
        var filePath = $"Shaiya/Cloak/{fileName}";
        var jsonPath = $"Shaiya/Cloak/{fileName}.json";
        var newObjPath = $"Shaiya/Cloak/new_{fileName}";

        var obj = ParsecReader.FromFile<Parsec.Shaiya.Cloak.ClothTexture.Ctl>(filePath);

        obj.WriteJson(jsonPath);
        var objFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Cloak.ClothTexture.Ctl>(jsonPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        objFromJson.Write(newObjPath);
        var newObj = ParsecReader.FromFile<Parsec.Shaiya.Cloak.ClothTexture.Ctl>(newObjPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }

    [Theory]
    [InlineData("EmblemBack.dat")]
    [InlineData("EmblemFront.dat")]
    [InlineData("EmblemList.dat")]
    public void EmblemDatReadWriteTest(string fileName)
    {
        var filePath = $"Shaiya/Cloak/{fileName}";
        var jsonPath = $"Shaiya/Cloak/{fileName}.json";
        var newObjPath = $"Shaiya/Cloak/new_{fileName}";

        var obj = ParsecReader.FromFile<Parsec.Shaiya.Cloak.Emblem.EmblemDat>(filePath);

        obj.WriteJson(jsonPath);
        var objFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Cloak.Emblem.EmblemDat>(jsonPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        objFromJson.Write(newObjPath);
        var newObj = ParsecReader.FromFile<Parsec.Shaiya.Cloak.Emblem.EmblemDat>(newObjPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }
}
