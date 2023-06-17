using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff;

public sealed class Seff : FileBase
{
    public int Format { get; set; }
    public TimeStamp TimeStamp;
    public List<Record> Records { get; } = new();

    [JsonIgnore]
    public override string Extension => "seff";

    public override void Read(params object[] options)
    {
        Format = _binaryReader.Read<int>();
        TimeStamp.Year = _binaryReader.Read<short>();
        TimeStamp.Month = _binaryReader.Read<short>();
        TimeStamp.Day = _binaryReader.Read<short>();
        TimeStamp.Hour = _binaryReader.Read<short>();
        TimeStamp.Minute = _binaryReader.Read<short>();
        TimeStamp.Second = _binaryReader.Read<short>();

        int recordCount = _binaryReader.Read<int>();
        for (int i = 0; i < recordCount; i++)
        {
            var record = new Record(_binaryReader, Format);
            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Format.GetBytes());
        buffer.AddRange(TimeStamp.Year.GetBytes());
        buffer.AddRange(TimeStamp.Month.GetBytes());
        buffer.AddRange(TimeStamp.Day.GetBytes());
        buffer.AddRange(TimeStamp.Hour.GetBytes());
        buffer.AddRange(TimeStamp.Minute.GetBytes());
        buffer.AddRange(TimeStamp.Second.GetBytes());

        buffer.AddRange(Records.Count.GetBytes());
        foreach (var effect in Records)
            buffer.AddRange(effect.GetBytes(Format));

        return buffer;
    }
}
