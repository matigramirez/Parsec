﻿namespace Parsec.Tests.Shaiya.MLT;

public class MltTests
{
    [Theory]
    [InlineData("demf_face.MLT")]
    [InlineData("demf_hair.MLT")]
    [InlineData("demf_helmet.MLT")]
    [InlineData("demr_helmet.MLT")]
    [InlineData("dewr_hand.MLT")]
    [InlineData("humf_face.MLT")]
    [InlineData("humf_foot.MLT")]
    [InlineData("humf_helmet.MLT")]
    [InlineData("humf_lower.MLT")]
    [InlineData("huwf_lower.MLT")]
    [InlineData("huwf_upper.MLT")]
    [InlineData("huwm_lower.MLT")]
    [InlineData("huwm_upper.MLT")]
    public void MltMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/MLT/{fileName}";
        string outputPath = $"Shaiya/MLT/output_{fileName}";
        string jsonPath = $"Shaiya/MLT/{fileName}.json";
        string newObjPath = $"Shaiya/MLT/new_{fileName}";

        var mlt = ParsecReader.FromFile<Parsec.Shaiya.Mlt.Mlt>(filePath);
        mlt.Write(outputPath);
        mlt.WriteJson(jsonPath);

        var outputMlt = ParsecReader.FromFile<Parsec.Shaiya.Mlt.Mlt>(outputPath);
        var mltFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.Mlt.Mlt>(jsonPath);

        // Check bytes
        Assert.Equal(mlt.GetBytes(), outputMlt.GetBytes());
        Assert.Equal(mlt.GetBytes(), mltFromJson.GetBytes());

        mltFromJson.Write(newObjPath);
        var newMlt = ParsecReader.FromFile<Parsec.Shaiya.Mlt.Mlt>(newObjPath);

        // Check bytes
        Assert.Equal(mlt.GetBytes(), newMlt.GetBytes());
    }
}
