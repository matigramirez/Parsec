using Newtonsoft.Json;
using Parsec.Attributes;

namespace Parsec.Shaiya.NpcQuest
{
    public class QuestTranslation
    {
        [ShaiyaProperty]
        [LengthPrefixedString]
        public string Name { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string Summary { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string CompletionMessage { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string CompletionMessage2 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string CompletionMessage3 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string CompletionMessage4 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string CompletionMessage5 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string CompletionMessage6 { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string InitialDescription { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string WelcomeMessage { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string ReminderMessage { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString]
        public string AlternateResponse { get; set; }

        [JsonConstructor]
        public QuestTranslation()
        {
        }
    }
}
