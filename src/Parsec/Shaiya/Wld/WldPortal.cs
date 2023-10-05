using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Represents a Portal in the world
/// </summary>
public sealed class WldPortal : ISerializable
{
    /// <summary>
    /// The area of the portal
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// 256-byte non-localized string, usually korean characters
    /// </summary>
    public String256 Text1 { get; set; } = string.Empty;

    /// <summary>
    /// 256-byte non-localized string, usually empty
    /// </summary>
    public String256 Text2 { get; set; } = string.Empty;

    /// <summary>
    /// The destination mapId
    /// </summary>
    public byte MapId { get; set; }

    /// <summary>
    /// The faction which can use the portal (unsigned short)
    /// </summary>
    public WldFaction Faction { get; set; }

    /// <summary>
    /// Almost always 0L
    /// </summary>
    public byte Unknown { get; set; }

    /// <summary>
    /// The destination position
    /// </summary>
    public Vector3 DestinationPosition { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
        Text1 = binaryReader.Read<String256>();
        Text2 = binaryReader.Read<String256>();
        MapId = binaryReader.ReadByte();
        Faction = (WldFaction)binaryReader.ReadInt16();
        Unknown = binaryReader.ReadByte();
        DestinationPosition = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
        binaryWriter.Write(Text1);
        binaryWriter.Write(Text2);
        binaryWriter.Write(MapId);
        binaryWriter.Write((short)Faction);
        binaryWriter.Write(Unknown);
        binaryWriter.Write(DestinationPosition);
    }
}
