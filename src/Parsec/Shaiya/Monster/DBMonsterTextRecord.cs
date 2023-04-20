using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Monster;

public sealed class DBMonsterTextRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long Id { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedString(true)]
    public string Name { get; set; }
}
