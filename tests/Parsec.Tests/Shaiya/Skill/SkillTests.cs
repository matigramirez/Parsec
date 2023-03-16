using System.Linq;
using Parsec.Common;
using Parsec.Shaiya.Skill;

namespace Parsec.Tests.Shaiya.Skill;

public class SkillTests
{
    [Theory]
    [InlineData("SkillEp5", Episode.EP5)]
    [InlineData("SkillEp6", Episode.EP6)]
    public void SkillTest(string fileName, Episode episode)
    {
        string filePath = $"Shaiya/Skill/{fileName}.SData";
        string outputPath = $"Shaiya/Skill/output_{fileName}.SData";
        string jsonPath = $"Shaiya/Skill/{fileName}.SData.json";
        string csvPath = $"Shaiya/Skill/{fileName}.SData.csv";

        var skill = Reader.ReadFromFile<Parsec.Shaiya.Skill.Skill>(filePath, episode);
        skill.Write(outputPath, episode);
        skill.ExportJson(jsonPath);
        skill.ExportCsv(csvPath);

        var outputSkill = Reader.ReadFromFile<Parsec.Shaiya.Skill.Skill>(outputPath, episode);
        var jsonSkill = Reader.ReadFromJsonFile<Parsec.Shaiya.Skill.Skill>(jsonPath);
        var csvSkill = Parsec.Shaiya.Skill.Skill.ReadFromCsv(csvPath, episode);

        var expected = skill.GetBytes().ToList();
        Assert.Equal(expected, outputSkill.GetBytes());
        Assert.Equal(expected, jsonSkill.GetBytes());
        Assert.Equal(expected, csvSkill.GetBytes());
    }

    [Fact]
    public void DbSkillTest()
    {
        const string filePath = "Shaiya/Skill/DBSkillData.SData";
        const string outputPath = "Shaiya/Skill/output_DBSkillData.SData";
        const string jsonPath = "Shaiya/Skill/DBSkillData.SData.json";
        const string csvPath = "Shaiya/Skill/DBSkillData.SData.csv";

        var dbSkill = Reader.ReadFromFile<DBSkillData>(filePath);
        dbSkill.Write(outputPath);
        dbSkill.ExportJson(jsonPath);
        dbSkill.ExportCsv(csvPath);

        var outputDbSkill = Reader.ReadFromFile<DBSkillData>(outputPath);
        var jsonDbSkill = Reader.ReadFromJsonFile<DBSkillData>(jsonPath);
        var csvSkill = DBSkillData.ReadFromCsv<DBSkillData>(csvPath);

        var expected = dbSkill.GetBytes().ToList();
        Assert.Equal(expected, outputDbSkill.GetBytes());
        Assert.Equal(expected, jsonDbSkill.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvSkill.GetBytes().Skip(128));
    }

    [Fact]
    public void DbSkillTextTest()
    {
        const string filePath = "Shaiya/Skill/DBSkillText_USA.SData";
        const string outputPath = "Shaiya/Skill/output_DBSkillText_USA.SData";
        const string jsonPath = "Shaiya/Skill/DBSkillText_USA.SData.json";
        const string csvPath = "Shaiya/Skill/DBSkillText_USA.SData.csv";

        var skillText = Reader.ReadFromFile<DBSkillText>(filePath);
        skillText.Write(outputPath);
        skillText.ExportJson(jsonPath);
        skillText.ExportCsv(csvPath);

        var outputSkillText = Reader.ReadFromFile<DBSkillText>(outputPath);
        var jsonSkillText = Reader.ReadFromJsonFile<DBSkillText>(jsonPath);
        var csvSkillText = DBSkillText.ReadFromCsv<DBSkillText>(csvPath);

        var expected = skillText.GetBytes().ToList();
        Assert.Equal(expected, outputSkillText.GetBytes());
        Assert.Equal(expected, jsonSkillText.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvSkillText.GetBytes().Skip(128));
    }
}
