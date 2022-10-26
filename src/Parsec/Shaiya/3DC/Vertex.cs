using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya._3DC;

public sealed class Vertex
{
    /// <summary>
    /// The vertex's 3d coordinates
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Coordinates { get; set; }

    /// <summary>
    /// If the 3DC file's format is EP5 or inferior, this value is shared between <see cref="BoneVertexGroup1" /> and
    /// <see cref="BoneVertexGroup2" />, it indicates the weight of this vertex for those vertex groups.
    /// If the file's format is EP6 or superior, this value is the weight for <see cref="BoneVertexGroup1" /> only.
    /// </summary>
    [ShaiyaProperty]
    public float Bone1Weight { get; set; }

    /// <summary>
    /// Bone weight for <see cref="BoneVertexGroup2" /> Present in EP6+ format only
    /// </summary>
    [ShaiyaProperty(Episode.EP6, Episode.EP8)]
    public float Bone2Weight { get; set; }

    /// <summary>
    /// Present in EP6+ format
    /// </summary>
    [ShaiyaProperty(Episode.EP6, Episode.EP8)]
    public float Bone3Weight { get; set; }

    /// <summary>
    /// The first vertex group this vertex belongs. The vertex group belongs to a bone.
    /// </summary>
    [ShaiyaProperty]
    public byte BoneVertexGroup1 { get; set; }

    /// <summary>
    /// The second vertex group this vertex belongs. The vertex group belongs to a bone.
    /// </summary>
    [ShaiyaProperty]
    public byte BoneVertexGroup2 { get; set; }

    /// <summary>
    /// The third vertex group this vertex belongs. The vertex group belongs to a bone.
    /// </summary>
    [ShaiyaProperty]
    public byte BoneVertexGroup3 { get; set; }

    /// <summary>
    /// Unknown byte. Always 0.
    /// </summary>
    [ShaiyaProperty]
    public byte Unknown { get; set; }

    /// <summary>
    /// Normal of this point, used for lighting computation.
    /// </summary>
    [ShaiyaProperty]
    public Vector3 Normal { get; set; }

    /// <summary>
    /// UV mapping for the 2D texture. For more information visit
    /// <a href="https://en.wikipedia.org/wiki/UV_mapping">this link</a>.
    /// </summary>
    [ShaiyaProperty]
    public Vector2 UV { get; set; }
}
