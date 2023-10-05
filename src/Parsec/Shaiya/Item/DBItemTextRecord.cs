using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Item;

public sealed class DBItemTextRecord : IBinarySDataRecord
{
    public long ItemType { get; set; }

    public long ItemTypeId { get; set; }

    public string ItemName { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        ItemType = binaryReader.ReadInt64();
        ItemTypeId = binaryReader.ReadInt64();
        ItemName = binaryReader.ReadString();
        Text = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ItemType);
        binaryWriter.Write(ItemTypeId);
        binaryWriter.WriteLengthPrefixedString(ItemName, false);
        binaryWriter.WriteLengthPrefixedString(Text, false);
    }
}
