using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cash;

public sealed class CashProduct : ISerializable
{
    public uint Index { get; set; }

    public uint Bag { get; set; }

    public uint Unknown { get; set; }

    public uint Cost { get; set; }

    public List<CashProductItem> Items { get; set; } = new();

    public string ProductName { get; set; } = string.Empty;

    public string ProductCode { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Index = binaryReader.ReadUInt32();
        Bag = binaryReader.ReadUInt32();
        Unknown = binaryReader.ReadUInt32();
        Cost = binaryReader.ReadUInt32();
        Items = binaryReader.ReadList<CashProductItem>(24).ToList();
        ProductName = binaryReader.ReadString(false);
        ProductCode = binaryReader.ReadString(false);
        Description = binaryReader.ReadString(false);

        // Manually remove double string terminator on the end of each string.
        ProductName = ProductName.Substring(0, ProductName.Length - 2);
        ProductCode = ProductCode.Substring(0, ProductCode.Length - 2);
        Description = Description.Substring(0, Description.Length - 2);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Index);
        binaryWriter.Write(Bag);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(Cost);
        binaryWriter.Write(Items.Take(24).ToSerializable(), false);
        binaryWriter.Write(ProductName + "\0\0", false);
        binaryWriter.Write(ProductCode + "\0\0", false);
        binaryWriter.Write(Description + "\0\0", false);
    }
}
