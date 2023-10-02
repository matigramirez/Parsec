using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Coordinates to place a 3D object in the field. Used by 'MANI' entities only.
/// </summary>
public sealed class WldManiCoordinate : IBinary
{
    /// <summary>
    /// Id of the building that should be animated using this MAni file
    /// </summary>
    public int WorldBuildingId { get; set; }

    /// <summary>
    /// Id of a 3D Model
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// World position where to place the model
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

    [JsonConstructor]
    public WldManiCoordinate()
    {
    }

    public WldManiCoordinate(SBinaryReader binaryReader)
    {
        WorldBuildingId = binaryReader.Read<int>();
        Id = binaryReader.Read<int>();
        Position = new Vector3(binaryReader);
        RotationForward = new Vector3(binaryReader);
        RotationUp = new Vector3(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(WorldBuildingId.GetBytes());
        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Position.GetBytes());
        buffer.AddRange(RotationForward.GetBytes());
        buffer.AddRange(RotationUp.GetBytes());
        return buffer;
    }
}
