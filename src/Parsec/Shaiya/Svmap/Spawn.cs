using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Spawn : IBinary
    {
        public int Unknown1 { get; set; }
        public FactionInt Faction { get; set; }
        public int Unknown2 { get; set; }
        public BoundingBox Area { get; set; }

        [JsonConstructor]
        public Spawn()
        {
        }
        
        public Spawn(SBinaryReader binaryReader)
        {
            Unknown1 = binaryReader.Read<int>();
            Faction = (FactionInt)binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<int>();
            Area = new BoundingBox(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
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
