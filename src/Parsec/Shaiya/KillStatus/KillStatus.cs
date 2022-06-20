using System.Linq;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.KillStatus;

public class KillStatus : SData.SData, IJsonReadable
{
    public List<KillStatusRecord> Records { get; } = new();

    [JsonIgnore]
    public List<KillStatusRecord> LightRecords => Records.Where(r => r.Faction == FactionInt.Light).ToList();

    [JsonIgnore]
    public List<KillStatusRecord> FuryRecords => Records.Where(r => r.Faction == FactionInt.Fury).ToList();

    public override void Read(params object[] options)
    {
        var totalStatus = _binaryReader.Read<int>();

        for (int i = 0; i < totalStatus; i++)
        {
            var record = new KillStatusRecord(_binaryReader);
            Records.Add(record);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown) => Records.GetBytes();
}
