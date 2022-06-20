using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Coordinates to place a 3D object in the field. Used by 'MANI' entities only.
/// </summary>
public class ManiCoordinate
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
    /// Rotation vector
    /// </summary>
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Scaling vector - almost always (0, 1, 0)
    /// </summary>
    public Vector3 Scaling { get; set; }

    public ManiCoordinate(SBinaryReader binaryReader)
    {
        Unknown = binaryReader.Read<int>();
        Id = binaryReader.Read<int>();
        Position = new Vector3(binaryReader);
        Rotation = new Vector3(binaryReader);
        Scaling = new Vector3(binaryReader);
    }
}
