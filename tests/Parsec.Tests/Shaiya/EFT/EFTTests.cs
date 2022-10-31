namespace Parsec.Tests.Shaiya.EFT;

public class EftTests
{
    [Fact]
    public void EftReadWriteTest()
    {
        const string filePath = "Shaiya/EFT/Monster.EFT";
        var eft = Reader.ReadFromFile<Parsec.Shaiya.EFT.EFT>(filePath);

        // Check original EFT values
        Assert.Empty(eft.Objects);
        Assert.Equal(111, eft.Textures.Count);
        Assert.Equal(294, eft.Effects.Count);
        Assert.Empty(eft.EffectSequences);

        // Export to json
        const string jsonPath = "Shaiya/EFT/Monster.EFT.json";
        eft.ExportJson(jsonPath);
        var eftFromJson = Reader.ReadFromJson<Parsec.Shaiya.EFT.EFT>(jsonPath);

        // Check fields
        Assert.Equal(eft.Objects.Count, eftFromJson.Objects.Count);
        Assert.Equal(eft.Textures.Count, eftFromJson.Textures.Count);
        Assert.Equal(eft.Effects.Count, eftFromJson.Effects.Count);
        Assert.Equal(eft.EffectSequences.Count, eftFromJson.EffectSequences.Count);

        const string newEftPath = "Shaiya/EFT/Monster.new.EFT";
        eftFromJson.Write(newEftPath);

        var newEft = Reader.ReadFromFile<Parsec.Shaiya.EFT.EFT>(newEftPath);

        // Check fields
        Assert.Equal(eft.Objects.Count, newEft.Objects.Count);
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

        var eft = Reader.ReadFromFile<Parsec.Shaiya.EFT.EFT>(filePath);
        eft.Write(outputPath);
        eft.ExportJson(jsonPath);

        var outputEft = Reader.ReadFromFile<Parsec.Shaiya.EFT.EFT>(outputPath);
        var eftFromJson = Reader.ReadFromJson<Parsec.Shaiya.EFT.EFT>(jsonPath);

        // Check bytes
        Assert.Equal(eft.GetBytes(), outputEft.GetBytes());
        // Assert.Equal(eft.GetBytes(), eftFromJson.GetBytes());

        eftFromJson.Write(newObjPath);
        var newEft = Reader.ReadFromFile<Parsec.Shaiya.EFT.EFT>(newObjPath);

        // Since EFTs use different encodings on texts, the EFT -> JSON -> EFT conversion will modify the strings,
        // so a checksum can't be done here, that's why only list lengths will be compared
        Assert.Equal(eft.Objects.Count, newEft.Objects.Count);
        Assert.Equal(eft.Textures.Count, newEft.Textures.Count);
        Assert.Equal(eft.Effects.Count, newEft.Effects.Count);
        Assert.Equal(eft.EffectSequences.Count, newEft.EffectSequences.Count);
    }
}
