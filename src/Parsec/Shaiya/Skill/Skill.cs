using System.Globalization;
using System.Text;
using CsvHelper;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.Skill;

public sealed class Skill : SData.SData, ICsv
{
    public List<SkillGroup> SkillGroups { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        var skillGroupCount = binaryReader.ReadInt32();

        for (var skillGroupId = 0; skillGroupId < skillGroupCount; skillGroupId++)
        {
            binaryReader.SerializationOptions.ExtraOption = skillGroupId;
            var skillGroup = binaryReader.Read<SkillGroup>();
            SkillGroups.Add(skillGroup);
        }
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(SkillGroups.ToSerializable());
    }

    public static Skill ReadFromCsv(string csvFilePath, Episode episode = Episode.EP5, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;

        using var reader = new StreamReader(csvFilePath, encoding);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var skillRecords = csvReader.GetRecords<SkillDefinition>().ToList();

        var groupedSkillRecords = skillRecords.GroupBy(x => x.SkillId);
        var skill = new Skill { Episode = episode, Encoding = encoding };

        foreach (var groupedSkills in groupedSkillRecords)
        {
            var skillGroup = new SkillGroup { SkillDefinitions = groupedSkills.ToList() };
            skill.SkillGroups.Add(skillGroup);
        }

        return skill;
    }

    public void WriteCsv(string outputPath, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;
        using var writer = new StreamWriter(outputPath, false, encoding);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        foreach (var skillGroup in SkillGroups)
        {
            csvWriter.WriteRecords(skillGroup.SkillDefinitions);
        }
    }
}
