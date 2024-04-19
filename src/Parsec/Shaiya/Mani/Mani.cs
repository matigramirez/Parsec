using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mani;

/// <summary>
/// Represents a .mani file. Its used to define an animation for an SMOD object, that's where the extension comes
/// from, given by "Mesh Animation"
/// </summary>
public sealed class Mani : FileBase
{
    /// <summary>
    /// Always 0x21 = 33
    /// </summary>
    public int Version { get; set; }

    public int Unknown1 { get; set; }

    public Vector3 UnknownVec1 { get; set; } = new();

    public float Unknown2 { get; set; }

    public float Unknown3 { get; set; }

    public float Unknown4 { get; set; }

    public int Unknown5 { get; set; }

    public int Unknown6 { get; set; }

    public Vector3 UnknownVec2 { get; set; } = new();

    public float Unknown7 { get; set; }

    public float Unknown8 { get; set; }

    /// <summary>
    /// Indicates if the object should rotate
    /// </summary>
    public int EnableRotation { get; set; }

    /// <summary>
    /// Indicates the axis of rotation of the object, -1f or 1f values should be used
    /// </summary>
    public Vector3 Rotation { get; set; } = new();

    /// <summary>
    /// Animation Speed [0.0f, 1.0f]
    /// </summary>
    public float AnimationSpeed { get; set; }

    public short UnknownShort1 { get; set; }

    public short UnknownShort2 { get; set; }

    public Vector3 UnknownVec4 { get; set; } = new();

    public float Unknown11 { get; set; }

    public float Unknown12 { get; set; }

    public int Unknown13 { get; set; }

    public override string Extension => "mani";

    protected override void Read(SBinaryReader binaryReader)
    {
        Version = binaryReader.ReadInt32();
        Unknown1 = binaryReader.ReadInt32();
        UnknownVec1 = binaryReader.Read<Vector3>();
        Unknown2 = binaryReader.ReadSingle();
        Unknown3 = binaryReader.ReadSingle();
        Unknown4 = binaryReader.ReadSingle();
        Unknown5 = binaryReader.ReadInt32();
        Unknown6 = binaryReader.ReadInt32();
        UnknownVec2 = binaryReader.Read<Vector3>();
        Unknown7 = binaryReader.ReadSingle();
        Unknown8 = binaryReader.ReadSingle();
        EnableRotation = binaryReader.ReadInt32();
        Rotation = binaryReader.Read<Vector3>();
        AnimationSpeed = binaryReader.ReadSingle();
        UnknownShort1 = binaryReader.ReadInt16();
        UnknownShort2 = binaryReader.ReadInt16();
        UnknownVec4 = binaryReader.Read<Vector3>();
        Unknown11 = binaryReader.ReadSingle();
        Unknown12 = binaryReader.ReadSingle();
        Unknown13 = binaryReader.ReadInt32();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Version);
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(UnknownVec1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Unknown3);
        binaryWriter.Write(Unknown4);
        binaryWriter.Write(Unknown5);
        binaryWriter.Write(Unknown6);
        binaryWriter.Write(UnknownVec2);
        binaryWriter.Write(Unknown7);
        binaryWriter.Write(Unknown8);
        binaryWriter.Write(EnableRotation);
        binaryWriter.Write(Rotation);
        binaryWriter.Write(AnimationSpeed);
        binaryWriter.Write(UnknownShort1);
        binaryWriter.Write(UnknownShort2);
        binaryWriter.Write(UnknownVec4);
        binaryWriter.Write(Unknown11);
        binaryWriter.Write(Unknown12);
        binaryWriter.Write(Unknown13);
    }
}
