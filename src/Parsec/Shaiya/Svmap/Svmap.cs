using System.Collections.Generic;
using System.Linq;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    public class Svmap : FileBase
    {
        public int MapSize { get; set; }
        private int _mapHeightsCount => MapSize * MapSize / 8;
        public List<byte> MapHeights { get; private set; } = new();
        public int Unknown { get; set; }
        public int LadderCount { get; set; }
        public List<Ladder> Ladders { get; } = new();
        public int MonsterAreaCount { get; set; }
        public List<MonsterArea> MonsterAreas { get; } = new();
        public int NpcCount { get; set; }
        public List<Npc> Npcs { get; } = new();
        public int PortalCount { get; set; }
        public List<Portal> Portals { get; } = new();
        public int SpawnCount { get; set; }
        public List<Spawn> Spawns { get; } = new();
        public int NamedAreaCount { get; set; }
        public List<NamedArea> NamedAreas { get; } = new();

        public Svmap(string path) : base(path)
        {
        }


        public override void Read()
        {
            MapSize = _binaryReader.Read<int>();
            MapHeights = _binaryReader.ReadBytes(_mapHeightsCount).ToList();
            Unknown = _binaryReader.Read<int>();

            LadderCount = _binaryReader.Read<int>();

            for (int i = 0; i < LadderCount; i++)
            {
                var ladder = ReadLadder();
                Ladders.Add(ladder);
            }

            MonsterAreaCount = _binaryReader.Read<int>();

            for (int i = 0; i < MonsterAreaCount; i++)
            {
                var monsterArea = ReadMonsterArea();
                MonsterAreas.Add(monsterArea);
            }

            NpcCount = _binaryReader.Read<int>();

            for (int i = 0; i < NpcCount; i++)
            {
                var npc = ReadNpc();
                Npcs.Add(npc);
            }

            PortalCount = _binaryReader.Read<int>();

            for (int i = 0; i < PortalCount; i++)
            {
                var portal = ReadPortal();
                Portals.Add(portal);
            }

            SpawnCount = _binaryReader.Read<int>();

            for (int i = 0; i < SpawnCount; i++)
            {
                var spawn = ReadSpawn();
                Spawns.Add(spawn);
            }

            NamedAreaCount = _binaryReader.Read<int>();

            for (int i = 0; i < NamedAreaCount; i++)
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
                Count = _binaryReader.Read<int>(),
                Monsters = new List<Monster>()
            };

            // Read monsters
            for (int i = 0; i < monsterArea.Count; i++)
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
                LocationCount = _binaryReader.Read<int>(),
                Locations = new List<NpcLocation>()
            };

            for (int i = 0; i < npc.LocationCount; i++)
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
            Unknown_1 = _binaryReader.Read<int>(),
            Faction = (Faction)_binaryReader.Read<int>(),
            Unknown_2 = _binaryReader.Read<int>(),
            Area = new CubicArea(_binaryReader)
        };

        private NamedArea ReadNamedArea() => new NamedArea
        {
            Area = new CubicArea(_binaryReader),
            NameIdentifier_1 = _binaryReader.Read<int>(),
            NameIdentifier_2 = _binaryReader.Read<int>()
        };
    }
}
