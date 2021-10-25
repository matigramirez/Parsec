using Parsec.Shaiya.Common;

namespace Parsec.Shaiya
{
    public class GateTarget
    {
        public short MapId { get; set; }
        public Point3D Position { get; set; }
        public string TargetName { get; set; }

        /// <summary>
        /// Teleporting gold cost
        /// </summary>
        public int Cost { get; set; }
    }
}
