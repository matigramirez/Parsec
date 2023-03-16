using System.Linq;
using Parsec.Common;

namespace Parsec.Tests.Shaiya.NpcQuest;

public class NpcQuestTests
{
    [Fact]
    public void NpcQuestEp5Test()
    {
        const string filePath = "Shaiya/NpcQuest/NpcQuestEp5.SData";
        const string outputPath = "Shaiya/NpcQuest/NpcQuestEp5.output.SData";
        const string jsonPath = "Shaiya/NpcQuest/NpcQuestEp5.SData.json";
        var npcQuest = Reader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(filePath, Episode.EP5);
        npcQuest.Write(outputPath, Episode.EP5);
        npcQuest.ExportJson(jsonPath);

        var outputNpcQuest = Reader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(outputPath, Episode.EP5);
        var jsonNpcQuest = Reader.ReadFromJsonFile<Parsec.Shaiya.NpcQuest.NpcQuest>(jsonPath);

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
        var npcQuest = Reader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(filePath, Episode.EP6);
        npcQuest.Write(outputPath, Episode.EP6);
        npcQuest.ExportJson(jsonPath);

        var outputNpcQuest = Reader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(outputPath, Episode.EP6);
        var jsonNpcQuest = Reader.ReadFromJsonFile<Parsec.Shaiya.NpcQuest.NpcQuest>(jsonPath);

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
        var npcQuest = Reader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(filePath, Episode.EP8);
        npcQuest.Write(outputPath, Episode.EP8);
        npcQuest.ExportJson(jsonPath);

        var outputNpcQuest = Reader.ReadFromFile<Parsec.Shaiya.NpcQuest.NpcQuest>(outputPath, Episode.EP8);
        var jsonNpcQuest = Reader.ReadFromJsonFile<Parsec.Shaiya.NpcQuest.NpcQuest>(jsonPath);

        var expected = npcQuest.GetBytes().ToList();
        Assert.Equal(expected, outputNpcQuest.GetBytes());
        Assert.Equal(expected, jsonNpcQuest.GetBytes());
    }
}
