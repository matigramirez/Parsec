using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Vani;

public sealed class VaniVertexFrame : ISerializable
{
    /// <summary>
    /// The vertex coordinates in the 3d space
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// The vertex normal
    /// </summary>
    public Vector3 Normal { get; set; }

    /// <summary>
    /// VAni's don't have bones, that's why this value is always -1.
    /// </summary>
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// Texture mapping
    /// </summary>
    public Vector2 UV { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        Normal = binaryReader.Read<Vector3>();
        BoneId = binaryReader.ReadInt32();
        UV = binaryReader.Read<Vector2>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(Normal);
        binaryWriter.Write(BoneId);
        binaryWriter.Write(UV);
    }
}
