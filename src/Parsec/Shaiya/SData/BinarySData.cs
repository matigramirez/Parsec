using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.SData
{
    public abstract class BinarySData<TRecord> : SData where TRecord : IBinarySDataRecord, new()
    {
        /// <summary>
        /// 128-byte header unused by the game itself. It looks like a file signature + metadata
        /// </summary>
        public byte[] Header { get; set; }

        /// <summary>
        /// Field names are defined before the data. They aren't really used but knowing which each field means is nice
        /// </summary>
        public List<BinarySDataField> Fields { get; } = new();

        public List<TRecord> Records { get; } = new();

        public override void Read(params object[] options)
        {
            Header = _binaryReader.ReadBytes(128);
            var fieldCount = _binaryReader.Read<int>();

            for (int i = 0; i < fieldCount; i++)
                Fields.Add(new BinarySDataField(_binaryReader));

            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var record = new TRecord();
                record.Read(_binaryReader);
                Records.Add(record);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Header);
            buffer.AddRange(Fields.GetBytes());

            buffer.AddRange(Records.Count.GetBytes());

            foreach (var record in Records)
                buffer.AddRange(record.GetBytes());

            return buffer;
        }
    }
}
