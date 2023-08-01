using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents a Portal in the world
/// </summary>
public sealed class Portal : IBinary
{
    /// <summary>
    /// The area of the portal
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// TODO: Check that "DistanceToCenter" fits this field
    /// </summary>
    public float DistanceToCenter { get; set; }

    /// <summary>
    /// 256-byte non-localized string, usually korean characters
    /// </summary>
    public String256 Text1 { get; set; }

    /// <summary>
    /// 256-byte non-localized string, usually empty
    /// </summary>
    public String256 Text2 { get; set; }

    /// <summary>
    /// The destination mapId
    /// </summary>
    public byte MapId { get; set; }

    /// <summary>
    /// The faction which can use the portal
    /// </summary>
    public FactionShort Faction { get; set; }

    /// <summary>
    /// Almost always 0L
    /// </summary>
    public byte Unknown { get; set; }

    /// <summary>
    /// The destination position
    /// </summary>
    public Vector3 Position { get; set; }

    public Portal(SBinaryReader binaryReader)
    {
        BoundingBox = new BoundingBox(binaryReader);
        DistanceToCenter = binaryReader.Read<float>();
        Text1 = new String256(binaryReader);
        Text2 = new String256(binaryReader);
        MapId = binaryReader.Read<byte>();
        Faction = (FactionShort)binaryReader.Read<short>();
        Unknown = binaryReader.Read<byte>();
        Position = new Vector3(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(BoundingBox.GetBytes());
        buffer.AddRange(DistanceToCenter.GetBytes());
        buffer.AddRange(Text1.GetBytes());
        buffer.AddRange(Text2.GetBytes());
        buffer.Add(MapId);
        buffer.AddRange(((short)Faction).GetBytes());
        buffer.Add(Unknown);
        buffer.AddRange(Position.GetBytes());
        return buffer;
    }
}
