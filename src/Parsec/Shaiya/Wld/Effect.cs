using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents an effect in the world
/// </summary>
public sealed class Effect : IBinary
{
    /// <summary>
    /// Effect's position
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Effect's rotation
    /// </summary>
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Effect's scaling
    /// </summary>
    public Vector3 Scale { get; set; }

    /// <summary>
    /// Identifier of the effect from the linked .eft file
    /// </summary>
    public int Id { get; set; }

    public Effect(SBinaryReader binaryReader)
    {
        Position = new Vector3(binaryReader);
        Rotation = new Vector3(binaryReader);
        Scale = new Vector3(binaryReader);
        Id = binaryReader.Read<int>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Position.GetBytes());
        buffer.AddRange(Rotation.GetBytes());
        buffer.AddRange(Scale.GetBytes());
        buffer.AddRange(Id.GetBytes());
        return buffer;
    }
}
