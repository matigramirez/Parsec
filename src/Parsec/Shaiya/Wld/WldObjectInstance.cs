using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Represents a world object
/// </summary>
public sealed class WldObjectInstance : ISerializable
{
    /// <summary>
    /// Index of the 3d model in its corresponding category list
    /// </summary>
    public int AssetIndex { get; set; }

    /// <summary>
    /// World position where to place the model
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

    public void Read(SBinaryReader binaryReader)
    {
        AssetIndex = binaryReader.ReadInt32();
        Position = binaryReader.Read<Vector3>();
        RotationForward = binaryReader.Read<Vector3>();
        RotationUp = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(AssetIndex);
        binaryWriter.Write(Position);
        binaryWriter.Write(RotationForward);
        binaryWriter.Write(RotationUp);
    }
}
