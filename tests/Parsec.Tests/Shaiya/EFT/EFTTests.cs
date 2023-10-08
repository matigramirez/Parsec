namespace Parsec.Tests.Shaiya.EFT;

public class EftTests
{
    [Fact]
    public void EftReadWriteTest()
    {
        const string filePath = "Shaiya/EFT/Monster.EFT";
        var eft = ParsecReader.ReadFromFile<Parsec.Shaiya.Eft.Eft>(filePath);

        // Check original EFT values
        Assert.Empty(eft.Meshes);
        Assert.Equal(111, eft.Textures.Count);
        Assert.Equal(294, eft.Effects.Count);
        Assert.Empty(eft.EffectSequences);

        // Export to json
        const string jsonPath = "Shaiya/EFT/Monster.EFT.json";
        eft.WriteJson(jsonPath);
        var eftFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.Eft.Eft>(jsonPath);

        // Check fields
        Assert.Equal(eft.Meshes.Count, eftFromJson.Meshes.Count);
        Assert.Equal(eft.Textures.Count, eftFromJson.Textures.Count);
        Assert.Equal(eft.Effects.Count, eftFromJson.Effects.Count);
        Assert.Equal(eft.EffectSequences.Count, eftFromJson.EffectSequences.Count);

        const string newEftPath = "Shaiya/EFT/Monster.new.EFT";
        eftFromJson.Write(newEftPath);

        var newEft = ParsecReader.ReadFromFile<Parsec.Shaiya.Eft.Eft>(newEftPath);

        // Check fields
        Assert.Equal(eft.Meshes.Count, newEft.Meshes.Count);
        Assert.Equal(eft.Textures.Count, newEft.Textures.Count);
        Assert.Equal(eft.Effects.Count, newEft.Effects.Count);
        Assert.Equal(eft.EffectSequences.Count, newEft.EffectSequences.Count);
    }

    [Theory]
    [InlineData("1hellTooth01.EFT")]
    [InlineData("4dragon_att02.EFT")]
    [InlineData("CA_magic.EFT")]
    [InlineData("CA_tyro_spear.EFT")]
    [InlineData("completerestore.EFT")]
    [InlineData("DA_area_Mwind.EFT")]
    [InlineData("DA_target_cqguard.EFT")]
    [InlineData("da_tyro_type2_backflyingswordforce.EFT")]
    [InlineData("in_tyro_type2_93_satellitesupport.EFT")]
    [InlineData("levelup.EFT")]
    [InlineData("M_A8B8_05_a01_die.EFT")]
    [InlineData("Monster.EFT")]
    [InlineData("Pet_Gold.EFT")]
    [InlineData("point.EFT")]
    [InlineData("portal.EFT")]
    public void EftMultipleReadWriteTest(string fileName)
    {
        string filePath = $"Shaiya/EFT/{fileName}";
        string outputPath = $"Shaiya/EFT/output_{fileName}";
        string jsonPath = $"Shaiya/EFT/{fileName}.json";
        string newObjPath = $"Shaiya/EFT/new_{fileName}";

        var eft = ParsecReader.ReadFromFile<Parsec.Shaiya.Eft.Eft>(filePath);
        eft.Write(outputPath);
        eft.WriteJson(jsonPath);

        var outputEft = ParsecReader.ReadFromFile<Parsec.Shaiya.Eft.Eft>(outputPath);
        var eftFromJson = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.Eft.Eft>(jsonPath);

        // Check bytes
        Assert.Equal(eft.GetBytes(), outputEft.GetBytes());
        // Assert.Equal(eft.GetBytes(), eftFromJson.GetBytes());

        eftFromJson.Write(newObjPath);
        var newEft = ParsecReader.ReadFromFile<Parsec.Shaiya.Eft.Eft>(newObjPath);

        // Since EFTs use different encodings on texts, the EFT -> JSON -> EFT conversion will modify the strings,
        // so a checksum can't be done here, that's why only list lengths will be compared
        Assert.Equal(eft.Meshes.Count, newEft.Meshes.Count);
        Assert.Equal(eft.Textures.Count, newEft.Textures.Count);
        Assert.Equal(eft.Effects.Count, newEft.Effects.Count);
        Assert.Equal(eft.EffectSequences.Count, newEft.EffectSequences.Count);
    }
}
