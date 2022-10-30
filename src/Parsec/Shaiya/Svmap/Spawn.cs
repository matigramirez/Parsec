using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Spawn : IBinary
{
    [JsonConstructor]
    public Spawn()
    {
    }

    public Spawn(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.Read<int>();
        Faction = (FactionInt)binaryReader.Read<int>();
        Unknown2 = binaryReader.Read<int>();
        Area = new BoundingBox(binaryReader);
    }

    public int Unknown1 { get; set; }
    public FactionInt Faction { get; set; }
    public int Unknown2 { get; set; }
    public BoundingBox Area { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(((int)Faction).GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        buffer.AddRange(Area.GetBytes());
        return buffer;
    }
}
