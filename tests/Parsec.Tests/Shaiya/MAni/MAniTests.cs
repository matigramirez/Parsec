﻿namespace Parsec.Tests.Shaiya.MAni;

public class MAniTests
{
    [Theory]
    [InlineData("A8_DUN_2F_statue_ANI.mani")]
    [InlineData("Boat_B2.mani")]
    [InlineData("halloween_pumkin02.mani")]
    [InlineData("Login_floatrock01a.mani")]
    [InlineData("login_rotate02.mani")]
    [InlineData("raputa.mani")]
    [InlineData("stoneimage.mani")]
    [InlineData("turn_rocks02.mani")]
    [InlineData("wing.mani")]
    [InlineData("Wing_small.mani")]
    [InlineData("World_01.mani")]
    public void MAniMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/MAni/{fileName}";
        string jsonPath = $"Shaiya/MAni/{fileName}.json";
        string newObjPath = $"Shaiya/MAni/new_{fileName}";

        var mani = ParsecReader.FromFile<Parsec.Shaiya.Mani.Mani>(filePath);
        mani.WriteJson(jsonPath);
        var maniFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Mani.Mani>(jsonPath);

        // Check bytes
        Assert.Equal(mani.GetBytes(), maniFromJson.GetBytes());

        maniFromJson.Write(newObjPath);
        var newMani = ParsecReader.FromFile<Parsec.Shaiya.Mani.Mani>(newObjPath);

        // Check bytes
        Assert.Equal(mani.GetBytes(), newMani.GetBytes());
    }
}
