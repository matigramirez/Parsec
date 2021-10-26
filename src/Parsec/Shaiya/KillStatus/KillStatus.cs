using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya
{
    public class KillStatus : FileBase, IDumpable
    {
        public int TotalStatus { get; set; }
        public List<KillStatusRecord> Records { get; } = new();
        public List<KillStatusRecord> LightRecords => Records.Where(r => r.Faction == Faction.Light).ToList();
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

        public void CreateFriendlyDump(string path)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("[KillStatus.SData]");
            stringBuilder.AppendLine($"TotalRecords: {Records.Count}");
            stringBuilder.AppendLine($"LightRecords: {LightRecords.Count}");
            stringBuilder.AppendLine($"FuryRecords: {FuryRecords.Count}");
            stringBuilder.AppendLine();

            for (int i = 0; i < Records.Count; i++)
            {
                stringBuilder.AppendLine($"[Record_{i}]");
                stringBuilder.AppendLine($"Faction: {Records[i].Faction}");
                stringBuilder.AppendLine($"BlessValue: {Records[i].BlessValue}");
                stringBuilder.AppendLine($"Index: {Records[i].Index}");

                stringBuilder.AppendLine("Bonuses: [");

                foreach (var bonus in Records[i].Bonuses)
                {
                    // Skip type 0, which means no bonus
                    if (bonus.Type == 0)
                        continue;
                    stringBuilder.AppendLine($@"    {{ BonusType: {bonus.Type}, Value: {bonus.Value} }}");
                }

                stringBuilder.AppendLine("]");
                stringBuilder.AppendLine();
            }

            var fileBytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());

            FileHelper.WriteFile(path, fileBytes);
        }
    }
}
