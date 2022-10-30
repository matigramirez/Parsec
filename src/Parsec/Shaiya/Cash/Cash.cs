using Parsec.Attributes;

namespace Parsec.Shaiya.Cash;

/// <summary>
/// Class that represents the Cash.SData format, which is used to define the items that are for sale in the in-game shop.
/// </summary>
public sealed class Cash : SData.SData
{
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Product))]
    public List<Product> Products { get; set; } = new();
}
