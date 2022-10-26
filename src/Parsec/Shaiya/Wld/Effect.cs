using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents an effect in the world
/// </summary>
public sealed class Effect
{
    /// <summary>
    /// Effect's position
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Position { get; set; }

    /// <summary>
    /// Effect's rotation
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Effect's scaling
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Scale { get; set; }

    /// <summary>
    /// Identifier of the effect from the linked .eft file
    /// </summary>
    [ShaiyaProperty]
    public int Id { get; set; }
}
