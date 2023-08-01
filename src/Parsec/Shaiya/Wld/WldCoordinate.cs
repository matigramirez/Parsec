using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Coordinates to place a 3D model in the world
/// </summary>
public sealed class WldCoordinate : IBinary
{
    /// <summary>
    /// Id of a 3D Model
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// World position where to place the model
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Rotation vector
    /// </summary>
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Scale vector - almost always (0, 1, 0)
    /// </summary>
    public Vector3 Scale { get; set; }

    public WldCoordinate(SBinaryReader binaryReader)
    {
        Id = binaryReader.Read<int>();
        Position = new Vector3(binaryReader);
        Rotation = new Vector3(binaryReader);
        Scale = new Vector3(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Id.GetBytes());
        buffer.AddRange(Position.GetBytes());
        buffer.AddRange(Rotation.GetBytes());
        buffer.AddRange(Scale.GetBytes());
        return buffer;
    }
}
