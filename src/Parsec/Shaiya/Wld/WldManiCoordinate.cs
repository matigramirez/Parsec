using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Coordinates to place a 3D object in the field. Used by 'MANI' entities only.
/// </summary>
public sealed class WldManiCoordinate : IBinary
{
    /// <summary>
    /// Unknown field
    /// </summary>
    public int Unknown { get; set; }

    /// <summary>
    /// Id of a 3D Model
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// World position where to place the model
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Rotation about the up vector
    /// </summary>
    public Vector3 RotationUp { get; set; }

    /// <summary>
    /// Rotation about the forward vector
    /// </summary>
    public Vector3 RotationForward { get; set; }

    [JsonConstructor]
    public WldManiCoordinate()
    {
    }

    public WldManiCoordinate(SBinaryReader binaryReader)
    {
        Unknown = binaryReader.Read<int>();
        Id = binaryReader.Read<int>();
        Position = new Vector3(binaryReader);
        RotationUp = new Vector3(binaryReader);
        RotationForward = new Vector3(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Unknown.GetBytes());
        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Position.GetBytes());
        buffer.AddRange(RotationUp.GetBytes());
        buffer.AddRange(RotationForward.GetBytes());
        return buffer;
    }
}
