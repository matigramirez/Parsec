namespace Parsec.Tests.Shaiya.SMOD;

public class SmodTests
{
    [Fact]
    public void SmodReadWriteTest()
    {
        const string filePath = "Shaiya/SMOD/a2_Elf_House_01.SMOD";
        var smod = ParsecReader.ReadFromFile<Parsec.Shaiya.Smod.Smod>(filePath);

        // Check original EFT values
        Assert.Single(smod.CollisionObjects);
        Assert.Equal(12, smod.TexturedObjects.Count);

        // Export to json
        const string jsonPath = "Shaiya/SMOD/a2_Elf_House_01.SMOD.json";
        smod.WriteJson(jsonPath);
        var smodFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.Smod.Smod>(jsonPath);

        // Check fields
        Assert.Equal(smod.CollisionObjects.Count, smodFromJson.CollisionObjects.Count);
        Assert.Equal(smod.TexturedObjects.Count, smodFromJson.TexturedObjects.Count);

        // Check bytes
        Assert.Equal(smod.GetBytes(), smodFromJson.GetBytes());

        const string newObjPath = "Shaiya/SMOD/a2_Elf_House_01.new.SMOD";
        smodFromJson.Write(newObjPath);

        var newSmod = ParsecReader.ReadFromFile<Parsec.Shaiya.Smod.Smod>(newObjPath);

        // Check fields
        Assert.Equal(smod.CollisionObjects.Count, newSmod.CollisionObjects.Count);
        Assert.Equal(smod.TexturedObjects.Count, newSmod.TexturedObjects.Count);

        // Check bytes
        Assert.Equal(smod.GetBytes(), newSmod.GetBytes());
    }

    [Theory]
    [InlineData("A1_Elf_Tree02.SMOD")]
    [InlineData("A1_Goblinstone01.SMOD")]
    [InlineData("A2_Dolmen_06.SMOD")]
    [InlineData("a2_Elf_House_01.SMOD")]
    [InlineData("A2_SS_stone01.SMOD")]
    [InlineData("A7_QueenEggSto.SMOD")]
    [InlineData("b1_checkpoint_Ladder.SMOD")]
    [InlineData("GuardTower_Ladder_New.SMOD")]
    [InlineData("R1_Dun1_Skeleton02.SMOD")]
    [InlineData("R1_TallerPlant.SMOD")]
    public void SmodMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/SMOD/{fileName}";
        string jsonPath = $"Shaiya/SMOD/{fileName}.json";
        string newObjPath = $"Shaiya/SMOD/new_{fileName}";

        var smod = ParsecReader.ReadFromFile<Parsec.Shaiya.Smod.Smod>(filePath);
        smod.WriteJson(jsonPath);
        var smodFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.Smod.Smod>(jsonPath);

        // Check bytes
        Assert.Equal(smod.GetBytes(), smodFromJson.GetBytes());

        smodFromJson.Write(newObjPath);
        var newSmod = ParsecReader.ReadFromFile<Parsec.Shaiya.Smod.Smod>(newObjPath);

        // Check bytes
        Assert.Equal(smod.GetBytes(), newSmod.GetBytes());
    }
}
