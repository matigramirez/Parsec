using Parsec.Attributes;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.DualLayerClothes;

public sealed class DBDualLayerClothesDataRecord : IBinarySDataRecord
{
    [ShaiyaProperty]
    public long Id { get; set; }

    [ShaiyaProperty]
    public long Top { get; set; }

    [ShaiyaProperty]
    public long Hand { get; set; }

    [ShaiyaProperty]
    public long Bottom { get; set; }

    [ShaiyaProperty]
    public long Shoe { get; set; }

    [ShaiyaProperty]
    public long Empty { get; set; }

    [ShaiyaProperty]
    public long Helmet { get; set; }
}
