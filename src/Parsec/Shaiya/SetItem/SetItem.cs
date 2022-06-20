using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.SetItem
{
    public class SetItem : SData.SData, IJsonReadable
    {
        public List<SetItemRecord> Records { get; } = new();

        public override void Read(params object[] options)
        {
            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var set = new SetItemRecord(_binaryReader);
                Records.Add(set);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown) => Records.GetBytes();
    }
}
