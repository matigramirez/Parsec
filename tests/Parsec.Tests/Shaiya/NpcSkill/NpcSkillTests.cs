using System.Linq;
using Parsec.Shaiya.NpcSkill;

namespace Parsec.Tests.Shaiya.NpcSkill;

public class NpcSkillTests
{
    [Fact]
    public void DbSkillTest()
    {
        const string filePath = "Shaiya/NpcSkill/DBNpcSkillData.SData";
        const string outputPath = "Shaiya/NpcSkill/output_DBNpcSkillData.SData";
        const string jsonPath = "Shaiya/NpcSkill/DBNpcSkillData.SData.json";
        const string csvPath = "Shaiya/NpcSkill/DBNpcSkillData.SData.csv";

        var npcSkill = Reader.ReadFromFile<DBNpcSkillData>(filePath);
        npcSkill.Write(outputPath);
        npcSkill.ExportJson(jsonPath);
        npcSkill.ExportCsv(csvPath);

        var outputNpcSkill = Reader.ReadFromFile<DBNpcSkillData>(outputPath);
        var jsonNpcSkill = Reader.ReadFromJson<DBNpcSkillData>(jsonPath);
        var csvNpcSkill = DBNpcSkillData.ReadFromCsv<DBNpcSkillData>(csvPath);

        var expected = npcSkill.GetBytes().ToList();
        Assert.Equal(expected, outputNpcSkill.GetBytes());
        Assert.Equal(expected, jsonNpcSkill.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvNpcSkill.GetBytes().Skip(128));
    }

    [Fact]
    public void DbSkillTextTest()
    {
        const string filePath = "Shaiya/NpcSkill/DBNpcSkillText_USA.SData";
        const string outputPath = "Shaiya/NpcSkill/output_DBNpcSkillText_USA.SData";
        const string jsonPath = "Shaiya/NpcSkill/DBNpcSkillText_USA.SData.json";
        const string csvPath = "Shaiya/NpcSkill/DBNpcSkillText_USA.SData.csv";

        var npcSkillText = Reader.ReadFromFile<DBNpcSkillText>(filePath);
        npcSkillText.Write(outputPath);
        npcSkillText.ExportJson(jsonPath);
        npcSkillText.ExportCsv(csvPath);

        var outputNpcSkillText = Reader.ReadFromFile<DBNpcSkillText>(outputPath);
        var jsonNpcSkillText = Reader.ReadFromJson<DBNpcSkillText>(jsonPath);
        var csvNpcSkillText = DBNpcSkillText.ReadFromCsv<DBNpcSkillText>(csvPath);

        var expected = npcSkillText.GetBytes().ToList();
        Assert.Equal(expected, outputNpcSkillText.GetBytes());
        Assert.Equal(expected, jsonNpcSkillText.GetBytes());
        // For the csv check, skip the 128-byte header, which gets lost in the process
        Assert.Equal(expected.Skip(128), csvNpcSkillText.GetBytes().Skip(128));
    }
}
