using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// Represents a vertex used in an SMOD mesh
/// </summary>
public sealed class Vertex
{
    /// <summary>
    /// Vertex coordinates in the 3D space
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// Vertex normal used for lighting
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Normal { get; set; }

    /// <summary>
    /// SMOD's don't have bones, that's why this value is always -1.
    /// </summary>
    [ShaiyaProperty]
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// Texture mapping
    /// </summary>
    [ShaiyaProperty]
    public Vector2 UV { get; set; }
}
