using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Represents an effect in the world
/// </summary>
public sealed class WldEffect : ISerializable
{
    /// <summary>
    /// Effect's position
    /// </summary>
    public Vector3 Position { get; set; } = new();

    /// <summary>
    /// Rotation about the forward vector
    /// </summary>
    public Vector3 RotationForward { get; set; } = new();

    /// <summary>
    /// Rotation about the up vector
    /// </summary>
    public Vector3 RotationUp { get; set; } = new();

    /// <summary>
    /// Identifier of the effect from the linked .eft file
    /// </summary>
    public int EffectId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Position = binaryReader.Read<Vector3>();
        RotationForward = binaryReader.Read<Vector3>();
        RotationUp = binaryReader.Read<Vector3>();
        EffectId = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Position);
        binaryWriter.Write(RotationForward);
        binaryWriter.Write(RotationUp);
        binaryWriter.Write(EffectId);
    }
}
