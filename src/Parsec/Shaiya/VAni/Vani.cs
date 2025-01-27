using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Vani;

public sealed class Vani : FileBase
{
    /// <summary>
    /// Coordinates of the center of the 3d object
    /// </summary>
    public Vector3 Center { get; set; }

    /// <summary>
    /// The distance between the vertices of the <see cref="BoundingBox"/> and the <see cref="Center"/> of the VAni object. Used for game calculations.
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// Rectangular bounding box
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// Amount of frames
    /// </summary>
    public int FrameCount { get; set; }

    /// <summary>
    /// ?
    /// </summary>
    public int Unknown1 { get; set; }

    public List<VaniMesh> Meshes { get; set; } = new();

    public BoundingBox BoundingBox2 { get; set; }

    /// <summary>
    /// Always 00?
    /// </summary>
    public int Unknown2 { get; set; }

    public override string Extension => "VANI";

    protected override void Read(SBinaryReader binaryReader)
    {
        Center = binaryReader.Read<Vector3>();
        Radius = binaryReader.ReadSingle();
        BoundingBox = binaryReader.Read<BoundingBox>();
        var meshCount = binaryReader.ReadInt32();
        FrameCount = binaryReader.ReadInt32();
        Unknown1 = binaryReader.ReadInt32();

        // VaniMesh instances expect the FrameCount to be set as the ExtraOption on the serialization options
        binaryReader.SerializationOptions.ExtraOption = FrameCount;

        Meshes = binaryReader.ReadList<VaniMesh>(meshCount).ToList();
        BoundingBox2 = binaryReader.Read<BoundingBox>();
        Unknown2 = binaryReader.ReadInt32();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Center);
        binaryWriter.Write(Radius);
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Meshes.Count);
        binaryWriter.Write(FrameCount);
        binaryWriter.Write(Unknown1);

        // VaniMesh instances expect the FrameCount to be set as the ExtraOption on the serialization options
        binaryWriter.SerializationOptions.ExtraOption = FrameCount;

        binaryWriter.Write(Meshes.ToSerializable(), lengthPrefixed: false);
        binaryWriter.Write(BoundingBox2);
        binaryWriter.Write(Unknown2);
    }
}
