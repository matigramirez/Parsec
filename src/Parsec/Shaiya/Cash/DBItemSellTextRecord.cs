using Parsec.Serialization;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Cash;

public sealed class DBItemSellTextRecord : IBinarySDataRecord
{
    public long Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Id = binaryReader.ReadInt64();
        ProductName = binaryReader.ReadString();
        Text = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.WriteLengthPrefixedString(ProductName, includeStringTerminator: false);
        binaryWriter.WriteLengthPrefixedString(Text, includeStringTerminator: false);
    }
}
