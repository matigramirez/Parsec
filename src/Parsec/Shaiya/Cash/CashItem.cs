using Parsec.Attributes;

namespace Parsec.Shaiya.Cash;

public sealed class CashItem
{
    [ShaiyaProperty]
    public int ItemId { get; set; }

    [ShaiyaProperty]
    public byte Count { get; set; }
}
