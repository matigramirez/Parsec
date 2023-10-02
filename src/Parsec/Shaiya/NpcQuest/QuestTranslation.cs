using Newtonsoft.Json;
using Parsec.Attributes;

namespace Parsec.Shaiya.NpcQuest;

public class QuestTranslation
{
    [ShaiyaProperty]
    [LengthPrefixedString]
    public string Name { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string Summary { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string CompletionMessage { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string CompletionMessage2 { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string CompletionMessage3 { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string CompletionMessage4 { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string CompletionMessage5 { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string CompletionMessage6 { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string InitialDescription { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string WelcomeMessage { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string ReminderMessage { get; set; } = string.Empty;

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string AlternateResponse { get; set; } = string.Empty;

    [JsonConstructor]
    public QuestTranslation()
    {
    }
}
