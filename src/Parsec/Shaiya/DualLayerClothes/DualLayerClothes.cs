using System.Text;
using Parsec.Common;
using Parsec.Serialization;
#if INCLUDE_CSV
using System.Globalization;
using CsvHelper;
#endif

namespace Parsec.Shaiya.DualLayerClothes;

public sealed class DualLayerClothes : SData.SData
#if INCLUDE_CSV
                                       , ICsv
#endif
{
    public List<DualLayerClothesRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Records = binaryReader.ReadList<DualLayerClothesRecord>();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Records);
    }

#if INCLUDE_CSV
    public static DualLayerClothes FromCsv(string csvPath, Encoding? encoding = null)
    {
        encoding ??= Encoding.ASCII;

        using var reader = new StreamReader(csvPath, encoding);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csvReader.GetRecords<DualLayerClothesRecord>().ToList();

        var dualLayerClothes = new DualLayerClothes
        {
            Records = records
        };

        return dualLayerClothes;
    }

    public void WriteCsv(string outputPath, Encoding? encoding = null)
    {
        encoding ??= Encoding;
        using var writer = new StreamWriter(outputPath, false, encoding);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(Records);
    }
#endif
}
