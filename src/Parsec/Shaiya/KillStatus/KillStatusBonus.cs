using Parsec.Readers;

namespace Parsec.Shaiya
{
    public class KillStatusBonus
    {
        public KillStatusBonusType Type { get; set; }
        public short Value { get; set; }

        public KillStatusBonus()
        {
        }

        public KillStatusBonus(ShaiyaBinaryReader binaryReader)
        {
            Type = (KillStatusBonusType)binaryReader.Read<byte>();
            Value = binaryReader.Read<short>();
        }
    }
}
