using Parsec.Readers;

namespace Parsec.Shaiya.GUILDHOUSE
{
    public class NpcInfo
    {
        public byte PriceRate { get; set; }
        public byte NpcLvl { get; set; }
        public byte RapiceMixPercentRate { get; set; }
        public byte RapiceMixDecreRate { get; set; }
        public byte MinRank { get; set; }
        public short Icon { get; set; }
        public short SysMsgId { get; set; }
        public short UpPrice { get; set; }
        public short ServicePrice { get; set; }
        public byte NpcType { get; set; }
        public byte Group { get; set; }

        public NpcInfo(ShaiyaBinaryReader binaryReader)
        {
            PriceRate = binaryReader.Read<byte>();
            NpcLvl = binaryReader.Read<byte>();
            RapiceMixPercentRate = binaryReader.Read<byte>();
            RapiceMixDecreRate = binaryReader.Read<byte>();
            MinRank = binaryReader.Read<byte>();
            Icon = binaryReader.Read<short>();
            SysMsgId = binaryReader.Read<short>();
            UpPrice = binaryReader.Read<short>();
            ServicePrice = binaryReader.Read<short>();
            NpcType = binaryReader.Read<byte>();
            Group = binaryReader.Read<byte>();
        }
    }
}
