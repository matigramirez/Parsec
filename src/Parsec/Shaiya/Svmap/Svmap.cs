using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Svmap : FileBase
{
    public int MapSize { get; set; }

    public byte[] MapHeight { get; set; } = Array.Empty<byte>();

    public int CellSize { get; set; }

    public List<SvmapLadder> Ladders { get; set; } = new();

    public List<SvmapMonsterSpawnArea> MonsterAreas { get; set; } = new();

    public List<SvmapNpc> Npcs { get; set; } = new();

    public List<SvmapPortal> Portals { get; set; } = new();

    public List<SvmapSpawnArea> Spawns { get; set; } = new();

    public List<SvmapNamedArea> NamedAreas { get; set; } = new();

    [JsonIgnore]
    public override string Extension => "svmap";

    protected override void Read(SBinaryReader binaryReader)
    {
        MapSize = binaryReader.ReadInt32();
        var mapHeightCount = MapSize * MapSize / 8;
        MapHeight = binaryReader.ReadBytes(mapHeightCount);
        CellSize = binaryReader.ReadInt32();

        Ladders = binaryReader.ReadList<SvmapLadder>().ToList();
        MonsterAreas = binaryReader.ReadList<SvmapMonsterSpawnArea>().ToList();
        Npcs = binaryReader.ReadList<SvmapNpc>().ToList();
        Portals = binaryReader.ReadList<SvmapPortal>().ToList();
        Spawns = binaryReader.ReadList<SvmapSpawnArea>().ToList();
        NamedAreas = binaryReader.ReadList<SvmapNamedArea>().ToList();
    }

    protected override void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MapSize);
        binaryWriter.Write(MapHeight.ToArray());
        binaryWriter.Write(CellSize);
        binaryWriter.Write(Ladders.ToSerializable());
        binaryWriter.Write(MonsterAreas.ToSerializable());
        binaryWriter.Write(Npcs.ToSerializable());
        binaryWriter.Write(Portals.ToSerializable());
        binaryWriter.Write(Spawns.ToSerializable());
        binaryWriter.Write(NamedAreas.ToSerializable());
    }
}
