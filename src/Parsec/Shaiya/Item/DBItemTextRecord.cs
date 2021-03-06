using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Item;

public class DBItemTextRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long ItemType { get; set; }

    [ShaiyaProperty]
    public long ItemTypeId { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string ItemName { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString]
    public string Text { get; set; }
}
