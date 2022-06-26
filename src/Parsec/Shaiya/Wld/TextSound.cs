using Parsec.Attributes;

namespace Parsec.Shaiya.WLD;

public class TextSound
{
    /// <summary>
    /// .tga texture file
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(256)]
    public string TextureName { get; set; }

    [ShaiyaProperty]
    public float Unknown { get; set; }

    /// <summary>
    /// .wav sound file
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(256)]
    public string SoundName { get; set; }
}
