using System.Linq;

namespace Parsec.Tests.Shaiya.GuildHouse;

public class GuildHouseTests
{
    [Fact]
    public void GuildHouseTest()
    {
        const string filePath = "Shaiya/GuildHouse/GuildHouse.SData";
        const string outputPath = "Shaiya/GuildHouse/GuildHouse.output.SData";
        const string jsonPath = "Shaiya/GuildHouse/GuildHouse.SData.json";
        var npcQuest = Reader.ReadFromFile<Parsec.Shaiya.GuildHouse.GuildHouse>(filePath);
        npcQuest.Write(outputPath);
        npcQuest.ExportJson(jsonPath);

        var outputNpcQuest = Reader.ReadFromFile<Parsec.Shaiya.GuildHouse.GuildHouse>(outputPath);
        var jsonNpcQuest = Reader.ReadFromJsonFile<Parsec.Shaiya.GuildHouse.GuildHouse>(jsonPath);

        var expected = npcQuest.GetBytes().ToList();
        Assert.Equal(expected, outputNpcQuest.GetBytes());
        Assert.Equal(expected, jsonNpcQuest.GetBytes());
    }
}
