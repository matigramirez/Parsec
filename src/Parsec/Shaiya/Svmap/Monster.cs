using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Monster : IBinary
    {
        public int MobId { get; set; }
        public int Count { get; set; }

        [JsonConstructor]
        public Monster()
        {
        }
        
        public Monster(SBinaryReader binaryReader)
        {
            MobId = binaryReader.Read<int>();
            Count = binaryReader.Read<int>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(MobId));
            buffer.AddRange(BitConverter.GetBytes(Count));
            return buffer.ToArray();
        }
    }
}
