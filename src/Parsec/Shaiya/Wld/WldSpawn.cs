using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

/// <summary>
/// Represents a spawn area in the world
/// </summary>
public sealed class WldSpawn : ISerializable
{
    /// <summary>
    /// Almost always 1
    /// </summary>
    public int Unknown1 { get; set; }

    /// <summary>
    /// The spawn area
    /// </summary>
    public BoundingBox BoundingBox { get; set; } = new();

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// Faction which uses this spawn area
    /// </summary>
    public WldFaction Faction { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    public int Unknown3 { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.ReadInt32();
        BoundingBox = binaryReader.Read<BoundingBox>();
        Radius = binaryReader.ReadSingle();
        Faction = (WldFaction)binaryReader.ReadInt32();
        Unknown3 = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(BoundingBox);
        binaryWriter.Write(Radius);
        binaryWriter.Write((int)Faction);
        binaryWriter.Write(Unknown3);
    }
}
