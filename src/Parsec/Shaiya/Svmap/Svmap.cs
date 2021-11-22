using System.Collections.Generic;
using System.Linq;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    public class Svmap : FileBase
    {
        public int MapSize { get; set; }
        public List<byte> MapHeight { get; private set; } = new();
        public int Unknown { get; set; }
        public List<Ladder> Ladders { get; } = new();
        public List<MonsterArea> MonsterAreas { get; } = new();
        public List<Npc> Npcs { get; } = new();
        public List<Portal> Portals { get; } = new();
        public List<Spawn> Spawns { get; } = new();
        public List<NamedArea> NamedAreas { get; } = new();

        public Svmap(string path) : base(path)
        {
        }

        public override void Read()
        {
            MapSize = _binaryReader.Read<int>();

            var mapHeightCount = MapSize * MapSize / 8;
            MapHeight = _binaryReader.ReadBytes(mapHeightCount).ToList();

            Unknown = _binaryReader.Read<int>();

            var ladderCount = _binaryReader.Read<int>();

            for (int i = 0; i < ladderCount; i++)
            {
                var ladder = new Ladder(_binaryReader);
                Ladders.Add(ladder);
            }

            var monsterAreaCount = _binaryReader.Read<int>();

            for (int i = 0; i < monsterAreaCount; i++)
            {
                var monsterArea = new MonsterArea(_binaryReader);
                MonsterAreas.Add(monsterArea);
            }

            var npcCount = _binaryReader.Read<int>();

            for (int i = 0; i < npcCount; i++)
            {
                var npc = new Npc(_binaryReader);
                Npcs.Add(npc);
            }

            var portalCount = _binaryReader.Read<int>();

            for (int i = 0; i < portalCount; i++)
            {
                var portal = new Portal(_binaryReader);
                Portals.Add(portal);
            }

            var spawnCount = _binaryReader.Read<int>();

            for (int i = 0; i < spawnCount; i++)
            {
                var spawn = new Spawn(_binaryReader);
                Spawns.Add(spawn);
            }

            var namedAreaCount = _binaryReader.Read<int>();

            for (int i = 0; i < namedAreaCount; i++)
            {
                var namedArea = new NamedArea(_binaryReader);
                NamedAreas.Add(namedArea);
            }
        }
    }
}
