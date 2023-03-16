using System.Globalization;
using CsvHelper;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Skill;

namespace Parsec.Shaiya.NpcSkill;

[DefaultVersion(Episode.EP5)]
public sealed class NpcSkill : SData.SData
{
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(SkillRecord))]
    [ListLengthMultiplier(Episode.EP4, 3)]
    [ListLengthMultiplier(Episode.EP5, 9)]
    [ListLengthMultiplier(Episode.EP6, 15)]
    public List<SkillRecord> Records { get; set; } = new();

    public void ExportCsv(string outputPath)
    {
        using var writer = new StreamWriter(outputPath);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }

    /// <summary>
    /// Reads the NpcSkill.SData format from a csv file
    /// </summary>
    /// <param name="csvPath">csv file path</param>
    /// <param name="episode">File episode</param>
    /// <returns><see cref="Skill"/> instance</returns>
    public static NpcSkill ReadFromCsv(string csvPath, Episode episode)
    {
        // Read all skill definitions from csv file
        using var reader = new StreamReader(csvPath);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csvReader.GetRecords<SkillRecord>().ToList();

        // Create npcSkill instance
        var npcSkill = new NpcSkill { Episode = episode, Records = records };
        return npcSkill;
    }
}
