using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// A circular area of the world in which music is played
/// </summary>
public sealed class MusicSpot
{
    /// <summary>
    /// Id of the wav file (from the linked name list of files)
    /// </summary>
    [ShaiyaProperty]
    public int Id { get; set; }

    /// <summary>
    /// The center point of the circle
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Center { get; set; }

    /// <summary>
    /// The radius of the circle
    /// </summary>
    [ShaiyaProperty]
    public float Radius { get; set; }
}
