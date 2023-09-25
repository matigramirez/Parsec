using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MAni;

/// <summary>
/// Represents a .mani file. Its used to define an animation for an SMOD object, that's where the extension comes
/// from, given by "Mesh Animation"
/// </summary>
public sealed class MAni : FileBase
{
    /// <summary>
    /// Always 0x21 = 33
    /// </summary>
    public int Version { get; set; }

    public int Unknown1 { get; set; }

    public Vector3 UnknownVec1 { get; set; }

    public float Unknown2 { get; set; }

    public float Unknown3 { get; set; }

    public float Unknown4 { get; set; }

    public int Unknown5 { get; set; }

    public int Unknown6 { get; set; }

    public Vector3 UnknownVec2 { get; set; }

    public float Unknown7 { get; set; }

    public float Unknown8 { get; set; }

    /// <summary>
    /// Indicates if the object should rotate
    /// </summary>
    public int EnableRotation { get; set; }

    /// <summary>
    /// Indicates the axis of rotation of the object, -1f or 1f values should be used
    /// </summary>
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Animation Speed [0.0f, 1.0f]
    /// </summary>
    public float AnimationSpeed { get; set; }

    public short UnknownShort1 { get; set; }

    public short UnknownShort2 { get; set; }

    public Vector3 UnknownVec4 { get; set; }

    public float Unknown11 { get; set; }

    public float Unknown12 { get; set; }

    public int Unknown13 { get; set; }

    public override string Extension => "mani";

    public override void Read()
    {
        Version = _binaryReader.Read<int>();
        Unknown1 = _binaryReader.Read<int>();
        UnknownVec1 = new Vector3(_binaryReader);
        Unknown2 = _binaryReader.Read<float>();
        Unknown3 = _binaryReader.Read<float>();
        Unknown4 = _binaryReader.Read<float>();
        Unknown5 = _binaryReader.Read<int>();
        Unknown6 = _binaryReader.Read<int>();
        UnknownVec2 = new Vector3(_binaryReader);
        Unknown7 = _binaryReader.Read<float>();
        Unknown8 = _binaryReader.Read<float>();
        EnableRotation = _binaryReader.Read<int>();
        Rotation = new Vector3(_binaryReader);
        AnimationSpeed = _binaryReader.Read<float>();
        UnknownShort1 = _binaryReader.Read<short>();
        UnknownShort2 = _binaryReader.Read<short>();
        UnknownVec4 = new Vector3(_binaryReader);
        Unknown11 = _binaryReader.Read<float>();
        Unknown12 = _binaryReader.Read<float>();
        Unknown13 = _binaryReader.Read<int>();
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Version.GetBytes());
        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(UnknownVec1.GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        buffer.AddRange(Unknown3.GetBytes());
        buffer.AddRange(Unknown4.GetBytes());
        buffer.AddRange(Unknown5.GetBytes());
        buffer.AddRange(Unknown6.GetBytes());
        buffer.AddRange(UnknownVec2.GetBytes());
        buffer.AddRange(Unknown7.GetBytes());
        buffer.AddRange(Unknown8.GetBytes());
        buffer.AddRange(EnableRotation.GetBytes());
        buffer.AddRange(Rotation.GetBytes());
        buffer.AddRange(AnimationSpeed.GetBytes());
        buffer.AddRange(UnknownShort1.GetBytes());
        buffer.AddRange(UnknownShort2.GetBytes());
        buffer.AddRange(UnknownVec4.GetBytes());
        buffer.AddRange(Unknown11.GetBytes());
        buffer.AddRange(Unknown12.GetBytes());
        buffer.AddRange(Unknown13.GetBytes());
        return buffer;
    }
}
