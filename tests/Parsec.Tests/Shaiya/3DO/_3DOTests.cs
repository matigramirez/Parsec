using Parsec.Common;
using Xunit;

namespace Parsec.Tests.Shaiya._3DO;

public class _3DOTests
{
    [Fact]
    public void _3DOReadWriteEP5Test()
    {
        const string filePath = "Shaiya/3DO/F_34_a002.3DO";
        var obj = Reader.ReadFromFile<Parsec.Shaiya._3DO._3DO>(filePath);

        // Check original EFT values
        Assert.Equal(1087, obj.Vertices.Count);
        Assert.Equal(964, obj.Faces.Count);
        Assert.Equal(Episode.EP5, obj.Episode);

        // Export to json
        const string jsonPath = "Shaiya/3DO/F_34_a002.3DO.json";
        obj.ExportJson(jsonPath);
        var objFromJson = Reader.ReadFromJson<Parsec.Shaiya._3DO._3DO>(jsonPath);

        // Check fields
        Assert.Equal(obj.Vertices.Count, objFromJson.Vertices.Count);
        Assert.Equal(obj.Faces.Count, objFromJson.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        const string newObjPath = "Shaiya/3DO/F_34_a002.new.3DO";
        objFromJson.Write(newObjPath);

        var newObj = Reader.ReadFromFile<Parsec.Shaiya._3DO._3DO>(newObjPath);

        // Check fields
        Assert.Equal(obj.Vertices.Count, newObj.Vertices.Count);
        Assert.Equal(obj.Faces.Count, newObj.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }
}
