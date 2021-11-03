using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.ANI
{
    public class Rotation
    {
        public int Index { get; set; }
        public Quaternion RotationQuaternion { get; set; }

        public Rotation(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
            RotationQuaternion = new Quaternion(binaryReader);
        }
    }
}
