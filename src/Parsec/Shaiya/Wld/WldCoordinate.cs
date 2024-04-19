using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Coordinates to place a 3D model in the world
/// </summary>
public sealed class WldCoordinate : ISerializable
{
    /// <summary>
    /// Id of a 3D Model
    /// </summary>
    public int Id { get; set; }

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
        Id = binaryReader.ReadInt32();
        Position = binaryReader.Read<Vector3>();
        RotationForward = binaryReader.Read<Vector3>();
        RotationUp = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Id);
        binaryWriter.Write(Position);
        binaryWriter.Write(RotationForward);
        binaryWriter.Write(RotationUp);
    }
}
