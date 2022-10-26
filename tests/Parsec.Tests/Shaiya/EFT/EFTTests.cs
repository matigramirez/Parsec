using Xunit;

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
}
