using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Smod;

/// <summary>
/// Represents a vertex used in SMOD collision objects
/// </summary>
public sealed class SmodCollisionMeshVertex : ISerializable
{
    /// <summary>
    /// Coordinates of the vertex in the 3D space.
    /// </summary>
    public Vector3 Coordinates { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
    }
}
