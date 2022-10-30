using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Ani;

/// <summary>
/// Class that represents the information for each bone present in the ani file
/// </summary>
public sealed class Bone
{
    /// <summary>
    /// The index of the bone which matches the .3DC bone
    /// </summary>
    public int BoneIndex { get; set; }

    /// <summary>
    /// The bone's parent bone index
    /// </summary>
    [ShaiyaProperty]
    public int ParentBoneIndex { get; set; }

    /// <summary>
    /// The transformation matrix for the initial position of the bone
    /// </summary>
    [ShaiyaProperty]
    public Matrix4x4 Matrix { get; set; }

    /// <summary>
    /// List of rotations for each keyframe
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(RotationFrame))]
    public List<RotationFrame> RotationFrames { get; set; } = new();

    /// <summary>
    /// List of translations for each keyframe
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(TranslationFrame))]
    public List<TranslationFrame> TranslationFrames { get; set; } = new();
}
