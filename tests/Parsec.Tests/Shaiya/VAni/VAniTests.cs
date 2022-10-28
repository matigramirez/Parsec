using Xunit;

namespace Parsec.Tests.Shaiya.VAni;

public class VAniTests
{
    [Theory]
    [InlineData("A1_butterfly01.vani")]
    [InlineData("A1_Green_ani00.vani")]
    [InlineData("AB7_dun2_femalebeeBUD.vani")]
    [InlineData("AB7_UReggStoNail01b.vani")]
    [InlineData("B2_grass_Ani01.vani")]
    [InlineData("D_Deadbody_01.vani")]
    [InlineData("L_A1_Ferry_Ship.vani")]
    [InlineData("R1_Green_ani06.vani")]
    [InlineData("R2_FireStone.vani")]
    public void VaniMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/VAni/{fileName}";
        string jsonPath = $"Shaiya/VAni/{fileName}.json";
        string newObjPath = $"Shaiya/VAni/new_{fileName}";

        var vani = Reader.ReadFromFile<Parsec.Shaiya.VAni.VAni>(filePath);
        vani.ExportJson(jsonPath);
        var vaniFromJson = Reader.ReadFromJson<Parsec.Shaiya.VAni.VAni>(jsonPath);

        // Check bytes
        Assert.Equal(vani.GetBytes(), vaniFromJson.GetBytes());

        vaniFromJson.Write(newObjPath);
        var newVani = Reader.ReadFromFile<Parsec.Shaiya.VAni.VAni>(newObjPath);

        // Check bytes
        Assert.Equal(vani.GetBytes(), newVani.GetBytes());
    }
}
