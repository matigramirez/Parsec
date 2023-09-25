using System.Globalization;
using CsvHelper;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.Skill;

public sealed class Skill : SData.SData
{
    public List<SkillRecord> Records { get; set; } = new();

    public override void Read(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
        {
            episode = (Episode)options[0];
        }

        var skillCount = _binaryReader.Read<int>();
        var recordCountPerSkill = GetRecordCountPerSkill(episode);

        for (int skillId = 0; skillId < skillCount; skillId++)
        {
            for (int i = 0; i < recordCountPerSkill; i++)
            {
                var record = new SkillRecord(_binaryReader, episode, skillId);
                Records.Add(record);
            }
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        if (episode == Episode.Unknown)
        {
            episode = Episode.EP5;
        }

        var buffer = new List<byte>();

        var skillCount = Records.Count / GetRecordCountPerSkill(episode);
        buffer.AddRange(skillCount.GetBytes());

        foreach (var record in Records)
        {
            buffer.AddRange(record.GetBytes(episode));
        }

        return buffer.ToArray();
    }

    private int GetRecordCountPerSkill(Episode episode)
    {
        return episode switch
        {
            Episode.EP5 => 9,
            >= Episode.EP6 => 15,
            _ => 3
        };
    }

    public void ExportCsv(string outputPath)
    {
        using var writer = new StreamWriter(outputPath);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }

    /// <summary>
    /// Reads the Skill.SData format from a csv file
    /// </summary>
    /// <param name="csvPath">csv file path</param>
    /// <param name="episode">File episode</param>
    /// <returns><see cref="Skill"/> instance</returns>
    public static Skill ReadFromCsv(string csvPath, Episode episode)
    {
        // Read all skill definitions from csv file
        using var reader = new StreamReader(csvPath);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csvReader.GetRecords<SkillRecord>().ToList();

        // Create skill instance
        var skill = new Skill { Episode = episode, Records = records };
        return skill;
    }
}
