using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Cash;

public class DBItemSellTextRecord : IBinarySDataRecord
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public string Text { get; set; }

    public void Read(SBinaryReader binaryReader, params object[] options)
    {
        Id = binaryReader.Read<long>();
        ProductName = binaryReader.ReadString();
        Text = binaryReader.ReadString();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(ProductName.GetLengthPrefixedBytes());
        buffer.AddRange(Text.GetLengthPrefixedBytes());
        return buffer;
    }
}
