using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Readers;

namespace Parsec.Shaiya.NpcQuest;

public class GateKeeper : BaseNpc
{
    public List<GateTarget> GateTargets { get; } = new();

    public GateKeeper(SBinaryReader binaryReader, Episode episode) : base(episode)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        ReadBaseNpcSecondSegment(binaryReader);

        for (int i = 0; i < 3; i++)
        {
            var gateTarget = new GateTarget(binaryReader, episode);
            GateTargets.Add(gateTarget);
        }

        ReadBaseNpcThirdSegment(binaryReader);
    }

    [JsonConstructor]
    public GateKeeper(Episode episode = Episode.EP5) : base(episode)
    {
    }

    public override IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();

        WriteBaseNpcFirstSegmentBytes(buffer);
        WriteBaseNpcSecondSegmentBytes(buffer);

        foreach (var gateTarget in GateTargets)
            buffer.AddRange(gateTarget.GetBytes());

        WriteBaseNpcThirdSegmentBytes(buffer);

        return buffer;
    }
}
