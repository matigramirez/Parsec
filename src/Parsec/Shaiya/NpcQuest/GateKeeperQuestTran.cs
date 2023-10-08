using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class GateKeeperQuestTran : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public string WelcomeMessage { get; set; } = string.Empty;

    public string TeleportName1 { get; set; } = string.Empty;

    public string TeleportName2 { get; set; } = string.Empty;

    public string TeleportName3 { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
        WelcomeMessage = binaryReader.ReadString();
        TeleportName1 = binaryReader.ReadString();
        TeleportName2 = binaryReader.ReadString();
        TeleportName3 = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name, false);
        binaryWriter.Write(WelcomeMessage, false);
        binaryWriter.Write(TeleportName1, false);
        binaryWriter.Write(TeleportName2, false);
        binaryWriter.Write(TeleportName3, false);
    }
}
