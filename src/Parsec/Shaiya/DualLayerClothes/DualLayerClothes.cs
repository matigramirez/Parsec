using Parsec.Extensions;
using Parsec.Serialization;

namespace Parsec.Shaiya.DualLayerClothes;

public sealed class DualLayerClothes : SData.SData
{
    public List<DualLayerClothesRecord> Records { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        Records = binaryReader.ReadList<DualLayerClothesRecord>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Records.ToSerializable());
    }
}
