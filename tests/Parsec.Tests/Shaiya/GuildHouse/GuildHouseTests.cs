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
        var guildHouse = Reader.ReadFromFile<Parsec.Shaiya.GuildHouse.GuildHouse>(filePath);
        guildHouse.Write(outputPath);
        guildHouse.ExportJson(jsonPath);

        var outputGuildHouse = Reader.ReadFromFile<Parsec.Shaiya.GuildHouse.GuildHouse>(outputPath);
        var jsonGuildHouse = Reader.ReadFromJsonFile<Parsec.Shaiya.GuildHouse.GuildHouse>(jsonPath);

        var expected = guildHouse.GetBytes().ToList();
        Assert.Equal(expected, outputGuildHouse.GetBytes());
        Assert.Equal(expected, jsonGuildHouse.GetBytes());
    }
}
