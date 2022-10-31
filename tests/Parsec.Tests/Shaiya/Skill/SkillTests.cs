using System.Linq;
using Parsec.Shaiya.Skill;

namespace Parsec.Tests.Shaiya.Skill;

public class SkillTests
{
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
        var jsonDbSkill = Reader.ReadFromJson<DBSkillData>(jsonPath);
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
        var jsonSkillText = Reader.ReadFromJson<DBSkillText>(jsonPath);
        var csvSkillText = DBSkillText.ReadFromCsv<DBSkillText>(csvPath);

        var expected = skillText.GetBytes().ToList();
        Assert.Equal(expected, outputSkillText.GetBytes());
        Assert.Equal(expected, jsonSkillText.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvSkillText.GetBytes().Skip(128));
    }
}
