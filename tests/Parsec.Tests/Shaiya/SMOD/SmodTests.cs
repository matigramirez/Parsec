using Xunit;

namespace Parsec.Tests.Shaiya.SMOD;

public class SmodTests
{
    [Fact]
    public void SmodReadWriteTest()
    {
        const string filePath = "Shaiya/SMOD/a2_Elf_House_01.SMOD";
        var smod = Reader.ReadFromFile<Parsec.Shaiya.SMOD.SMOD>(filePath);

        // Check original EFT values
        Assert.Single(smod.CollisionObjects);
        Assert.Equal(12, smod.TexturedObjects.Count);

        // Export to json
        const string jsonPath = "Shaiya/SMOD/a2_Elf_House_01.SMOD.json";
        smod.ExportJson(jsonPath);
        var smodFromJson = Reader.ReadFromJson<Parsec.Shaiya.SMOD.SMOD>(jsonPath);

        // Check fields
        Assert.Equal(smod.CollisionObjects.Count, smodFromJson.CollisionObjects.Count);
        Assert.Equal(smod.TexturedObjects.Count, smodFromJson.TexturedObjects.Count);

        // Check bytes
        Assert.Equal(smod.GetBytes(), smodFromJson.GetBytes());

        const string newObjPath = "Shaiya/SMOD/a2_Elf_House_01.new.SMOD";
        smodFromJson.Write(newObjPath);

        var newSmod = Reader.ReadFromFile<Parsec.Shaiya.SMOD.SMOD>(newObjPath);

        // Check fields
        Assert.Equal(smod.CollisionObjects.Count, newSmod.CollisionObjects.Count);
        Assert.Equal(smod.TexturedObjects.Count, newSmod.TexturedObjects.Count);

        // Check bytes
        Assert.Equal(smod.GetBytes(), newSmod.GetBytes());
    }
}
