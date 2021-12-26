using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.KillStatus
{
    public class KillStatusBonus : IBinary
    {
        public KillStatusBonusType Type { get; set; }
        public short Value { get; set; }

        [JsonConstructor]
        public KillStatusBonus()
        {
        }

        public KillStatusBonus(SBinaryReader binaryReader)
        {
            Type = (KillStatusBonusType)binaryReader.Read<byte>();
            Value = binaryReader.Read<short>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.Add((byte)Type);
            buffer.AddRange(BitConverter.GetBytes(Value));

            return buffer.ToArray();
        }
    }
}
