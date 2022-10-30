using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Ani;

public sealed class TranslationFrame
{
    [ShaiyaProperty]
    public int Keyframe { get; set; }

    [ShaiyaProperty]
    public Vector3 Vector { get; set; }
}
