using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Coordinates to place a 3D object in the field. Used by 'MANI' entities only.
/// </summary>
public sealed class WldManiCoordinate : ISerializable
{
    /// <summary>
    /// Id of the building from BuildingAssets that should be animated using this MAni file
    /// </summary>
    public int BuildingAssetId { get; set; }

    /// <summary>
    /// Id of the asset from ManiAssets
    /// </summary>
    public int ManiAssetIndex { get; set; }

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

    public void Read(SBinaryReader binaryReader)
    {
        BuildingAssetId = binaryReader.ReadInt32();
        ManiAssetIndex = binaryReader.ReadInt32();
        Position = binaryReader.Read<Vector3>();
        RotationForward = binaryReader.Read<Vector3>();
        RotationUp = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BuildingAssetId);
        binaryWriter.Write(ManiAssetIndex);
        binaryWriter.Write(Position);
        binaryWriter.Write(RotationForward);
        binaryWriter.Write(RotationUp);
    }
}
