using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public enum NamedAreaMode
{
    WorldIndexTxt = 0,
    BmpFile = 2
}

/// <summary>
/// Represents a NamedArea in the world
/// </summary>
public sealed class NamedArea : IBinary
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
    public String256 Text1 { get; set; }

    /// <summary>
    /// Comment or file name (unlocalized - Korean)
    /// </summary>
    public String256 Text2 { get; set; }

    /// <summary>
    /// Defines the mode for <see cref="Text1"/>
    /// </summary>
    public NamedAreaMode Mode { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    public int Unknown { get; set; }

    [JsonConstructor]
    public NamedArea()
    {
    }

    public NamedArea(SBinaryReader binaryReader)
    {
        BoundingBox = new BoundingBox(binaryReader);
        Radius = binaryReader.Read<float>();
        Text1 = new String256(binaryReader);
        Text2 = new String256(binaryReader);
        Mode = (NamedAreaMode)binaryReader.Read<int>();
        Unknown = binaryReader.Read<int>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(BoundingBox.GetBytes());
        buffer.AddRange(Radius.GetBytes());
        buffer.AddRange(Text1.GetBytes());
        buffer.AddRange(Text2.GetBytes());
        buffer.AddRange(((int)Mode).GetBytes());
        buffer.AddRange(Unknown.GetBytes());
        return buffer;
    }
}
