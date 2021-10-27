using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.KILLSTATUS
{
    public class KillStatus : FileBase
    {
        [JsonIgnore]
        public int TotalStatus { get; set; }
        public List<KillStatusRecord> Records { get; } = new();
        [JsonIgnore]
        public List<KillStatusRecord> LightRecords => Records.Where(r => r.Faction == Faction.Light).ToList();
        [JsonIgnore]
        public List<KillStatusRecord> FuryRecords => Records.Where(r => r.Faction == Faction.Fury).ToList();

        public KillStatus(string path) : base(path)
        {
        }

        public override void Read()
        {
            TotalStatus = _binaryReader.Read<int>();

            for (int i = 0; i < TotalStatus; i++)
            {
                var record = new KillStatusRecord(_binaryReader);
                Records.Add(record);
            }
        }
    }
}
