using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Portal : IBinary
    {
        public Vector3 Position { get; set; }
        public Faction Faction { get; set; }
        public short MinLevel { get; set; }
        public short MaxLevel { get; set; }
        public int DestinationMapId { get; set; }
        public Vector3 DestinationPosition { get; set; }

        public Portal(ShaiyaBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
            Faction = (Faction)binaryReader.Read<int>();
            MinLevel = binaryReader.Read<short>();
            MaxLevel = binaryReader.Read<short>();
            DestinationMapId = binaryReader.Read<int>();
            DestinationPosition = new Vector3(binaryReader);
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Position.GetBytes());
            buffer.AddRange(BitConverter.GetBytes((int)Faction));
            buffer.AddRange(BitConverter.GetBytes(MinLevel));
            buffer.AddRange(BitConverter.GetBytes(MaxLevel));
            buffer.AddRange(BitConverter.GetBytes(DestinationMapId));
            buffer.AddRange(DestinationPosition.GetBytes());
            return buffer.ToArray();
        }
    }
}
