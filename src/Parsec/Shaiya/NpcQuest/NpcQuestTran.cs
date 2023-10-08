using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuestTran : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public string WelcomeMessage { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
        WelcomeMessage = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name, false);
        binaryWriter.Write(WelcomeMessage, false);
    }
}
