using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest;

public class NpcQuestGateKeeper : NpcQuestBaseNpc, ISerializable
{
    public List<NpcQuestGateTarget> GateTargets { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        ReadBaseNpcSecondSegment(binaryReader);
        GateTargets = binaryReader.ReadList<NpcQuestGateTarget>(3).ToList();
        ReadBaseNpcThirdSegment(binaryReader);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        WriteBaseNpcFirstSegment(binaryWriter);
        WriteBaseNpcSecondSegment(binaryWriter);
        binaryWriter.Write(GateTargets.Take(3).ToSerializable(), lengthPrefixed: false);
        WriteBaseNpcThirdSegment(binaryWriter);
    }
}
