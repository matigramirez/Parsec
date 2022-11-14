using Parsec.Attributes;

namespace Parsec.Shaiya.WLD;

public sealed class TextSound
{
    /// <summary>
    /// .tga texture file
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string TextureName { get; set; }

    [ShaiyaProperty]
    public float Unknown { get; set; }

    /// <summary>
    /// .wav sound file
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string SoundName { get; set; }
}
