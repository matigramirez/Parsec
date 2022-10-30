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

    public float Unknown1 { get; set; }
    public Vector3 UnknownVec1 { get; set; }
    public float Unknown2 { get; set; }
    public float Unknown3 { get; set; }
    public float Unknown4 { get; set; }
    public float Unknown5 { get; set; }
    public float Unknown6 { get; set; }
    public Vector3 UnknownVec2 { get; set; }
    public float Unknown7 { get; set; }
    public float Unknown8 { get; set; }
    public float Unknown9 { get; set; }
    public Vector3 UnknownVec3 { get; set; }
    public float Unknown10 { get; set; }
    public short UnknownShort1 { get; set; }
    public short UnknownShort2 { get; set; }
    public Vector3 UnknownVec4 { get; set; }
    public float Unknown11 { get; set; }
    public float Unknown12 { get; set; }
    public float Unknown13 { get; set; }

    public override string Extension => "mani";

    public override void Read(params object[] options)
    {
        Version = _binaryReader.Read<int>();
        Unknown1 = _binaryReader.Read<float>();
        UnknownVec1 = new Vector3(_binaryReader);
        Unknown2 = _binaryReader.Read<float>();
        Unknown3 = _binaryReader.Read<float>();
        Unknown4 = _binaryReader.Read<float>();
        Unknown5 = _binaryReader.Read<float>();
        Unknown6 = _binaryReader.Read<float>();
        UnknownVec2 = new Vector3(_binaryReader);
        Unknown7 = _binaryReader.Read<float>();
        Unknown8 = _binaryReader.Read<float>();
        Unknown9 = _binaryReader.Read<float>();
        UnknownVec3 = new Vector3(_binaryReader);
        Unknown10 = _binaryReader.Read<float>();
        UnknownShort1 = _binaryReader.Read<short>();
        UnknownShort2 = _binaryReader.Read<short>();
        UnknownVec4 = new Vector3(_binaryReader);
        Unknown11 = _binaryReader.Read<float>();
        Unknown12 = _binaryReader.Read<float>();
        Unknown13 = _binaryReader.Read<float>();
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
        buffer.AddRange(Unknown9.GetBytes());
        buffer.AddRange(UnknownVec3.GetBytes());
        buffer.AddRange(Unknown10.GetBytes());
        buffer.AddRange(UnknownShort1.GetBytes());
        buffer.AddRange(UnknownShort2.GetBytes());
        buffer.AddRange(UnknownVec4.GetBytes());
        buffer.AddRange(Unknown11.GetBytes());
        buffer.AddRange(Unknown12.GetBytes());
        buffer.AddRange(Unknown13.GetBytes());
        return buffer;
    }
}
