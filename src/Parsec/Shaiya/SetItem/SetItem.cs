using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.SetItem;

public sealed class SetItem : SData.SData
{
    public List<SetItemRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Records = binaryReader.ReadList<SetItemRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Records.ToSerializable());
    }
}
