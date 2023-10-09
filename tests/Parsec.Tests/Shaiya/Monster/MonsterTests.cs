using System.Linq;
using Parsec.Shaiya.Monster;

namespace Parsec.Tests.Shaiya.Monster;

public class MonsterTests
{
    [Fact]
    public void MonsterCsvTest()
    {
        const string filePath = "Shaiya/Monster/Monster.SData";
        const string csvPath = "Shaiya/Monster/Monster.SData.csv";

        var monster = ParsecReader.FromFile<Parsec.Shaiya.Monster.Monster>(filePath);
        monster.WriteCsv(csvPath);
        var monsterFromCsv = Parsec.Shaiya.Monster.Monster.FromCsv(csvPath);
        Assert.Equal(monster.GetBytes(), monsterFromCsv.GetBytes());
    }

    [Fact]
    public void MonsterCsv_EncodingTest()
    {
        const string filePath = "Shaiya/Monster/Monster_1252.SData";
        const string csvPath = "Shaiya/Monster/Monster_1252.SData.csv";

        var encoding = TestEncodings.Encoding1252;

        var monster = ParsecReader.FromFile<Parsec.Shaiya.Monster.Monster>(filePath, encoding: encoding);
        monster.WriteCsv(csvPath, encoding);
        var monsterFromCsv = Parsec.Shaiya.Monster.Monster.FromCsv(csvPath, encoding);
        Assert.Equal(monster.GetBytes(), monsterFromCsv.GetBytes());
    }

    [Fact]
    public void DbMonsterTest()
    {
        const string filePath = "Shaiya/Monster/DBMonsterData.SData";
        const string outputPath = "Shaiya/Monster/output_DBMonsterData.SData";
        const string jsonPath = "Shaiya/Monster/DBMonsterData.SData.json";
        const string csvPath = "Shaiya/Monster/DBMonsterData.SData.csv";

        var dbMonster = ParsecReader.FromFile<DBMonsterData>(filePath);
        dbMonster.Write(outputPath);
        dbMonster.WriteJson(jsonPath);
        dbMonster.WriteCsv(csvPath);

        var outputDbMonster = ParsecReader.FromFile<DBMonsterData>(outputPath);
        var jsonDbMonster = ParsecReader.FromJsonFile<DBMonsterData>(jsonPath);
        var csvMonster = DBMonsterData.FromCsv<DBMonsterData>(csvPath);

        var expected = dbMonster.GetBytes().ToList();
        Assert.Equal(expected, outputDbMonster.GetBytes());
        Assert.Equal(expected, jsonDbMonster.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvMonster.GetBytes().Skip(128));
    }

    [Fact]
    public void DbMonsterTextTest()
    {
        const string filePath = "Shaiya/Monster/DBMonsterText_USA.SData";
        const string outputPath = "Shaiya/Monster/output_DBMonsterText_USA.SData";
        const string jsonPath = "Shaiya/Monster/DBMonsterText_USA.SData.json";
        const string csvPath = "Shaiya/Monster/DBMonsterText_USA.SData.csv";

        var monsterText = ParsecReader.FromFile<DBMonsterText>(filePath);
        monsterText.Write(outputPath);
        monsterText.WriteJson(jsonPath);
        monsterText.WriteCsv(csvPath);

        var outputMonsterText = ParsecReader.FromFile<DBMonsterText>(outputPath);
        var jsonMonsterText = ParsecReader.FromJsonFile<DBMonsterText>(jsonPath);
        var csvMonsterText = DBMonsterText.FromCsv<DBMonsterText>(csvPath);

        var expected = monsterText.GetBytes().ToList();
        Assert.Equal(expected, outputMonsterText.GetBytes());
        Assert.Equal(expected, jsonMonsterText.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvMonsterText.GetBytes().Skip(128));
    }
}
