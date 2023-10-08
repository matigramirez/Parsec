using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Alt;

/// <summary>
/// Class that represents an animation record in an ALT file.
/// Throughout the list of animations, there's some of them which have 0-length names, when this happens, the rest of the fields are not present
/// in the file, so they need to be skipped when reading or writing.
/// </summary>
public sealed class AltAnimation : ISerializable
{
    public string Name { get; set; } = string.Empty;

    /// TODO: In shStudio, Mode is split into 4 separate bytes, investigate if that's correct, since the game client actually reads a single value 4-byte
    public int Mode { get; set; }

    public int Unknown { get; set; }

    public float Float1 { get; set; }

    public float Float2 { get; set; }

    public float Float3 { get; set; }

    public float Float4 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();

        // When name is empty, the rest of the fields are not read
        if (string.IsNullOrEmpty(Name))
            return;

        Mode = binaryReader.ReadInt32();
        Unknown = binaryReader.ReadInt32();
        Float1 = binaryReader.ReadSingle();
        Float2 = binaryReader.ReadSingle();
        Float3 = binaryReader.ReadSingle();
        Float4 = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        // When name is empty, the rest of the fields are not written and the name length must be set to '0'
        if (string.IsNullOrEmpty(Name))
        {
            binaryWriter.Write(0);
            return;
        }

        binaryWriter.Write(Name);
        binaryWriter.Write(Mode);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(Float1);
        binaryWriter.Write(Float2);
        binaryWriter.Write(Float3);
        binaryWriter.Write(Float4);
    }
}
