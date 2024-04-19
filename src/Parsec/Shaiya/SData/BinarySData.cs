using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using CsvHelper;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.NpcSkill;

namespace Parsec.Shaiya.SData;

public abstract class BinarySData<TRecord> : SData, ICsv where TRecord : IBinarySDataRecord, new()
{
    /// <summary>
    /// 128-byte header unused by the game itself. It looks like a file signature + metadata
    /// </summary>
    public byte[] Header { get; set; } = new byte[128];

    /// <summary>
    /// Field names are defined before the data. They aren't really used but knowing which each field means is nice
    /// </summary>
    public List<BinarySDataField> Fields { get; set; } = new();

    public List<TRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Header = binaryReader.ReadBytes(128);
        Fields = binaryReader.ReadList<BinarySDataField>().ToList();
        Records = binaryReader.ReadList<TRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        if (Header is not { Length: 128 })
        {
            Header = new byte[128];
        }

        binaryWriter.Write(Header);
        binaryWriter.Write(Fields.ToSerializable());
        binaryWriter.Write(Records.ToSerializable());
    }

    public static T FromCsv<T>(string csvPath, Encoding? encoding = null) where T : BinarySData<TRecord>, new()
    {
        encoding ??= Encoding.ASCII;
        using var reader = new StreamReader(csvPath, encoding);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

        // Read records
        var records = csvReader.GetRecords<TRecord>().ToList();

        if (csvReader.HeaderRecord == null)
        {
            throw new FileLoadException("Csv file doesn't have a valid header.");
        }

        // Read headers
        var fields = csvReader.HeaderRecord.Select(column => (BinarySDataField)column.ToLower()).ToList();
        var binarySData = new T { Fields = fields, Records = records, Encoding = encoding };
        return binarySData;
    }

    public void WriteCsv(string outputPath, Encoding? encoding = null)
    {
        encoding ??= Encoding;
        using var writer = new StreamWriter(outputPath, false, encoding);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }
}
