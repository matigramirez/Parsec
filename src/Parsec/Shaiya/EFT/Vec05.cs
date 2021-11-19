using Parsec.Readers;

namespace Parsec.Shaiya.EFT
{
    public class Vec05
    {
        public float Elem01 { get; set; }
        public float Elem02 { get; set; }
        public float Elem03 { get; set; }
        public float Elem04 { get; set; }
        public float Elem05 { get; set; }

        public Vec05()
        {
        }

        public Vec05(ShaiyaBinaryReader binaryReader)
        {
            Elem01 = binaryReader.Read<float>();
            Elem02 = binaryReader.Read<float>();
            Elem03 = binaryReader.Read<float>();
            Elem04 = binaryReader.Read<float>();
            Elem05 = binaryReader.Read<float>();
        }
    }
}
