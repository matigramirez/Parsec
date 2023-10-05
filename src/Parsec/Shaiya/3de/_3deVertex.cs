using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3de;

public sealed class _3deVertex : ISerializable
{
    /// <summary>
    /// Vertex coordinates in the 3D space
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// 3DE's don't have vertex groups like 3DC's, that's why this value is always -1.
    /// </summary>
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// UV Texture mapping
    /// </summary>
    public Vector2 UV { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        BoneId = binaryReader.ReadInt32();
        UV = binaryReader.Read<Vector2>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(BoneId);
        binaryWriter.Write(UV);
    }
}
