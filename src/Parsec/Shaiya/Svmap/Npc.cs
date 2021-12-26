using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Npc : IBinary
    {
        public int Type { get; set; }
        public int NpcId { get; set; }
        public List<NpcLocation> Locations { get; set; } = new();

        public Npc(SBinaryReader binaryReader)
        {
            Type = binaryReader.Read<int>();
            NpcId = binaryReader.Read<int>();

            var locationCount = binaryReader.Read<int>();

            for (int i = 0; i < locationCount; i++)
            {
                var npcLocation = new NpcLocation(binaryReader);
                Locations.Add(npcLocation);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Type));
            buffer.AddRange(BitConverter.GetBytes(NpcId));

            buffer.AddRange(BitConverter.GetBytes(Locations.Count));

            foreach (var location in Locations)
            {
                buffer.AddRange(location.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
