using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// A rectangular area of the world in which music is played
/// </summary>
public sealed class MusicZone
{
    /// <summary>
    /// The rectangular area of the music zone
    /// </summary>
    [ShaiyaProperty]
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// TODO: Check that "DistanceToCenter" fits this field
    /// </summary>
    [ShaiyaProperty]
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// Id of the wav file (from the linked name list of files)
    /// </summary>
    [ShaiyaProperty]
    public int Id { get; set; }

    /// <summary>
    /// Usually 0L
    /// </summary>
    [ShaiyaProperty]
    public int Unknown { get; set; }
}
