using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
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

        [JsonIgnore]
        public override string Extension => "svmap";

        public override void Read(params object[] options)
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

        public override byte[] GetBytes(params object[] options)
        {
            // TODO: There's something off about the writing process, it needs to be reviewed
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(MapSize));
            buffer.AddRange(MapHeight);
            buffer.AddRange(BitConverter.GetBytes(Unknown));

            buffer.AddRange(BitConverter.GetBytes(Ladders.Count));

            foreach (var ladder in Ladders)
                buffer.AddRange(ladder.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(MonsterAreas.Count));

            foreach (var monsterArea in MonsterAreas)
                buffer.AddRange(monsterArea.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Npcs.Count));

            foreach (var npc in Npcs)
                buffer.AddRange(npc.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Portals.Count));

            foreach (var portal in Portals)
                buffer.AddRange(portal.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Spawns.Count));

            foreach (var spawn in Spawns)
                buffer.AddRange(spawn.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(NamedAreas.Count));

            foreach (var namedArea in NamedAreas)
                buffer.AddRange(namedArea.GetBytes());

            return buffer.ToArray();
        }
    }
}
