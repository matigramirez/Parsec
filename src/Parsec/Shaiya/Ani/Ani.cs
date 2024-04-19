using System.Text.Json.Serialization;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani;

/// <summary>
/// Class that represents an .ANI file which is used to animate a .3DC model.
/// </summary>
public sealed class Ani : FileBase
{
    /// <summary>
    /// Starting keyframe. 0 for most animations
    /// </summary>
    public uint StartKeyframe { get; set; }

    /// <summary>
    /// The ending animation keyframe
    /// </summary>
    public uint EndKeyframe { get; set; }

    /// <summary>
    /// The list of bones with their translations and rotations for each keyframe
    /// </summary>
    public List<AniBone> Bones { get; set; } = new();

    protected override void Read(SBinaryReader binaryReader)
    {
        var signature = binaryReader.ReadString(6);

        if (signature == "ANI_V2")
        {
            Episode = Episode.EP6;
        }
        else
        {
            binaryReader.ResetOffset();
        }

        binaryReader.SerializationOptions.Episode = Episode;

        StartKeyframe = binaryReader.ReadUInt32();
        EndKeyframe = binaryReader.ReadUInt32();

        var boneCount = binaryReader.ReadUInt16();
        Bones = binaryReader.ReadList<AniBone>(boneCount).ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        if (binaryWriter.SerializationOptions.Episode >= Episode.EP6)
        {
            binaryWriter.Write("ANI_V2", isLengthPrefixed: false, includeStringTerminator: false);
        }

        binaryWriter.Write(StartKeyframe);
        binaryWriter.Write(EndKeyframe);
        binaryWriter.Write((ushort)Bones.Count);
        binaryWriter.Write(Bones.ToSerializable(), false);
    }
}
