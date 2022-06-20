using System.IO;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using ServiceStack;

namespace Parsec.Shaiya.Monster;

public class Monster : SData.SData, ICsv
{
    public List<MonsterRecord> Records { get; } = new();

    public override string Extension => "SData";

    [JsonConstructor]
    public Monster()
    {
    }

    public Monster(List<MonsterRecord> records)
    {
        Records = records;
    }

    public override void Read(params object[] options)
    {
        var recordCount = _binaryReader.Read<int>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new MonsterRecord(_binaryReader);
            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown) => Records.GetBytes();

    public void ExportCSV(string path)
    {
        var csv = Records.ToCsv();
        FileHelper.WriteFile(path, csv.GetBytes());
    }

    /// <summary>
    /// Reads the Monster.SData format from a csv file
    /// </summary>
    /// <param name="path">csv file path</param>
    /// <returns><see cref="Monster"/> instance</returns>
    public static Monster ReadFromCSV(string path)
    {
        // Read all monster definitions from csv file
        var monsterRecords = File.ReadAllText(path).FromCsv<List<MonsterRecord>>();

        // Create monster instance
        var monster = new Monster(monsterRecords);
        return monster;
    }
}
