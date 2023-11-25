using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgSegmentVertex : ISerializable
{
    /// <summary>
    /// Vertex coordinates in the 3D space
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// Vertex normal used for lighting
    /// </summary>
    public Vector3 Normal { get; set; }

    /// <summary>
    /// SMODs don't have bones, that's why this value is always -1.
    /// </summary>
    public int BoneId { get; set; } = -1;

    /// <summary>
    /// Texture mapping
    /// </summary>
    public Vector2 UV { get; set; }

    public float Unknown1 { get; set; }

    public float Unknown2 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        Normal = binaryReader.Read<Vector3>();
        BoneId = binaryReader.ReadInt32();
        UV = binaryReader.Read<Vector2>();
        Unknown1 = binaryReader.ReadSingle();
        Unknown2 = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(Normal);
        binaryWriter.Write(BoneId);
        binaryWriter.Write(UV);
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
    }
}
