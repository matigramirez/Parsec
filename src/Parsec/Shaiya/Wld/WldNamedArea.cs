using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public enum WldNamedAreaMode
{
    WorldIndexTxt = 0,
    BmpFile = 2
}

/// <summary>
/// Represents a NamedArea in the world
/// </summary>
public sealed class WldNamedArea : ISerializable
{
    /// <summary>
    /// The BoundingBox where this Named Area applies
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// Multipurpose, its value depends on <see cref="Mode"/>
    /// If Mode is 0, it reads the caption from world_index.txt
    /// If Mode is 2, this field defines the bmp file for the area's name
    /// </summary>
    public String256 Text1 { get; set; } = string.Empty;

    /// <summary>
    /// Comment or file name (unlocalized - Korean)
    /// </summary>
    public String256 Text2 { get; set; } = string.Empty;

    /// <summary>
    /// Defines the mode for <see cref="Text1"/>
    /// </summary>
    public WldNamedAreaMode Mode { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    public int Unknown { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
        Text1 = binaryReader.Read<String256>();
        Text2 = binaryReader.Read<String256>();
        Mode = (WldNamedAreaMode)binaryReader.ReadInt32();
        Unknown = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
        binaryWriter.Write(Text1);
        binaryWriter.Write(Text2);
        binaryWriter.Write((int)Mode);
        binaryWriter.Write(Unknown);
    }
}
