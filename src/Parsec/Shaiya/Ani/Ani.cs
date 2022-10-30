using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani;

/// <summary>
/// Class that represents an .ANI file which is used to animate a .3DC model.
/// </summary>
[DefaultVersion(Episode.EP5)]
[VersionPrefixed(typeof(string), "ANI_V2", Episode.EP6, Episode.EP8)]
public sealed class Ani : FileBase
{
    /// <summary>
    /// Starting keyframe. 0 for most animations
    /// </summary>
    [ShaiyaProperty]
    public int StartKeyframe { get; set; }

    /// <summary>
    /// The ending animation keyframe
    /// </summary>
    [ShaiyaProperty]
    public int EndKeyframe { get; set; }

    /// <summary>
    /// The list of bones with their translations and rotations for each keyframe
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Bone), typeof(short))]
    public List<Bone> Bones { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "ANI";
}
