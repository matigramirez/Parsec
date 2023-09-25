namespace Parsec.Tests.Shaiya.Monster;

public class MonsterTests
{
    [Fact]
    public void MonsterCsvTest()
    {
        const string filePath = "Shaiya/Monster/Monster.SData";
        const string csvPath = "Shaiya/Monster/Monster.SData.csv";

        var monster = Reader.ReadFromFile<Parsec.Shaiya.Monster.Monster>(filePath);
        monster.WriteCsv(csvPath);
        var monsterFromCsv = Parsec.Shaiya.Monster.Monster.ReadFromCsv(csvPath);
        Assert.Equal(monster.GetBytes(), monsterFromCsv.GetBytes());
    }

    [Fact]
    public void MonsterCsv_EncodingTest()
    {
        const string filePath = "Shaiya/Monster/Monster_1252.SData";
        const string csvPath = "Shaiya/Monster/Monster_1252.SData.csv";

        var encoding = TestEncodings.Encoding1252;

        var monster = Reader.ReadFromFile<Parsec.Shaiya.Monster.Monster>(filePath, encoding: encoding);
        monster.WriteCsv(csvPath, encoding);
        var monsterFromCsv = Parsec.Shaiya.Monster.Monster.ReadFromCsv(csvPath, encoding);
        Assert.Equal(monster.GetBytes(), monsterFromCsv.GetBytes());
    }
}
