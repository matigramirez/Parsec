using Parsec.Attributes;

namespace Parsec.Shaiya.DualLayerClothes;

public sealed class DualLayerClothesRecord
{
    [ShaiyaProperty]
    public short Index { get; set; }

    [ShaiyaProperty]
    public short Upper { get; set; }

    [ShaiyaProperty]
    public short Hands { get; set; }

    [ShaiyaProperty]
    public short Lower { get; set; }

    [ShaiyaProperty]
    public short Feet { get; set; }

    [ShaiyaProperty]
    public short Face { get; set; }

    [ShaiyaProperty]
    public short Head { get; set; }
}
