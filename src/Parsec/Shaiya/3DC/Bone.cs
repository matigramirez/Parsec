using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya._3DC;

public sealed class Bone
{
    /// <summary>
    /// The transformation matrix of this bone, which holds the starting position and rotation of the bone
    /// </summary>
    [ShaiyaProperty]
    public Matrix4x4 Matrix { get; set; }
}
