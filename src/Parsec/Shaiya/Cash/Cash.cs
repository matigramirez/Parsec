using Parsec.Attributes;
using Parsec.Common;

namespace Parsec.Shaiya.Cash;

/// <summary>
/// Class that represents the Cash.SData format, which is used to define the items that are for sale in the in-game shop.
/// </summary>
public sealed class Cash : SData.SData, IJsonReadable
{
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Product))]
    public List<Product> Products { get; set; } = new();
}
