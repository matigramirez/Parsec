using System.Linq;
using Parsec.Common;
using Parsec.Shaiya.NpcQuest;

namespace Parsec.Tests.Shaiya.NpcQuest;

public class NpcQuestTests
{
    [Fact]
    public void NpcQuestEp5Test()
    {
        const string filePath = "Shaiya/NpcQuest/NpcQuestEp5.SData";
        const string outputPath = "Shaiya/NpcQuest/NpcQuestEp5.output.SData";
        const string jsonPath = "Shaiya/NpcQuest/NpcQuestEp5.SData.json";
        var npcQuest = ParsecReader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(filePath);
        npcQuest.Write(outputPath, Episode.EP5);
        npcQuest.WriteJson(jsonPath);

        var outputNpcQuest = ParsecReader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(outputPath);
        var jsonNpcQuest = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.NpcQuest.NpcQuest>(jsonPath);

        var expected = npcQuest.GetBytes().ToList();
        Assert.Equal(expected, outputNpcQuest.GetBytes());
        Assert.Equal(expected, jsonNpcQuest.GetBytes());
    }

    [Fact]
    public void NpcQuestEp6Test()
    {
        const string filePath = "Shaiya/NpcQuest/NpcQuestEp6.SData";
        const string outputPath = "Shaiya/NpcQuest/NpcQuestEp6.output.SData";
        const string jsonPath = "Shaiya/NpcQuest/NpcQuestEp6.SData.json";
        var npcQuest = ParsecReader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(filePath, Episode.EP6);
        npcQuest.Write(outputPath, Episode.EP6);
        npcQuest.WriteJson(jsonPath);

        var outputNpcQuest = ParsecReader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(outputPath, Episode.EP6);
        var jsonNpcQuest = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.NpcQuest.NpcQuest>(jsonPath);

        var expected = npcQuest.GetBytes().ToList();
        Assert.Equal(expected, outputNpcQuest.GetBytes());
        Assert.Equal(expected, jsonNpcQuest.GetBytes());
    }

    [Fact]
    public void NpcQuestEp8Test()
    {
        const string filePath = "Shaiya/NpcQuest/NpcQuestEp8.SData";
        const string outputPath = "Shaiya/NpcQuest/NpcQuestEp8.output.SData";
        const string jsonPath = "Shaiya/NpcQuest/NpcQuestEp8.SData.json";
        var npcQuest = ParsecReader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(filePath, Episode.EP8);
        npcQuest.Write(outputPath, Episode.EP8);
        npcQuest.WriteJson(jsonPath);

        var outputNpcQuest = ParsecReader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(outputPath, Episode.EP8);
        var jsonNpcQuest = ParsecReader.ReadFromJsonFile<Parsec.Shaiya.NpcQuest.NpcQuest>(jsonPath);

        var expected = npcQuest.GetBytes().ToList();
        Assert.Equal(expected, outputNpcQuest.GetBytes());
        Assert.Equal(expected, jsonNpcQuest.GetBytes());
    }

    [Fact]
    public void NpcQuestTranslationTest()
    {
        const string filePath = "Shaiya/NpcQuest/NpcQuestTrans_USA.SData";
        const string outputPath = "Shaiya/NpcQuest/NpcQuestTrans_USA.output.SData";
        const string jsonPath = "Shaiya/NpcQuest/NpcQuestTrans_USA.SData.json";
        var npcQuest = ParsecReader.ReadFromFile<NpcQuestTrans>(filePath);
        npcQuest.Write(outputPath);
        npcQuest.WriteJson(jsonPath);

        var outputNpcQuest = ParsecReader.ReadFromFile<NpcQuestTrans>(outputPath);
        var jsonNpcQuest = ParsecReader.ReadFromJsonFile<NpcQuestTrans>(jsonPath);

        var expected = npcQuest.GetBytes().ToList();
        Assert.Equal(expected, outputNpcQuest.GetBytes());
        Assert.Equal(expected, jsonNpcQuest.GetBytes());
    }
}
