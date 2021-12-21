using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.KillStatus
{
    public class KillStatus : SData.SData, IJsonReadable
    {
        public List<KillStatusRecord> Records { get; } = new();

        [JsonIgnore]
        public List<KillStatusRecord> LightRecords => Records.Where(r => r.Faction == Faction.Light).ToList();

        [JsonIgnore]
        public List<KillStatusRecord> FuryRecords => Records.Where(r => r.Faction == Faction.Fury).ToList();

        public override void Read(params object[] options)
        {
            var totalStatus = _binaryReader.Read<int>();

            for (int i = 0; i < totalStatus; i++)
            {
                var record = new KillStatusRecord(_binaryReader);
                Records.Add(record);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Records.Count));

            foreach (var record in Records)
                buffer.AddRange(record.GetBytes());

            return buffer.ToArray();
        }
    }
}
