using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SVMAP
{
    public class NamedArea
    {
        public CubicArea Area { get; set; }
        public int NameIdentifier1 { get; set; }
        public int NameIdentifier2 { get; set; }

        public NamedArea(ShaiyaBinaryReader binaryReader)
        {
            Area = new CubicArea(binaryReader);
            NameIdentifier1 = binaryReader.Read<int>();
            NameIdentifier2 = binaryReader.Read<int>();
        }
    }
}
