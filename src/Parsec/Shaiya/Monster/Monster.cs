using System.Globalization;
using System.Text;
using CsvHelper;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.Monster;

public sealed class Monster : SData.SData, ICsv
{
    [JsonConstructor]
    public Monster()
    {
    }

    public Monster(List<MonsterRecord> records)
    {
        Records = records;
    }

    public List<MonsterRecord> Records { get; } = new();

    public override string Extension => "SData";

    public override void Read()
    {
        int recordCount = _binaryReader.Read<int>();
        for (int i = 0; i < recordCount; i++)
        {
            var record = new MonsterRecord(_binaryReader, Encoding);
            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown) => Records.GetBytes();

    /// <summary>
    /// Reads the Monster.SData format from a csv file
    /// </summary>
    /// <param name="csvPath">csv file path</param>
    /// <param name="encoding">File encoding</param>
    /// <returns><see cref="Monster"/> instance</returns>
    public static Monster ReadFromCsv(string csvPath, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;

        // Read all monster definitions from csv file
        using var reader = new StreamReader(csvPath, encoding);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csvReader.GetRecords<MonsterRecord>().ToList();

        // Create monster instance
        var monster = new Monster(records) { Encoding = encoding };
        return monster;
    }

    public void WriteCsv(string outputPath, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;
        using var writer = new StreamWriter(outputPath, false, encoding);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }
}
