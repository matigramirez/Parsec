using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class DDS
    {
        public int Index { get; set; }

        public DDS()
        {
        }

        public DDS(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
        }
    }
}
