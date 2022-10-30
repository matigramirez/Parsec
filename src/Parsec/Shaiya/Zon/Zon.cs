using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Zon;

public sealed class Zon : FileBase
{
    public int Format { get; set; }
    public List<ZonRecord> Records { get; } = new();

    public override string Extension => "zon";

    public override void Read(params object[] options)
    {
        Format = _binaryReader.Read<int>();

        int recordCount = _binaryReader.Read<int>();
        for (int i = 0; i < recordCount; i++)
            Records.Add(new ZonRecord(Format, _binaryReader));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Format.GetBytes());

        buffer.AddRange(Records.Count.GetBytes());
        foreach (var record in Records)
            buffer.AddRange(record.GetBytes(Format));

        return buffer;
    }
}
