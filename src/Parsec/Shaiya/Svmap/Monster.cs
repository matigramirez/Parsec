using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    public class Monster : IBinary
    {
        public int MobId { get; set; }
        public int Count { get; set; }

        public Monster(ShaiyaBinaryReader binaryReader)
        {
            MobId = binaryReader.Read<int>();
            Count = binaryReader.Read<int>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(MobId));
            buffer.AddRange(BitConverter.GetBytes(Count));
            return buffer.ToArray();
        }
    }
}
