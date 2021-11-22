using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    public class NpcLocation
    {
        public Vector3 Position { get; set; }
        public float Orientation { get; set; }

        public NpcLocation(ShaiyaBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
            Orientation = binaryReader.Read<float>();
        }
    }
}
