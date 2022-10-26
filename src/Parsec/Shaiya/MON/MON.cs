using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MON;

public sealed class MON : FileBase, IJsonReadable
{
    /// <summary>
    /// File signature. "MO2", "MO4". Read as char[3]
    /// </summary>
    public string Signature { get; set; }

    public MONFormat Format { get; set; } = MONFormat.MO2;

    public List<MONRecord> Records { get; } = new();

    public override string Extension => "MON";

    public override void Read(params object[] options)
    {
        Signature = _binaryReader.ReadString(3);

        switch (Signature)
        {
            case "MO2":
            default:
                Format = MONFormat.MO2;
                break;
            case "MO4":
                Format = MONFormat.MO4;
                break;
        }

        var recordCount = _binaryReader.Read<int>();

        for (int i = 0; i < recordCount; i++)
        {
            var record = new MONRecord(_binaryReader, Format);
            Records.Add(record);
        }
    }

    // TODO: This method needs attention because the MON format doesn't depend on the episode itself, sometimes MO2 and MO4 are mixed within the same client
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var outputFormat = Format;

        if (options.Length > 0)
            outputFormat = (MONFormat)options[0];

        var buffer = new List<byte>();
        buffer.AddRange(outputFormat.ToString().GetBytes());

        buffer.AddRange(Records.Count.GetBytes());

        foreach (var record in Records)
            buffer.AddRange(record.GetBytes(outputFormat));

        return buffer;
    }
}
