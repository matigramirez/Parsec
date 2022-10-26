using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Ani;

public sealed class RotationFrame
{
    [ShaiyaProperty]
    public int Keyframe { get; set; }

    [ShaiyaProperty]
    public Quaternion Quaternion { get; set; }
}
