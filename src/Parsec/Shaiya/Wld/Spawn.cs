using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents a spawn area in the world
/// </summary>
public sealed class Spawn
{
    /// <summary>
    /// Almost always 1
    /// </summary>
    [ShaiyaProperty]
    public int Unknown1 { get; set; }

    /// <summary>
    /// The spawn area
    /// </summary>
    [ShaiyaProperty]
    public BoundingBox Area { get; set; }

    /// <summary>
    /// TODO: Check that "DistanceToCenter" fits this field
    /// </summary>
    [ShaiyaProperty]
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// Faction which uses this spawn area
    /// </summary>
    [ShaiyaProperty]
    public FactionInt Faction { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    [ShaiyaProperty]
    public int Unknown3 { get; set; }
}
