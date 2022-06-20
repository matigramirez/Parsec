using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Represents a Portal in the world
/// </summary>
public class Portal
{
    /// <summary>
    /// The area of the portal
    /// </summary>
    public BoundingBox Area { get; set; }

    /// <summary>
    /// Usually 0L. Possibly a condition to use the portal (Level? maybe it's 2 int values with minLevel and maxLevel?)
    /// </summary>
    public int Unknown_1 { get; set; }

    /// <summary>
    /// 256-byte non-localized string, usually korean characters
    /// </summary>
    public string Text1 { get; set; }
    /// <summary>
    /// 256-byte non-localized string, usually empty
    /// </summary>
    public string Text2 { get; set; }

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
    public byte Unknown_2 { get; set; }

    /// <summary>
    /// The destination position
    /// </summary>
    public Vector3 Position { get; set; }

    public Portal(SBinaryReader binaryReader)
    {
        Area = new BoundingBox(binaryReader);
        Unknown_1 = binaryReader.Read<int>();
        Text1 = binaryReader.ReadString(256);
        Text2 = binaryReader.ReadString(256);
        MapId = binaryReader.Read<byte>();
        Faction = (FactionShort)binaryReader.Read<short>();
        Unknown_2 = binaryReader.Read<byte>();
        Position = new Vector3(binaryReader);
    }
}
