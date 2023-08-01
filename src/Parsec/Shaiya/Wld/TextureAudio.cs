using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class TextureAudio : IBinary
{
    /// <summary>
    /// .tga texture file
    /// </summary>
    public String256 TextureName { get; set; }

    public float Unknown { get; set; }

    /// <summary>
    /// .wav sound file
    /// </summary>
    public String256 SoundName { get; set; }

    public TextureAudio(SBinaryReader binaryReader)
    {
        TextureName = new String256(binaryReader);
        Unknown = binaryReader.Read<float>();
        SoundName = new String256(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(TextureName.GetBytes());
        buffer.AddRange(Unknown.GetBytes());
        buffer.AddRange(SoundName.GetBytes());
        return buffer;
    }
}
