using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class Vec02
    {
        public float Elem01 { get; set; }
        public float Elem02 { get; set; }

        public Vec02()
        {
        }

        public Vec02(ShaiyaBinaryReader binaryReader)
        {
            Elem01 = binaryReader.Read<float>();
            Elem02 = binaryReader.Read<float>();
        }
    }
}
