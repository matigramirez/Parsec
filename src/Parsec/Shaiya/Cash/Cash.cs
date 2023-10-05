using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.Cash;

/// <summary>
/// Class that represents the Cash.SData format, which is used to define the items that are for sale in the in-game shop.
/// </summary>
public sealed class Cash : SData.SData
{
    public List<CashProduct> Products { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Products = binaryReader.ReadList<CashProduct>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Products.ToSerializable());
    }
}
