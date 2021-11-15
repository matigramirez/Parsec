using Parsec.Readers;

namespace Parsec.Shaiya.CASH
{
    public class Item
    {
        public int ItemId { get; set; }
        public byte Count { get; set; }

        public Item()
        {
        }

        public Item(ShaiyaBinaryReader binaryReader)
        {
            ItemId = binaryReader.Read<int>();
            Count = binaryReader.Read<byte>();
        }
    }
}
