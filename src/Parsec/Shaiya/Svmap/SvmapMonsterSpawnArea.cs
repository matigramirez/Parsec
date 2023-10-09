using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

/// <summary>
/// Represents a 2-D area where monsters are spawned
/// </summary>
public sealed class SvmapMonsterSpawnArea : ISerializable
{
    public BoundingBox Area { get; set; }

    public List<SvmapMonsterSpawn> Monsters { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Area = binaryReader.Read<BoundingBox>();
        Monsters = binaryReader.ReadList<SvmapMonsterSpawn>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Area);
        binaryWriter.Write(Monsters.ToSerializable());
    }
}
