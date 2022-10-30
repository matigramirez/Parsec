using Parsec.Attributes;
using Parsec.Common;

namespace Parsec.Shaiya.DualLayerClothes;

[DefaultVersion(Episode.EP6)]
public sealed class DualLayerClothes : SData.SData
{
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(DualLayerClothesRecord))]
    public List<DualLayerClothesRecord> Records { get; set; } = new();
}
