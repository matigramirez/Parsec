using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Common;
using Newtonsoft.Json;

namespace Parsec.Shaiya.NpcQuest
{
    public class GateKeeper : BaseNpc
    {
        public List<GateTarget> GateTargets { get; } = new();

        public GateKeeper(SBinaryReader binaryReader, Format format) : base(format)
        {
            ReadBaseNpcFirstSegment(binaryReader);
            ReadBaseNpcSecondSegment(binaryReader);

            for (int i = 0; i < 3; i++)
            {
                var gateTarget = new GateTarget(binaryReader, format);
                GateTargets.Add(gateTarget);
            }

            ReadBaseNpcThirdSegment(binaryReader);
        }

        [JsonConstructor]
        public GateKeeper(Format format = Format.EP5) : base(format)
        {
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            WriteBaseNpcFirstSegmentBytes(buffer);
            WriteBaseNpcSecondSegmentBytes(buffer);

            foreach (var gateTarget in GateTargets)
                buffer.AddRange(gateTarget.GetBytes());

            WriteBaseNpcThirdSegmentBytes(buffer);

            return buffer.ToArray();
        }
    }
}
