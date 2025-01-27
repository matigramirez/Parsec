using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// A circular area of the world in which music is played
/// </summary>
public sealed class WldSoundEffect : ISerializable
{
    /// <summary>
    /// Id of the sound asset from the SoundEffectAssets list
    /// </summary>
    public int SoundEffectAssetId { get; set; }

    /// <summary>
    /// The center point of the circle
    /// </summary>
    public Vector3 Center { get; set; }

    /// <summary>
    /// The radius of the circle
    /// </summary>
    public float Radius { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        SoundEffectAssetId = binaryReader.ReadInt32();
        Center = binaryReader.Read<Vector3>();
        Radius = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(SoundEffectAssetId);
        binaryWriter.Write(Center);
        binaryWriter.Write(Radius);
    }
}
