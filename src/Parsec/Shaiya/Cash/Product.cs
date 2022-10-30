using Parsec.Attributes;

namespace Parsec.Shaiya.Cash;

public sealed class Product
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
    [FixedLengthList(typeof(CashItem), 24)]
    public List<CashItem> Items { get; set; } = new();

    [ShaiyaProperty]
    [LengthPrefixedString(IncludeStringTerminator = false, Suffix = "\0\0")]
    public string ProductName { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(IncludeStringTerminator = false, Suffix = "\0\0")]
    public string ProductCode { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(IncludeStringTerminator = false, Suffix = "\0\0")]
    public string Description { get; set; }
}
