using Parsec.Common;

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

    [Theory]
    [InlineData("Cloud.3DC")]
    [InlineData("co_huwf_helmet006.3DC")]
    [InlineData("Ctl_Hors_01.3DC")]
    [InlineData("ev_12CM_huwm.3DC")]
    [InlineData("humf_hand011.3DC")]
    [InlineData("M_A8B8_11_a01.3DC")]
    [InlineData("M_A8B8_29_a01.3DC")]
    [InlineData("Mob_Fox_01.3DC")]
    [InlineData("pet_maddog.3DC")]
    [InlineData("vehicle_El_06.3DC")]
    [InlineData("WhiteWing.3DC")]
    [InlineData("Wing_01.3DC")]
    public void _3DCMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/3DC/{fileName}";
        string jsonPath = $"Shaiya/3DC/{fileName}.json";
        string newObjPath = $"Shaiya/3DC/new_{fileName}";

        var obj = Reader.ReadFromFile<Parsec.Shaiya._3DC._3DC>(filePath);

        obj.ExportJson(jsonPath);
        var objFromJson = Reader.ReadFromJson<Parsec.Shaiya._3DC._3DC>(jsonPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), objFromJson.GetBytes());

        objFromJson.Write(newObjPath);
        var newObj = Reader.ReadFromFile<Parsec.Shaiya._3DC._3DC>(newObjPath);

        // Check bytes
        Assert.Equal(obj.GetBytes(), newObj.GetBytes());
    }
}
