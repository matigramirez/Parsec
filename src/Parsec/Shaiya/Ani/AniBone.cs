using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani;

/// <summary>
/// Class that represents the information for each bone present in the ani file
/// </summary>
public sealed class AniBone : ISerializable
{
    /// <summary>
    /// The bone's parent bone index
    /// </summary>
    public int ParentBoneIndex { get; set; }

    /// <summary>
    /// The transformation matrix for the initial position of the bone
    /// </summary>
    public Matrix4x4 Matrix { get; set; }

    /// <summary>
    /// List of rotations for each keyframe
    /// </summary>
    public List<AniRotationFrame> RotationFrames { get; set; } = new();

    /// <summary>
    /// List of translations for each keyframe
    /// </summary>
    public List<AniTranslationFrame> TranslationFrames { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        ParentBoneIndex = binaryReader.ReadInt32();
        Matrix = binaryReader.Read<Matrix4x4>();
        RotationFrames = binaryReader.ReadList<AniRotationFrame>().ToList();
        TranslationFrames = binaryReader.ReadList<AniTranslationFrame>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(ParentBoneIndex);
        binaryWriter.Write(Matrix);
        binaryWriter.Write(RotationFrames.ToSerializable());
        binaryWriter.Write(TranslationFrames.ToSerializable());
    }
}
