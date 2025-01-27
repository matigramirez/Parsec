using Newtonsoft.Json;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// A rectangular area of the world in which music is played
/// </summary>
public sealed class WldMusicZone : ISerializable
{
    /// <summary>
    /// The rectangular area of the music zone
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// Id of the music asset from the MusicAssets list
    /// </summary>
    public int MusicAssetId { get; set; }

    /// <summary>
    /// Usually 0
    /// </summary>
    public int Unknown { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
        MusicAssetId = binaryReader.ReadInt32();
        Unknown = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
        binaryWriter.Write(MusicAssetId);
        binaryWriter.Write(Unknown);
    }
}
