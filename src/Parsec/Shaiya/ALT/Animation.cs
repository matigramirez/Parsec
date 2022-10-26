using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.ALT;

/// <summary>
/// Class that represents an animation record in an ALT file.
/// Throughout the list of animations, there's some of them which have 0-length names, when this happens, the rest of the fields are not present
/// in the file, so they need to be skipped when reading or writing.
/// This is considered a serialization anti-pattern and that's why its read through a custom constructor and written using a custom
/// <see cref="GetBytes"/> method.
/// </summary>
public sealed class Animation : IBinary
{
    [JsonConstructor]
    public Animation()
    {
    }

    public Animation(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();

        // When name is empty, the rest of the fields are not read
        if (string.IsNullOrEmpty(Name))
            return;

        Mode = binaryReader.Read<int>();
        Unknown = binaryReader.Read<int>();
        Float1 = binaryReader.Read<float>();
        Float2 = binaryReader.Read<float>();
        Float3 = binaryReader.Read<float>();
        Float4 = binaryReader.Read<float>();
    }

    public string Name { get; set; }

    /// TODO: In shStudio, Mode is split into 4 separate bytes, investigate if that's correct, since the game client actually reads a single value 4-byte
    public int Mode { get; set; }

    public int Unknown { get; set; }
    public float Float1 { get; set; }
    public float Float2 { get; set; }
    public float Float3 { get; set; }
    public float Float4 { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        // When name is empty, the rest of the fields are not written and the name length must be set to '0'
        if (string.IsNullOrEmpty(Name))
        {
            return 0.GetBytes();
        }

        var buffer = new List<byte>();

        buffer.AddRange(Name.GetLengthPrefixedBytes());
        buffer.AddRange(Mode.GetBytes());
        buffer.AddRange(Unknown.GetBytes());
        buffer.AddRange(Float1.GetBytes());
        buffer.AddRange(Float2.GetBytes());
        buffer.AddRange(Float3.GetBytes());
        buffer.AddRange(Float4.GetBytes());

        return buffer;
    }
}
