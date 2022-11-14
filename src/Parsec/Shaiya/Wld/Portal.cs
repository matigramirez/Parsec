using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents a Portal in the world
/// </summary>
public sealed class Portal
{
    /// <summary>
    /// The area of the portal
    /// </summary>
    [ShaiyaProperty]
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// TODO: Check that "DistanceToCenter" fits this field
    /// </summary>
    [ShaiyaProperty]
    public int DistanceToCenter { get; set; }

    /// <summary>
    /// 256-byte non-localized string, usually korean characters
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string Text1 { get; set; }

    /// <summary>
    /// 256-byte non-localized string, usually empty
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string Text2 { get; set; }

    /// <summary>
    /// The destination mapId
    /// </summary>
    [ShaiyaProperty]
    public byte MapId { get; set; }

    /// <summary>
    /// The faction which can use the portal
    /// </summary>
    [ShaiyaProperty]
    public FactionShort Faction { get; set; }

    /// <summary>
    /// Almost always 0L
    /// </summary>
    [ShaiyaProperty]
    public byte Unknown { get; set; }

    /// <summary>
    /// The destination position
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Position { get; set; }
}
