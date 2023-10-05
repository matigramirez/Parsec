using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class StandardNpc : BaseNpc, ISerializable
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
