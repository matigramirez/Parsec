using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents an effect in the world
/// </summary>
public sealed class WldEffect : IBinary
{
    /// <summary>
    /// Effect's position
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Rotation about the forward vector
    /// </summary>
    public Vector3 RotationForward { get; set; }

    /// <summary>
    /// Rotation about the up vector
    /// </summary>
    public Vector3 RotationUp { get; set; }

    /// <summary>
    /// Identifier of the effect from the linked .eft file
    /// </summary>
    public int EffectId { get; set; }

    [JsonConstructor]
    public WldEffect()
    {
    }

    public WldEffect(SBinaryReader binaryReader)
    {
        Position = new Vector3(binaryReader);
        RotationForward = new Vector3(binaryReader);
        RotationUp = new Vector3(binaryReader);
        EffectId = binaryReader.Read<int>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Position.GetBytes());
        buffer.AddRange(RotationForward.GetBytes());
        buffer.AddRange(RotationUp.GetBytes());
        buffer.AddRange(EffectId.GetBytes());
        return buffer;
    }
}
