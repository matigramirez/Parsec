using Parsec.Shaiya.EFT;
using Xunit;

namespace Parsec.Tests.Shaiya;

public class EFTTests
{
    [Fact]
    public void Test1()
    {
        var eft = Reader.ReadFromFile<EFT>("Shaiya/EFT/Monster.EFT");
        
        // Check original EFT values
        Assert.Empty(eft.Objects);
        Assert.Equal(111, eft.Textures.Count);
        Assert.Equal(294, eft.Effects.Count);
        Assert.Empty(eft.EffectSequences);
        
        // Export to json
        const string jsonPath = "Shaiya/EFT/Monster.EFT.json";
        eft.ExportJson(jsonPath);
        var eftFromJson = Reader.ReadFromJson<EFT>(jsonPath);
        
        // Check json files
        Assert.Equal(eft.Objects.Count, eftFromJson.Objects.Count);
        Assert.Equal(eft.Textures.Count, eftFromJson.Textures.Count);
        Assert.Equal(eft.Effects.Count, eftFromJson.Effects.Count);
        Assert.Equal(eft.EffectSequences.Count, eftFromJson.EffectSequences.Count);
        
        // Check bytes
        Assert.Equal(eft.GetBytes(), eftFromJson.GetBytes());
    }
}
