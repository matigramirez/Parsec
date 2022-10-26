using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.SetItem;

public sealed class DBSetItemTextRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long Id { get; set; }

    [ShaiyaProperty]
    public string Name { get; set; }

    [ShaiyaProperty]
    public long SetEff1 { get; set; }

    [ShaiyaProperty]
    public long SetEff2 { get; set; }

    [ShaiyaProperty]
    public long SetEff3 { get; set; }

    [ShaiyaProperty]
    public long SetEff4 { get; set; }

    [ShaiyaProperty]
    public long SetEff5 { get; set; }

    [ShaiyaProperty]
    public long SetEff6 { get; set; }

    [ShaiyaProperty]
    public long SetEff7 { get; set; }

    [ShaiyaProperty]
    public long SetEff8 { get; set; }

    [ShaiyaProperty]
    public long SetEff9 { get; set; }

    [ShaiyaProperty]
    public long SetEff10 { get; set; }

    [ShaiyaProperty]
    public long SetEff11 { get; set; }

    [ShaiyaProperty]
    public long SetEff12 { get; set; }

    [ShaiyaProperty]
    public long SetEff13 { get; set; }
}
