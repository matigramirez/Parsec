using Parsec.Attributes;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Shaiya.Core;
using ServiceStack;

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

    public void ExportCSV(string path)
    {
        string csv = Records.ToCsv();
        FileHelper.WriteFile(path, csv.GetBytes());
    }

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
                object value = Binary.ReadProperty(_binaryReader, typeof(TRecord), record, property);
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
                var propertyBytes = Binary.GetPropertyBytes(recordType, record, property);
                buffer.AddRange(propertyBytes);
            }
        }

        return buffer;
    }

    public static T ReadFromCSV<T>(string path) where T : BinarySData<TRecord>, new()
    {
        var records = File.ReadAllText(path).FromCsv<List<TRecord>>();
        var columnNames = CsvHelper.ReadColumnNames(path);
        var fields = columnNames.Select(c => new BinarySDataField(c.ToLower())).ToList();

        var binarySData = new T { Header = new byte[128], Fields = fields, Records = records };

        return binarySData;
    }
}
