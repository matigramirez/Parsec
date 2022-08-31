using Newtonsoft.Json;
using Parsec.Attributes;

namespace Parsec.Shaiya.NpcQuest
{
    public class NpcQuestTran
    {
        [ShaiyaProperty]
        [LengthPrefixedString]
        public string Name { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string WelcomeMessage { get; set; }

        [JsonConstructor]
        public NpcQuestTran()
        {
        }
    }

    public class GateKeeperQuestTran
    {
        [ShaiyaProperty]
        [LengthPrefixedString]
        public string Name { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string WelcomeMessage { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string TeleportName1 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string TeleportName2 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string TeleportName3 { get; set; }

        [JsonConstructor]
        public GateKeeperQuestTran()
        {
        }
    }
}
