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
    public int Unknown1 { get; set; }

    /// <summary>
    /// The spawn area
    /// </summary>
    public BoundingBox Area { get; set; }

    /// <summary>
    /// TODO: Check that "DistanceToCenter" fits this field
    /// </summary>
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// Faction which uses this spawn area
    /// </summary>
    public FactionInt Faction { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    public int Unknown3 { get; set; }
}
