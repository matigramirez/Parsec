using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Coordinates to place a 3D model in the world
/// </summary>
public sealed class Coordinate
{
    /// <summary>
    /// Id of a 3D Model
    /// </summary>
    [ShaiyaProperty]
    public int Id { get; set; }

    /// <summary>
    /// World position where to place the model
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Position { get; set; }

    /// <summary>
    /// Rotation vector
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Scale vector - almost always (0, 1, 0)
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Scale { get; set; }
}
