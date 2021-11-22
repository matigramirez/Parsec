using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.KILLSTATUS
{
    public class KillStatus : FileBase, IJsonReadable
    {
        public List<KillStatusRecord> Records { get; } = new();

        [JsonIgnore]
        public List<KillStatusRecord> LightRecords => Records.Where(r => r.Faction == Faction.Light).ToList();

        [JsonIgnore]
        public List<KillStatusRecord> FuryRecords => Records.Where(r => r.Faction == Faction.Fury).ToList();

        public KillStatus(string path) : base(path)
        {
        }

        [JsonConstructor]
        public KillStatus()
        {
        }

        public override void Read()
        {
            var totalStatus = _binaryReader.Read<int>();

            for (int i = 0; i < totalStatus; i++)
            {
                var record = new KillStatusRecord(_binaryReader);
                Records.Add(record);
            }
        }

        public override void Write(string path)
        {
            // Create byte list which will contain the data
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Records.Count));

            foreach (var record in Records)
            {
                buffer.AddRange(record.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
