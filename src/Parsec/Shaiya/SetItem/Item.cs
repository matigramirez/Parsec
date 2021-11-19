using Parsec.Readers;

namespace Parsec.Shaiya.SETITEM
{
    public class Item
    {
        public short Type { get; set; }
        public short TypeId { get; set; }

        public Item()
        {
        }

        public Item(ShaiyaBinaryReader binaryReader)
        {
            Type = binaryReader.Read<short>();
            TypeId = binaryReader.Read<short>();
        }
    }
}
