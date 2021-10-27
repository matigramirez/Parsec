using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.KILLSTATUS
{
    public class KillStatusRecord
    {
        public Faction Faction { get; set; }
        public int BlessValue { get; set; }
        public short Index { get; set; }
        public List<KillStatusBonus> Bonuses { get; } = new();

        public KillStatusRecord()
        {
        }

        public KillStatusRecord(ShaiyaBinaryReader binaryReader)
        {
            Faction = (Faction)binaryReader.Read<byte>();
            BlessValue = binaryReader.Read<int>();
            Index = binaryReader.Read<short>();

            for (int i = 0; i < 6; i++)
            {
                var bonus = new KillStatusBonus(binaryReader);
                Bonuses.Add(bonus);
            }
        }
    }
}
