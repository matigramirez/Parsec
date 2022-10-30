using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;

namespace Parsec.Shaiya.NpcQuest;

public class GateKeeper : BaseNpc
{
    public List<GateTarget> GateTargets { get; } = new();

    public GateKeeper(SBinaryReader binaryReader, Episode episode)
    {
        ReadBaseNpcFirstSegment(binaryReader);
        ReadBaseNpcSecondSegment(binaryReader, episode);

        for (int i = 0; i < 3; i++)
        {
            var gateTarget = new GateTarget(binaryReader, episode);
            GateTargets.Add(gateTarget);
        }

        ReadBaseNpcThirdSegment(binaryReader);
    }

    [JsonConstructor]
    public GateKeeper()
    {
    }

    public override IEnumerable<byte> GetBytes(params object[] options)
    {
        var episode = Episode.EP5;

        if (options.Length > 0)
            episode = (Episode)options[0];

        var buffer = new List<byte>();
        WriteBaseNpcFirstSegmentBytes(buffer);
        WriteBaseNpcSecondSegmentBytes(buffer, episode);
        buffer.AddRange(GateTargets.Take(3).GetBytes(false, episode));
        WriteBaseNpcThirdSegmentBytes(buffer);
        return buffer;
    }
}
