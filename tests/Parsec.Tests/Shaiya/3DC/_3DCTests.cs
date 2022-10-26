using Parsec.Common;
using Xunit;

namespace Parsec.Tests.Shaiya._3DC;

public class _3DCTests
{
    [Fact]
    public void _3DCReadWriteEP5Test()
    {
        const string filePath = "Shaiya/3DC/Mob_Fox_01.3DC";
        var obj = Reader.ReadFromFile<Parsec.Shaiya._3DC._3DC>(filePath);

        // Check original EFT values
        Assert.Equal(32, obj.Bones.Count);
        Assert.Equal(808, obj.Vertices.Count);
        Assert.Equal(892, obj.Faces.Count);
        Assert.Equal(Episode.EP5, obj.Episode);

        // Export to json
        const string jsonPath = "Shaiya/3DC/Mob_Fox_01.3DC.json";
        obj.ExportJson(jsonPath);
        var objFromJson = Reader.ReadFromJson<Parsec.Shaiya._3DC._3DC>(jsonPath);

        // Check fields
        Assert.Equal(obj.Bones.Count, objFromJson.Bones.Count);
        Assert.Equal(obj.Vertices.Count, objFromJson.Vertices.Count);
        Assert.Equal(obj.Faces.Count, objFromJson.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        const string newObjPath = "Shaiya/3DC/Mob_Fox_01.new.3DC";
        objFromJson.Write(newObjPath);

        var newObj = Reader.ReadFromFile<Parsec.Shaiya._3DC._3DC>(newObjPath);

        // Check fields
        Assert.Equal(obj.Bones.Count, newObj.Bones.Count);
        Assert.Equal(obj.Vertices.Count, newObj.Vertices.Count);
        Assert.Equal(obj.Faces.Count, newObj.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }

    [Fact]
    public void _3DCReadWriteEP6Test()
    {
        const string filePath = "Shaiya/3DC/pet_maddog.3DC";
        var obj = Reader.ReadFromFile<Parsec.Shaiya._3DC._3DC>(filePath);

        // Check original EFT values
        Assert.Equal(48, obj.Bones.Count);
        Assert.Equal(3274, obj.Vertices.Count);
        Assert.Equal(3078, obj.Faces.Count);
        Assert.Equal(Episode.EP6, obj.Episode);

        // Export to json
        const string jsonPath = "Shaiya/3DC/pet_maddog.3DC.json";
        obj.ExportJson(jsonPath);
        var objFromJson = Reader.ReadFromJson<Parsec.Shaiya._3DC._3DC>(jsonPath);

        // Check fields
        Assert.Equal(obj.Bones.Count, objFromJson.Bones.Count);
        Assert.Equal(obj.Vertices.Count, objFromJson.Vertices.Count);
        Assert.Equal(obj.Faces.Count, objFromJson.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        const string newObjPath = "Shaiya/3DC/pet_maddog.new.3DC";
        objFromJson.Write(newObjPath);

        var newObj = Reader.ReadFromFile<Parsec.Shaiya._3DC._3DC>(newObjPath);

        // Check fields
        Assert.Equal(obj.Bones.Count, newObj.Bones.Count);
        Assert.Equal(obj.Vertices.Count, newObj.Vertices.Count);
        Assert.Equal(obj.Faces.Count, newObj.Faces.Count);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }
}
