using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuestStandardNpc : NpcQuestBaseNpc, ISerializable
{
    public void Read(SBinaryReader binaryReader)
    {
        ReadNpcBaseComplete(binaryReader);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        WriteNpcBaseComplete(binaryWriter);
    }
}
