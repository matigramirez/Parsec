using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.NPCQUEST
{
    public class BaseNpc
    {
        public NpcType Type { get; set; }
        public short TypeId { get; set; }
        public int Shape { get; set; }
        public int Unknown1 { get; set; }
        public int Unknown2 { get; set; }
        public Faction Faction { get; set; }
        public string Name { get; set; }
        public string WelcomeMessage { get; set; }

        public List<short> InQuestIds { get; } = new();
        public List<short> OutQuestIds { get; } = new();

        public void ReadNpcBaseComplete(ShaiyaBinaryReader binaryReader)
        {
            ReadBaseNpcFirstSegment(binaryReader);
            ReadBaseNpcSecondSegment(binaryReader);
            ReadBaseNpcThirdSegment(binaryReader);
        }

        public void ReadBaseNpcFirstSegment(ShaiyaBinaryReader binaryReader)
        {
            Type = (NpcType)binaryReader.Read<byte>();
            TypeId = binaryReader.Read<short>();
        }

        public void ReadBaseNpcSecondSegment(ShaiyaBinaryReader binaryReader)
        {
            Shape = binaryReader.Read<int>();
            Unknown1 = binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<int>();
            Faction = (Faction)binaryReader.Read<int>();
            Name = binaryReader.ReadString();
            WelcomeMessage = binaryReader.ReadString();
        }

        public void ReadBaseNpcThirdSegment(ShaiyaBinaryReader binaryReader)
        {
            var inQuestQuantity = binaryReader.Read<int>();

            for (int i = 0; i < inQuestQuantity; i++)
            {
                var questId = binaryReader.Read<short>();
                InQuestIds.Add(questId);
            }

            var outQuestQuantity = binaryReader.Read<int>();

            for (int i = 0; i < outQuestQuantity; i++)
            {
                var questId = binaryReader.Read<short>();
                OutQuestIds.Add(questId);
            }
        }
    }
}
