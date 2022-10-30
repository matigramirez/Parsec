using System.Globalization;
using CsvHelper;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SData;

public abstract class BinarySData<TRecord> : SData, ICsv where TRecord : IBinarySDataRecord, new()
{
    /// <summary>
    /// 128-byte header unused by the game itself. It looks like a file signature + metadata
    /// </summary>
    [ShaiyaProperty]
    public byte[] Header { get; set; }

    /// <summary>
    /// Field names are defined before the data. They aren't really used but knowing which each field means is nice
    /// </summary>
    [ShaiyaProperty]
    public List<BinarySDataField> Fields { get; set; } = new();

    [ShaiyaProperty]
    public List<TRecord> Records { get; set; } = new();

    public override void Read(params object[] options)
    {
        Header = _binaryReader.ReadBytes(128);
        int fieldCount = _binaryReader.Read<int>();

        for (int i = 0; i < fieldCount; i++)
            Fields.Add(new BinarySDataField(_binaryReader));

        int recordCount = _binaryReader.Read<int>();

        for (int i = 0; i < recordCount; i++)
        {
            var recordType = typeof(TRecord);
            var record = Activator.CreateInstance<TRecord>();

            foreach (var property in recordType.GetProperties())
            {
                object value = ReflectionHelper.ReadProperty(_binaryReader, typeof(TRecord), record, property);
                property.SetValue(record, value);
            }

            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Header);
        buffer.AddRange(Fields.GetBytes());

        buffer.AddRange(Records.Count.GetBytes());

        var recordType = typeof(TRecord);

        foreach (var record in Records)
        {
            foreach (var property in recordType.GetProperties())
            {
                var propertyBytes = ReflectionHelper.GetPropertyBytes(recordType, record, property, Encoding, episode);
                buffer.AddRange(propertyBytes);
            }
        }

        return buffer;
    }

    public static T ReadFromCsv<T>(string csvPath) where T : BinarySData<TRecord>, new()
    {
        using var reader = new StreamReader(csvPath);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

        // Read headers and records
        var records = csvReader.GetRecords<TRecord>().ToList();
        var fields = csvReader.HeaderRecord?.Select(c => new BinarySDataField(c.ToLower())).ToList();

        // Create the BinarySData instance with an empty header. The header is skipped entirely by the game so this isn't an issue.
        var binarySData = new T { Header = new byte[128], Fields = fields, Records = records };
        return binarySData;
    }

    public void ExportCsv(string outputPath)
    {
        using var writer = new StreamWriter(outputPath);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }
}
