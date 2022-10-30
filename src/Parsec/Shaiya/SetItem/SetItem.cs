using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.SetItem;

public sealed class SetItem : SData.SData
{
    public List<SetItemRecord> Records { get; } = new();

    public override void Read(params object[] options)
    {
        int recordCount = _binaryReader.Read<int>();
        for (int i = 0; i < recordCount; i++)
            Records.Add(new SetItemRecord(_binaryReader));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown) => Records.GetBytes();
}
