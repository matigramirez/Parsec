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

        var mlx = ParsecReader.ReadFromFile<Parsec.Shaiya.Mlx.Mlx>(filePath);
        mlx.Write(outputPath);
        mlx.WriteJson(jsonPath);

        var outputMlx = ParsecReader.ReadFromFile<Parsec.Shaiya.Mlx.Mlx>(outputPath);
        var mlxFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.Mlx.Mlx>(jsonPath);

        // Check bytes
        Assert.Equal(mlx.GetBytes(), outputMlx.GetBytes());
        Assert.Equal(mlx.GetBytes(), mlxFromJson.GetBytes());

        mlxFromJson.Write(newObjPath);
        var newMlx = ParsecReader.ReadFromFile<Parsec.Shaiya.Mlx.Mlx>(newObjPath);

        // Check bytes
        Assert.Equal(mlx.GetBytes(), newMlx.GetBytes());
    }
}
