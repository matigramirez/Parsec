namespace Parsec.Tests.Shaiya._3DE;

public class _3DETests
{
    [Fact]
    public void _3DEReadWriteTest()
    {
        const string filePath = "Shaiya/3DE/waterfall04.3DE";
        var obj = Reader.ReadFromFile<Parsec.Shaiya._3DE._3DE>(filePath);

        // Check original EFT values
        Assert.Equal(126, obj.Vertices.Count);
        Assert.Equal(208, obj.Faces.Count);
        Assert.Equal(46, obj.Frames.Count);
        Assert.Equal(90, obj.MaxKeyframe);

        // Export to json
        const string jsonPath = "Shaiya/3DE/waterfall04.3DE.json";
        obj.ExportJson(jsonPath);
        var objFromJson = Reader.ReadFromJson<Parsec.Shaiya._3DE._3DE>(jsonPath);

        // Check fields
        Assert.Equal(obj.Vertices.Count, objFromJson.Vertices.Count);
        Assert.Equal(obj.Faces.Count, objFromJson.Faces.Count);
        Assert.Equal(obj.Frames.Count, objFromJson.Frames.Count);
        Assert.Equal(obj.MaxKeyframe, objFromJson.MaxKeyframe);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        const string newObjPath = "Shaiya/3DE/waterfall04.new.3DE";
        objFromJson.Write(newObjPath);

        var newObj = Reader.ReadFromFile<Parsec.Shaiya._3DE._3DE>(newObjPath);

        // Check fields
        Assert.Equal(obj.Vertices.Count, newObj.Vertices.Count);
        Assert.Equal(obj.Faces.Count, newObj.Faces.Count);
        Assert.Equal(obj.Frames.Count, newObj.Frames.Count);
        Assert.Equal(obj.MaxKeyframe, newObj.MaxKeyframe);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }

    [Theory]
    [InlineData("angelybill00.3DE")]
    [InlineData("death_b01.3DE")]
    [InlineData("death_b03.3DE")]
    [InlineData("ghost00.3DE")]
    [InlineData("hailstorm001.3DE")]
    [InlineData("ice_wall_02.3DE")]
    [InlineData("Mob_Cassiel_IP.3DE")]
    [InlineData("sidew00.3DE")]
    [InlineData("waterfall04.3DE")]
    public void _3DEMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/3DE/{fileName}";
        string jsonPath = $"Shaiya/3DE/{fileName}.json";
        string newObjPath = $"Shaiya/3DE/new_{fileName}";

        var obj = Reader.ReadFromFile<Parsec.Shaiya._3DE._3DE>(filePath);
        obj.ExportJson(jsonPath);
        var objFromJson = Reader.ReadFromJson<Parsec.Shaiya._3DE._3DE>(jsonPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        objFromJson.Write(newObjPath);
        var newObj = Reader.ReadFromFile<Parsec.Shaiya._3DE._3DE>(newObjPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }
}
