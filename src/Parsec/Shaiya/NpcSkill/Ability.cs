using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcSkill
{
    public class Ability : IBinary
    {
        public byte Type { get; set; }
        public short Value { get; set; }

        [JsonConstructor]
        public Ability()
        {
        }

        public Ability(SBinaryReader binaryReader)
        {
            Type = binaryReader.Read<byte>();
            Value = binaryReader.Read<short>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.Add(Type);
            buffer.AddRange(BitConverter.GetBytes(Value));
            return buffer.ToArray();
        }
    }
}
