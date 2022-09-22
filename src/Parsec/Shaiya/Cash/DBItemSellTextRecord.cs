using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Cash;

public class DBItemSellTextRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long Id { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(false)]
    public string ProductName { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(false)]
    public string Text { get; set; }
}
