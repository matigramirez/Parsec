using Parsec.Readers;

namespace Parsec.Shaiya.CASH
{
    public class CashItem
    {
        public int ItemId { get; set; }
        public byte Count { get; set; }

        public CashItem()
        {
        }

        public CashItem(ShaiyaBinaryReader binaryReader)
        {
            ItemId = binaryReader.Read<int>();
            Count = binaryReader.Read<byte>();
        }
    }
}
