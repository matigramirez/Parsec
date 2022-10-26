using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

public sealed class ZoneList
{
    [ShaiyaProperty]
    public BoundingBox BoundingBox { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(int))]
    public List<int> Identifiers { get; set; } = new();
}
