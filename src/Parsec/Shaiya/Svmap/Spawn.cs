using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    public class Spawn : IBinary
    {
        public int Unknown1 { get; set; }
        public Faction Faction { get; set; }
        public int Unknown2 { get; set; }
        public CubicArea Area { get; set; }

        public Spawn(ShaiyaBinaryReader binaryReader)
        {
            Unknown1 = binaryReader.Read<int>();
            Faction = (Faction)binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<int>();
            Area = new CubicArea(binaryReader);
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Unknown1));
            buffer.AddRange(BitConverter.GetBytes((int)Faction));
            buffer.AddRange(BitConverter.GetBytes(Unknown2));
            buffer.AddRange(Area.GetBytes());
            return buffer.ToArray();
        }
    }
}
