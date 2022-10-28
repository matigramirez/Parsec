using Xunit;

namespace Parsec.Tests.Shaiya.Monster;

public class MonsterTests
{
    [Fact]
    public void MonsterCsvTest()
    {
        const string filePath = "Shaiya/Monster/Monster.SData";
        const string csvPath = "Shaiya/Monster/Monster.SData.csv";

        var monster = Reader.ReadFromFile<Parsec.Shaiya.Monster.Monster>(filePath);
        monster.ExportCsv(csvPath);
        var monsterFromCsv = Parsec.Shaiya.Monster.Monster.ReadFromCsv(csvPath);
        Assert.Equal(monster.GetBytes(), monsterFromCsv.GetBytes());
    }
}
