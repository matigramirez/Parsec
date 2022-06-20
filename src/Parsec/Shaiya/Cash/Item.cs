using Parsec.Attributes;

namespace Parsec.Shaiya.Cash;

public class Item
{
    [ShaiyaProperty]
    public int ItemId { get; set; }

    [ShaiyaProperty]
    public byte Count { get; set; }
}
