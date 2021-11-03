using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.ANI
{
    public class Translation
    {
        public int Index { get; set; }
        public Vector3 Shift { get; set; }

        public Translation(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
            Shift = new Vector3(binaryReader);
        }
    }
}
