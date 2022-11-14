using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

public enum NamedAreaMode
{
    WorldIndexTxt = 0,
    BmpFile = 2
}

/// <summary>
/// Represents a NamedArea in the world
/// </summary>
public sealed class NamedArea
{
    /// <summary>
    /// The BoundingBox where this Named Area applies
    /// </summary>
    [ShaiyaProperty]
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// TODO: Check that "DistanceToCenter" fits this field
    /// </summary>
    [ShaiyaProperty]
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// Multipurpose, its value depends on <see cref="Mode"/>
    /// If Mode is 0, it reads the caption from world_index.txt
    /// If Mode is 2, this field defines the bmp file for the area's name
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string Text1 { get; set; }

    /// <summary>
    /// Comment or file name (unlocalized - Korean)
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string Text2 { get; set; }

    /// <summary>
    /// Defines the mode for <see cref="Text1"/>
    /// </summary>
    [ShaiyaProperty]
    public NamedAreaMode Mode { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    [ShaiyaProperty]
    public int Unknown { get; set; }
}
