using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class QuestTranslation : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string CompletionMessage { get; set; } = string.Empty;

    public string CompletionMessage2 { get; set; } = string.Empty;

    public string CompletionMessage3 { get; set; } = string.Empty;

    public string CompletionMessage4 { get; set; } = string.Empty;

    public string CompletionMessage5 { get; set; } = string.Empty;

    public string CompletionMessage6 { get; set; } = string.Empty;

    public string InitialDescription { get; set; } = string.Empty;

    public string WelcomeMessage { get; set; } = string.Empty;

    public string ReminderMessage { get; set; } = string.Empty;

    public string AlternateResponse { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
        Summary = binaryReader.ReadString();
        CompletionMessage = binaryReader.ReadString();
        CompletionMessage2 = binaryReader.ReadString();
        CompletionMessage3 = binaryReader.ReadString();
        CompletionMessage4 = binaryReader.ReadString();
        CompletionMessage5 = binaryReader.ReadString();
        CompletionMessage6 = binaryReader.ReadString();
        InitialDescription = binaryReader.ReadString();
        WelcomeMessage = binaryReader.ReadString();
        ReminderMessage = binaryReader.ReadString();
        AlternateResponse = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name, includeStringTerminator: false);
        binaryWriter.Write(Summary, includeStringTerminator: false);
        binaryWriter.Write(CompletionMessage, includeStringTerminator: false);
        binaryWriter.Write(CompletionMessage2, includeStringTerminator: false);
        binaryWriter.Write(CompletionMessage3, includeStringTerminator: false);
        binaryWriter.Write(CompletionMessage4, includeStringTerminator: false);
        binaryWriter.Write(CompletionMessage5, includeStringTerminator: false);
        binaryWriter.Write(CompletionMessage6, includeStringTerminator: false);
        binaryWriter.Write(InitialDescription, includeStringTerminator: false);
        binaryWriter.Write(WelcomeMessage, includeStringTerminator: false);
        binaryWriter.Write(ReminderMessage, includeStringTerminator: false);
        binaryWriter.Write(AlternateResponse, includeStringTerminator: false);
    }
}
