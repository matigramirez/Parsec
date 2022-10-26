using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.SMOD;

/// <summary>
/// A 3d object used in SMOD files to represent an object where players should collide.
/// </summary>
public sealed class CollisionObject
{
    /// <summary>
    /// Vertices of the 3d object.
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(SimpleVertex))]
    public List<SimpleVertex> Vertices { get; set; } = new();

    /// <summary>
    /// Triangular faces (polygons) of the 3d object.
    /// </summary>
    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Face))]
    public List<Face> Faces { get; set; } = new();
}
