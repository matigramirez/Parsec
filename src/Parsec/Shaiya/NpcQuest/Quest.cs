using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.NPCQUEST
{
    public class Quest
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public short MinLevel { get; set; }
        public short MaxLevel { get; set; }
        public byte Unknown1 { get; set; }
        public Mode Mode { get; set; }
        public byte Unknown2 { get; set; }
        public byte Unknown3 { get; set; }
        public byte AttackFighter { get; set; }
        public byte DefenseFighter { get; set; }
        public byte PatrolRogue { get; set; }
        public byte ShooterRogue { get; set; }
        public byte AttackMage { get; set; }
        public byte DefenseMage { get; set; }
        public short PrevQuestId2 { get; set; }
        public short PrevQuestId3 { get; set; }
        public short Unknown4 { get; set; }
        public byte Unknown5 { get; set; }
        public short PrevQuestId { get; set; }
        public int Unknown6 { get; set; }
        public byte Unknown7 { get; set; }
        public byte Unknown8 { get; set; }
        public byte Unknown9 { get; set; }
        public byte Unknown10 { get; set; }
        public short Unknown11 { get; set; }
        public byte Unknown12 { get; set; }
        public short QuestTimer { get; set; }

        public int Unknown13 { get; set; }
        public int Unknown14 { get; set; }
        public byte Unknown15 { get; set; }
        public byte Unknown16 { get; set; }
        public byte Unknown17 { get; set; }
        public byte Unknown18 { get; set; }
        public short Unknown19 { get; set; }

        public List<QuestRequiredItem> RequiredItems { get; } = new();

        public Quest(ShaiyaBinaryReader binaryReader)
        {
            Id = binaryReader.Read<short>();
            Name = binaryReader.ReadString();
            Summary = binaryReader.ReadString();
        }
    }
}