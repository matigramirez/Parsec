using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya
{
    public class BaseNpc
    {
        public NpcType Type { get; set; }
        public short TypeId { get; set; }
        public int Shape { get; set; }
        public int Unknown_1 { get; set; }
        public int Unknown_2 { get; set; }
        public Faction Faction { get; set; }
        public string Name { get; set; }
        public string WelcomeMessage { get; set; }

        public int InQuestQuantity { get; set; }
        public List<short> InQuestIds { get; } = new();
        public int OutQuestQuantity { get; set; }
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
            Unknown_1 = binaryReader.Read<int>();
            Unknown_2 = binaryReader.Read<int>();
            Faction = (Faction)binaryReader.Read<int>();
            Name = binaryReader.ReadString();
            WelcomeMessage = binaryReader.ReadString();
        }

        public void ReadBaseNpcThirdSegment(ShaiyaBinaryReader binaryReader)
        {
            InQuestQuantity = binaryReader.Read<int>();

            for (int i = 0; i < InQuestQuantity; i++)
            {
                var questId = binaryReader.Read<short>();
                InQuestIds.Add(questId);
            }

            OutQuestQuantity = binaryReader.Read<int>();

            for (int i = 0; i < OutQuestQuantity; i++)
            {
                var questId = binaryReader.Read<short>();
                OutQuestIds.Add(questId);
            }
        }
    }
}
