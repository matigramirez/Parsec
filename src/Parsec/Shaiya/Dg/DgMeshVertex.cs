using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Dg;

public class DgMeshVertex : ISerializable
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
    public Vector2 TextureUV { get; set; }

    /// <summary>
    /// Lightmap mapping
    /// </summary>
    public Vector2 LightmapUV { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        Normal = binaryReader.Read<Vector3>();
        BoneId = binaryReader.ReadInt32();
        TextureUV = binaryReader.Read<Vector2>();
        LightmapUV = binaryReader.Read<Vector2>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(Normal);
        binaryWriter.Write(BoneId);
        binaryWriter.Write(TextureUV);
        binaryWriter.Write(LightmapUV);
    }
}
