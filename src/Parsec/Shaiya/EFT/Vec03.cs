using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class Vec03
    {
        public float Elem01 { get; set; }
        public float Elem02 { get; set; }
        public float Elem03 { get; set; }

        public Vec03()
        {
        }

        public Vec03(ShaiyaBinaryReader binaryReader)
        {
            Elem01 = binaryReader.Read<float>();
            Elem02 = binaryReader.Read<float>();
            Elem03 = binaryReader.Read<float>();
        }
    }
}
