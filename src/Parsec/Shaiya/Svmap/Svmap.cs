using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class Svmap : FileBase
{
    [JsonConstructor]
    public Svmap()
    {
    }

    public int MapSize { get; set; }
    public List<byte> MapHeight { get; private set; } = new();
    public int CellSize { get; set; }
    public List<Ladder> Ladders { get; } = new();
    public List<MonsterArea> MonsterAreas { get; } = new();
    public List<Npc> Npcs { get; } = new();
    public List<Portal> Portals { get; } = new();
    public List<Spawn> Spawns { get; } = new();
    public List<NamedArea> NamedAreas { get; } = new();

    [JsonIgnore]
    public override string Extension => "svmap";

    public override void Read(params object[] options)
    {
        MapSize = _binaryReader.Read<int>();
        int mapHeightCount = MapSize * MapSize / 8;
        MapHeight = _binaryReader.ReadBytes(mapHeightCount).ToList();
        CellSize = _binaryReader.Read<int>();

        int ladderCount = _binaryReader.Read<int>();
        for (int i = 0; i < ladderCount; i++)
            Ladders.Add(new Ladder(_binaryReader));

        int monsterAreaCount = _binaryReader.Read<int>();
        for (int i = 0; i < monsterAreaCount; i++)
            MonsterAreas.Add(new MonsterArea(_binaryReader));

        int npcCount = _binaryReader.Read<int>();
        for (int i = 0; i < npcCount; i++)
            Npcs.Add(new Npc(_binaryReader));

        int portalCount = _binaryReader.Read<int>();
        for (int i = 0; i < portalCount; i++)
            Portals.Add(new Portal(_binaryReader));

        int spawnCount = _binaryReader.Read<int>();
        for (int i = 0; i < spawnCount; i++)
            Spawns.Add(new Spawn(_binaryReader));

        int namedAreaCount = _binaryReader.Read<int>();
        for (int i = 0; i < namedAreaCount; i++)
            NamedAreas.Add(new NamedArea(_binaryReader));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(MapSize.GetBytes());
        buffer.AddRange(MapHeight);
        buffer.AddRange(CellSize.GetBytes());
        buffer.AddRange(Ladders.GetBytes());
        buffer.AddRange(MonsterAreas.GetBytes());
        buffer.AddRange(Npcs.GetBytes());
        buffer.AddRange(Portals.GetBytes());
        buffer.AddRange(Spawns.GetBytes());
        buffer.AddRange(NamedAreas.GetBytes());
        return buffer;
    }
}
