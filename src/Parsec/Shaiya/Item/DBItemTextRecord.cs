using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Item
{
    public class DBItemTextRecord : IBinarySDataRecord
    {
        public long ItemType { get; set; }
        public long ItemTypeId { get; set; }
        public string ItemName { get; set; }
        public string Text { get; set; }

        public void Read(SBinaryReader binaryReader, params object[] options)
        {
            ItemType = binaryReader.Read<long>();
            ItemTypeId = binaryReader.Read<long>();
            ItemName = binaryReader.ReadString();
            Text = binaryReader.ReadString();
        }

        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(ItemType.GetBytes());
            buffer.AddRange(ItemTypeId.GetBytes());
            buffer.AddRange(ItemName.GetLengthPrefixedBytes());
            buffer.AddRange(Text.GetLengthPrefixedBytes());
            return buffer;
        }
    }
}
