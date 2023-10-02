using Newtonsoft.Json;
using Parsec.Attributes;

namespace Parsec.Shaiya.NpcQuest
{
    public class NpcQuestTran
    {
        [ShaiyaProperty]
        [LengthPrefixedString]
        public string Name { get; set; } = string.Empty;

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string WelcomeMessage { get; set; } = string.Empty;

        [JsonConstructor]
        public NpcQuestTran()
        {
        }
    }

    public class GateKeeperQuestTran
    {
        [ShaiyaProperty]
        [LengthPrefixedString]
        public string Name { get; set; } = string.Empty;

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string WelcomeMessage { get; set; } = string.Empty;

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string TeleportName1 { get; set; } = string.Empty;

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string TeleportName2 { get; set; } = string.Empty;

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string TeleportName3 { get; set; } = string.Empty;

        [JsonConstructor]
        public GateKeeperQuestTran()
        {
        }
    }
}
