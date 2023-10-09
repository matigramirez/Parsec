using System.Linq;
using Parsec.Shaiya.DualLayerClothes;

namespace Parsec.Tests.Shaiya.DualLayerClothes;

public class DualLayerClothesTests
{
    [Fact]
    public void DualLayerClothesTest()
    {
        var filePath = "Shaiya/DualLayerClothes/DualLayerClothes.SData";
        var outputPath = "Shaiya/DualLayerClothes/output_DualLayerClothes.SData";
        var jsonPath = "Shaiya/DualLayerClothes/DualLayerClothes.SData.json";
        var newObjPath = "Shaiya/DualLayerClothes/new_DualLayerClothes.SData";

        var dualLayerClothes = ParsecReader.FromFile<Parsec.Shaiya.DualLayerClothes.DualLayerClothes>(filePath);

        dualLayerClothes.Write(outputPath);
        dualLayerClothes.WriteJson(jsonPath);

        var outputDualLayerClothes = ParsecReader.FromFile<Parsec.Shaiya.DualLayerClothes.DualLayerClothes>(outputPath);
        var dualLayerClothesFromJson = ParsecReader.FromJsonFile<Parsec.Shaiya.DualLayerClothes.DualLayerClothes>(jsonPath);

        Assert.Equal(dualLayerClothes.GetBytes(), outputDualLayerClothes.GetBytes());
        Assert.Equal(dualLayerClothes.GetBytes(), dualLayerClothesFromJson.GetBytes());

        dualLayerClothesFromJson.Write(newObjPath);
        var newDualLayerClothes = ParsecReader.FromFile<Parsec.Shaiya.DualLayerClothes.DualLayerClothes>(newObjPath);

        Assert.Equal(dualLayerClothes.GetBytes(), newDualLayerClothes.GetBytes());
    }

    [Fact]
    public void DbDualLayerClothesTest()
    {
        const string filePath = "Shaiya/DualLayerClothes/DBDualLayerClothesData.SData";
        const string outputPath = "Shaiya/DualLayerClothes/output_DBDualLayerClothesData.SData";
        const string jsonPath = "Shaiya/DualLayerClothes/DBDualLayerClothesData.SData.json";
        const string csvPath = "Shaiya/DualLayerClothes/DBDualLayerClothesData.SData.csv";

        var dbDualLayerClothes = ParsecReader.FromFile<DBDualLayerClothesData>(filePath);
        dbDualLayerClothes.Write(outputPath);
        dbDualLayerClothes.WriteJson(jsonPath);
        dbDualLayerClothes.WriteCsv(csvPath);

        var outputDbDualLayerClothes = ParsecReader.FromFile<DBDualLayerClothesData>(outputPath);
        var jsonDbDualLayerClothes = ParsecReader.FromJsonFile<DBDualLayerClothesData>(jsonPath);
        var csvDualLayerClothes = DBDualLayerClothesData.FromCsv<DBDualLayerClothesData>(csvPath);

        var expected = dbDualLayerClothes.GetBytes().ToList();
        Assert.Equal(expected, outputDbDualLayerClothes.GetBytes());
        Assert.Equal(expected, jsonDbDualLayerClothes.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvDualLayerClothes.GetBytes().Skip(128));
    }
}
