using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Represents a box where monsters can't attack players. This is used only in dungeons to prevent attack exploits from players.
/// Even though this information is present in the world file they have no effect as they are hard-coded in the server files.
/// </summary>
public class WldMonsterRestrictedZone : ISerializable
{
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// This is supposed to be the BoundingBox Radius, but it's unused and its value is always 0.
    /// </summary>
    public float Radius { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
    }
}
