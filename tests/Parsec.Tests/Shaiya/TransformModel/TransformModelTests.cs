using System.Linq;
using Parsec.Shaiya.TransformModel;

namespace Parsec.Tests.Shaiya.TransformModel;

public class TransformModelTests
{
    [Fact]
    public void DbTransformModelTest()
    {
        const string filePath = "Shaiya/TransformModel/DBTransformModelData.SData";
        const string outputPath = "Shaiya/Skill/output_DBTransformModelData.SData";
        const string jsonPath = "Shaiya/Skill/DBTransformModelData.SData.json";
        const string csvPath = "Shaiya/Skill/DBTransformModelData.SData.csv";

        var transformModel = ParsecReader.FromFile<DBTransformModelData>(filePath);
        transformModel.Write(outputPath);
        transformModel.WriteJson(jsonPath);
        transformModel.WriteCsv(csvPath);

        var outputTransformModel = ParsecReader.FromFile<DBTransformModelData>(outputPath);
        var jsonTransformModel = ParsecReader.FromJsonFile<DBTransformModelData>(jsonPath);
        var csvTransformModel = DBTransformModelData.FromCsv<DBTransformModelData>(csvPath);

        var expected = transformModel.GetBytes().ToList();
        Assert.Equal(expected, outputTransformModel.GetBytes());
        Assert.Equal(expected, jsonTransformModel.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvTransformModel.GetBytes().Skip(128));
    }

    [Fact]
    public void DbTransformWeaponModelTest()
    {
        const string filePath = "Shaiya/TransformModel/DBTransformWeaponModelData.SData";
        const string outputPath = "Shaiya/Skill/output_DBTransformWeaponModelData.SData";
        const string jsonPath = "Shaiya/Skill/DBTransformWeaponModelData.SData.json";
        const string csvPath = "Shaiya/Skill/DBTransformWeaponModelData.SData.csv";

        var transformModel = ParsecReader.FromFile<DBTransformWeaponModelData>(filePath);
        transformModel.Write(outputPath);
        transformModel.WriteJson(jsonPath);
        transformModel.WriteCsv(csvPath);

        var outputTransformModel = ParsecReader.FromFile<DBTransformWeaponModelData>(outputPath);
        var jsonTransformModel = ParsecReader.FromJsonFile<DBTransformWeaponModelData>(jsonPath);
        var csvTransformModel = DBTransformWeaponModelData.FromCsv<DBTransformWeaponModelData>(csvPath);

        var expected = transformModel.GetBytes().ToList();
        Assert.Equal(expected, outputTransformModel.GetBytes());
        Assert.Equal(expected, jsonTransformModel.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvTransformModel.GetBytes().Skip(128));
    }
}
