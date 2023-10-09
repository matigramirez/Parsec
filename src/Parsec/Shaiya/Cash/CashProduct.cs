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
        ProductName = binaryReader.ReadString();
        ProductCode = binaryReader.ReadString();
        Description = binaryReader.ReadString();

        // Manually remove double string terminator on the end of each string.
        ProductName = ProductName.Trim('\0');
        ProductCode = ProductCode.Trim('\0');
        Description = Description.Trim('\0');
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Index);
        binaryWriter.Write(Bag);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(Cost);
        binaryWriter.Write(Items.Take(24).ToSerializable(), lengthPrefixed: false);

        // Manually add double string terminator on the end of each string.
        binaryWriter.Write(ProductName + "\0");
        binaryWriter.Write(ProductCode + "\0");
        binaryWriter.Write(Description + "\0");
    }
}
