using Xunit;

namespace Parsec.Tests.Shaiya.MLX;

public class MlxTests
{
    [Theory]
    [InlineData("demf.MLX")]
    [InlineData("demr.MLX")]
    [InlineData("dewf.MLX")]
    [InlineData("dewr.MLX")]
    [InlineData("elmm.MLX")]
    [InlineData("elmr.MLX")]
    [InlineData("elwm.MLX")]
    [InlineData("elwr.MLX")]
    [InlineData("humf.MLX")]
    [InlineData("humm.MLX")]
    [InlineData("huwf.MLX")]
    [InlineData("huwm.MLX")]
    [InlineData("vimm.MLX")]
    [InlineData("vimr.MLX")]
    [InlineData("viwm.MLX")]
    [InlineData("viwr.MLX")]
    public void MlxMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/MLX/{fileName}";
        string outputPath = $"Shaiya/MLX/output_{fileName}";
        string jsonPath = $"Shaiya/MLX/{fileName}.json";
        string newObjPath = $"Shaiya/MLX/new_{fileName}";

        var mlx = Reader.ReadFromFile<Parsec.Shaiya.MLX.MLX>(filePath);
        mlx.Write(outputPath);
        mlx.ExportJson(jsonPath);

        var outputMlx = Reader.ReadFromFile<Parsec.Shaiya.MLX.MLX>(outputPath);
        var mlxFromJson = Reader.ReadFromJson<Parsec.Shaiya.MLX.MLX>(jsonPath);

        // Check bytes
        Assert.Equal(mlx.GetBytes(), outputMlx.GetBytes());
        Assert.Equal(mlx.GetBytes(), mlxFromJson.GetBytes());

        mlxFromJson.Write(newObjPath);
        var newMlx = Reader.ReadFromFile<Parsec.Shaiya.MLX.MLX>(newObjPath);

        // Check bytes
        Assert.Equal(mlx.GetBytes(), newMlx.GetBytes());
    }
}
