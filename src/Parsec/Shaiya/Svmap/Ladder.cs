using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    public class Ladder
    {
        public Vector3 Position { get; set; }

        public Ladder(ShaiyaBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
        }
    }
}
