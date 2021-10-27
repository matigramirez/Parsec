using Parsec.Readers;

namespace Parsec.Shaiya.NPCQUEST
{
    public class MerchantItem
    {
        /// <summary>
        /// Item Type
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// Item TypeId
        /// </summary>
        public byte TypeId { get; set; }

        public MerchantItem(ShaiyaBinaryReader binaryReader)
        {
            Type = binaryReader.Read<byte>();
            TypeId = binaryReader.Read<byte>();
        }
    }
}
