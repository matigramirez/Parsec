using Parsec.Readers;

namespace Parsec.Shaiya.NPCQUEST
{
    public class GateKeeper : BaseNpc
    {
        public GateTarget GateTarget1 { get; set; }
        public GateTarget GateTarget2 { get; set; }
        public GateTarget GateTarget3 { get; set; }

        public GateKeeper(ShaiyaBinaryReader binaryReader)
        {
            ReadBaseNpcFirstSegment(binaryReader);
            ReadBaseNpcSecondSegment(binaryReader);

            GateTarget1 = new GateTarget(binaryReader);
            GateTarget2 = new GateTarget(binaryReader);
            GateTarget3 = new GateTarget(binaryReader);

            ReadBaseNpcThirdSegment(binaryReader);
        }
    }
}
