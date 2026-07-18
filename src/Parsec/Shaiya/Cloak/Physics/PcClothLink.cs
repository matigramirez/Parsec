using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.Physics;

/// <summary>
/// Describes one simulated cloth grid and its relationship to render and skeleton resources.
/// </summary>
public sealed class PcClothLink : ISerializable
{
    public const int AnchorCount = 20;
    public const int SerializedSize = 0x20c;

    public int ClothMeshIndex { get; set; }

    public int TextureIndex { get; set; }

    public int SolverMode { get; set; }

    public int RigidMeshIndex { get; set; }

    public int ColumnSegments { get; set; }

    public int RowSegments { get; set; }

    public int SampleColumn { get; set; }

    public int SampleRow { get; set; }

    public int SampleRadiusColumn { get; set; }

    public int SampleRadiusRow { get; set; }

    /// <summary>
    /// Reserved 32-bit field. PS0198 files commonly contain the debug-fill value 0xCDCDCDCD.
    /// </summary>
    public uint Padding { get; set; }

    /// <summary>
    /// The format always stores exactly 20 anchor slots, including inactive slots.
    /// </summary>
    public List<PcAnchor> Anchors { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        ClothMeshIndex = binaryReader.ReadInt32();
        TextureIndex = binaryReader.ReadInt32();
        SolverMode = binaryReader.ReadInt32();
        RigidMeshIndex = binaryReader.ReadInt32();
        ColumnSegments = binaryReader.ReadInt32();
        RowSegments = binaryReader.ReadInt32();
        SampleColumn = binaryReader.ReadInt32();
        SampleRow = binaryReader.ReadInt32();
        SampleRadiusColumn = binaryReader.ReadInt32();
        SampleRadiusRow = binaryReader.ReadInt32();
        Padding = binaryReader.ReadUInt32();
        Anchors = binaryReader.ReadList<PcAnchor>(AnchorCount);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        if (Anchors.Count != AnchorCount)
        {
            throw new InvalidDataException($"A .PC cloth link must contain exactly {AnchorCount} anchor slots.");
        }

        binaryWriter.Write(ClothMeshIndex);
        binaryWriter.Write(TextureIndex);
        binaryWriter.Write(SolverMode);
        binaryWriter.Write(RigidMeshIndex);
        binaryWriter.Write(ColumnSegments);
        binaryWriter.Write(RowSegments);
        binaryWriter.Write(SampleColumn);
        binaryWriter.Write(SampleRow);
        binaryWriter.Write(SampleRadiusColumn);
        binaryWriter.Write(SampleRadiusRow);
        binaryWriter.Write(Padding);
        binaryWriter.Write(Anchors, lengthPrefixed: false);
    }
}
