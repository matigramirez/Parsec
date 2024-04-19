using System.Globalization;
using System.Text;
using CsvHelper;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.Monster;

public sealed class Monster : SData.SData, ICsv
{
    public List<MonsterRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Records = binaryReader.ReadList<MonsterRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Records.ToSerializable());
    }

    /// <summary>
    /// Reads the Monster.SData format from a csv file
    /// </summary>
    /// <param name="csvPath">csv file path</param>
    /// <param name="encoding">File encoding</param>
    /// <returns><see cref="Monster"/> instance</returns>
    public static Monster FromCsv(string csvPath, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;

        // Read all monster definitions from csv file
        using var reader = new StreamReader(csvPath, encoding);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csvReader.GetRecords<MonsterRecord>().ToList();

        // Create monster instance
        var monster = new Monster { Records = records, Encoding = encoding };
        return monster;
    }

    public void WriteCsv(string outputPath, Encoding? encoding = null)
    {
        encoding ??= Encoding;
        using var writer = new StreamWriter(outputPath, false, encoding);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }
}
