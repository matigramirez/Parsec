using System.Collections.Generic;
using System.Linq;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    public class Svmap : FileBase
    {
        public int MapSize { get; set; }
        public List<byte> MapHeights { get; private set; } = new();
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

            var mapHeightsCount = MapSize * MapSize / 8;
            MapHeights = _binaryReader.ReadBytes(mapHeightsCount).ToList();

            Unknown = _binaryReader.Read<int>();

            var ladderCount = _binaryReader.Read<int>();

            for (int i = 0; i < ladderCount; i++)
            {
                var ladder = ReadLadder();
                Ladders.Add(ladder);
            }

            var monsterAreaCount = _binaryReader.Read<int>();

            for (int i = 0; i < monsterAreaCount; i++)
            {
                var monsterArea = ReadMonsterArea();
                MonsterAreas.Add(monsterArea);
            }

            var npcCount = _binaryReader.Read<int>();

            for (int i = 0; i < npcCount; i++)
            {
                var npc = ReadNpc();
                Npcs.Add(npc);
            }

            var portalCount = _binaryReader.Read<int>();

            for (int i = 0; i < portalCount; i++)
            {
                var portal = ReadPortal();
                Portals.Add(portal);
            }

            var spawnCount = _binaryReader.Read<int>();

            for (int i = 0; i < spawnCount; i++)
            {
                var spawn = ReadSpawn();
                Spawns.Add(spawn);
            }

            var namedAreaCount = _binaryReader.Read<int>();

            for (int i = 0; i < namedAreaCount; i++)
            {
                var namedArea = ReadNamedArea();
                NamedAreas.Add(namedArea);
            }
        }

        private Ladder ReadLadder() => new Ladder
        {
            Position = new Vector3(_binaryReader)
        };

        private MonsterArea ReadMonsterArea()
        {
            var monsterArea = new MonsterArea
            {
                Area = new CubicArea(_binaryReader),
                Monsters = new List<Monster>()
            };

            var monsterCount = _binaryReader.Read<int>();

            // Read monsters
            for (int i = 0; i < monsterCount; i++)
            {
                var monster = new Monster
                {
                    MobId = _binaryReader.Read<int>(),
                    Count = _binaryReader.Read<int>()
                };

                monsterArea.Monsters.Add(monster);
            }

            return monsterArea;
        }

        private Npc ReadNpc()
        {
            var npc = new Npc
            {
                Type = _binaryReader.Read<int>(),
                NpcId = _binaryReader.Read<int>(),
                Locations = new List<NpcLocation>()
            };

            var locationCount = _binaryReader.Read<int>();

            for (int i = 0; i < locationCount; i++)
            {
                var npcLocation = new NpcLocation
                {
                    Position = new Vector3(_binaryReader),
                    Orientation = _binaryReader.Read<float>()
                };

                npc.Locations.Add(npcLocation);
            }

            return npc;
        }

        private Portal ReadPortal() => new Portal
        {
            Position = new Vector3(_binaryReader),
            Faction = (Faction)_binaryReader.Read<int>(),
            MinLevel = _binaryReader.Read<short>(),
            MaxLevel = _binaryReader.Read<short>(),
            DestinationMapId = _binaryReader.Read<int>(),
            DestinationPosition = new Vector3(_binaryReader)
        };

        private Spawn ReadSpawn() => new Spawn
        {
            Unknown1 = _binaryReader.Read<int>(),
            Faction = (Faction)_binaryReader.Read<int>(),
            Unknown2 = _binaryReader.Read<int>(),
            Area = new CubicArea(_binaryReader)
        };

        private NamedArea ReadNamedArea() => new NamedArea
        {
            Area = new CubicArea(_binaryReader),
            NameIdentifier1 = _binaryReader.Read<int>(),
            NameIdentifier2 = _binaryReader.Read<int>()
        };
    }
}
