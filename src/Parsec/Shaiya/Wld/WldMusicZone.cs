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
    /// Id of the wav file (from the linked name list of files)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Usually 0L
    /// </summary>
    public int Unknown { get; set; }

    [JsonConstructor]
    public WldMusicZone()
    {
    }

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
        Id = binaryReader.ReadInt32();
        Unknown = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
        binaryWriter.Write(Id);
        binaryWriter.Write(Unknown);
    }
}
