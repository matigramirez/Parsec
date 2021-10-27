using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.NPCQUEST
{
    public class GateTarget
    {
        public short MapId { get; set; }
        public Vector3 Position { get; set; }
        public string TargetName { get; set; }

        /// <summary>
        /// Teleporting gold cost
        /// </summary>
        public int Cost { get; set; }

        public GateTarget(ShaiyaBinaryReader binaryReader)
        {
            MapId = binaryReader.Read<short>();
            Position = new Vector3(binaryReader);
            TargetName = binaryReader.ReadString();
            Cost = binaryReader.Read<int>();
        }
    }
}
