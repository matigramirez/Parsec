using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// Represents a vertex used in SMOD collision objects
/// </summary>
public sealed class SimpleVertex
{
    /// <summary>
    /// Coordinates of the vertex in the 3D space.
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Coordinates { get; set; }
}
