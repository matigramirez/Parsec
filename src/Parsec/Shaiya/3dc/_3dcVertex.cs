using Parsec.Common;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3dc;

public sealed class _3dcVertex : ISerializable
{
    /// <summary>
    /// The vertex's 3d coordinates
    /// </summary>
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// If the 3DC file's format is EP5 or inferior, this value is shared between <see cref="BoneVertexGroup1" /> and
    /// <see cref="BoneVertexGroup2" />, it indicates the weight of this vertex for those vertex groups.
    /// If the file's format is EP6 or superior, this value is the weight for <see cref="BoneVertexGroup1" /> only.
    /// </summary>
    public float Bone1Weight { get; set; }

    /// <summary>
    /// Bone weight for <see cref="BoneVertexGroup2" /> Present in EP6+ format only
    /// </summary>
    public float Bone2Weight { get; set; }

    /// <summary>
    /// Present in EP6+ format
    /// </summary>
    public float Bone3Weight { get; set; }

    /// <summary>
    /// The first vertex group this vertex belongs. The vertex group belongs to a bone.
    /// </summary>
    public byte BoneVertexGroup1 { get; set; }

    /// <summary>
    /// The second vertex group this vertex belongs. The vertex group belongs to a bone.
    /// </summary>
    public byte BoneVertexGroup2 { get; set; }

    /// <summary>
    /// The third vertex group this vertex belongs. The vertex group belongs to a bone.
    /// </summary>
    public byte BoneVertexGroup3 { get; set; }

    /// <summary>
    /// Unknown byte. Always 0.
    /// </summary>
    public byte Unknown { get; set; }

    /// <summary>
    /// Normal of this point, used for lighting computation.
    /// </summary>
    public Vector3 Normal { get; set; }

    /// <summary>
    /// UV mapping for the 2D texture. For more information visit
    /// <a href="https://en.wikipedia.org/wiki/UV_mapping">this link</a>.
    /// </summary>
    public Vector2 UV { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        Bone1Weight = binaryReader.ReadSingle();

        if (binaryReader.SerializationOptions.Episode >= Episode.EP6)
        {
            Bone2Weight = binaryReader.ReadSingle();
            Bone3Weight = binaryReader.ReadSingle();
        }

        BoneVertexGroup1 = binaryReader.ReadByte();
        BoneVertexGroup2 = binaryReader.ReadByte();
        BoneVertexGroup3 = binaryReader.ReadByte();
        Unknown = binaryReader.ReadByte();
        Normal = binaryReader.Read<Vector3>();
        UV = binaryReader.Read<Vector2>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(Bone1Weight);

        if (binaryWriter.SerializationOptions.Episode >= Episode.EP6)
        {
            binaryWriter.Write(Bone2Weight);
            binaryWriter.Write(Bone3Weight);
        }

        binaryWriter.Write(BoneVertexGroup1);
        binaryWriter.Write(BoneVertexGroup2);
        binaryWriter.Write(BoneVertexGroup3);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(Normal);
        binaryWriter.Write(UV);
    }
}
