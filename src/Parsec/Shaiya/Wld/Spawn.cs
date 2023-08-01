using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

/// <summary>
/// Represents a spawn area in the world
/// </summary>
public sealed class Spawn : IBinary
{
    /// <summary>
    /// Almost always 1
    /// </summary>
    public int Unknown1 { get; set; }

    /// <summary>
    /// The spawn area
    /// </summary>
    public BoundingBox BoundingBox { get; set; }

    /// <summary>
    /// BoundingBox Radius
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    /// Faction which uses this spawn area
    /// </summary>
    public FactionInt Faction { get; set; }

    /// <summary>
    /// Almost always 0
    /// </summary>
    public int Unknown3 { get; set; }

    [JsonConstructor]
    public Spawn()
    {
    }

    public Spawn(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.Read<int>();
        BoundingBox = new BoundingBox(binaryReader);
        Radius = binaryReader.Read<float>();
        Faction = (FactionInt)binaryReader.Read<int>();
        Unknown3 = binaryReader.Read<int>();
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(BoundingBox.GetBytes());
        buffer.AddRange(Radius.GetBytes());
        buffer.AddRange(((int)Faction).GetBytes());
        buffer.AddRange(Unknown1.GetBytes());
        return buffer;
    }
}
