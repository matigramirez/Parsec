using Xunit;

namespace Parsec.Tests.Shaiya.MAni;

public class MAniTests
{
    [Theory]
    [InlineData("A8_DUN_2F_statue_ANI.MAni")]
    [InlineData("Boat_B2.MAni")]
    [InlineData("halloween_pumkin02.MAni")]
    [InlineData("Login_floatrock01a.MAni")]
    [InlineData("login_rotate02.MAni")]
    [InlineData("raputa.MAni")]
    [InlineData("stoneimage.MAni")]
    [InlineData("turn_rocks02.MAni")]
    [InlineData("wing.MAni")]
    [InlineData("Wing_small.MAni")]
    [InlineData("World_01.MAni")]
    public void MAniMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/MAni/{fileName}";
        string jsonPath = $"Shaiya/MAni/{fileName}.json";
        string newObjPath = $"Shaiya/MAni/new_{fileName}";

        var mani = Reader.ReadFromFile<Parsec.Shaiya.MAni.MAni>(filePath);
        mani.ExportJson(jsonPath);
        var maniFromJson = Reader.ReadFromJson<Parsec.Shaiya.MAni.MAni>(jsonPath);

        // Check bytes
        Assert.Equal(mani.GetBytes(), maniFromJson.GetBytes());

        maniFromJson.Write(newObjPath);
        var newMani = Reader.ReadFromFile<Parsec.Shaiya.MAni.MAni>(newObjPath);

        // Check bytes
        Assert.Equal(mani.GetBytes(), newMani.GetBytes());
    }
}
