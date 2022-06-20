using Parsec.Attributes;

namespace Parsec.Shaiya.Cash
{
    public class Product
    {
        [ShaiyaProperty]
        public int Index { get; set; }

        [ShaiyaProperty]
        public int Bag { get; set; }

        [ShaiyaProperty]
        public int Unknown { get; set; }

        [ShaiyaProperty]
        public int Cost { get; set; }

        [ShaiyaProperty]
        [FixedLengthList(typeof(Item), 24)]
        public List<Item> Items { get; set; } = new();

        [ShaiyaProperty]
        [LengthPrefixedString(false)]
        [SuffixedString("\0\0")]
        public string ProductName { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString(false)]
        [SuffixedString("\0\0")]
        public string ProductCode { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedString(false)]
        [SuffixedString("\0\0")]
        public string Description { get; set; }
    }
}
