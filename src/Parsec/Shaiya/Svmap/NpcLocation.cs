using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class NpcLocation : IBinary
    {
        public Vector3 Position { get; set; }
        public float Orientation { get; set; }

        public NpcLocation(SBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
            Orientation = binaryReader.Read<float>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Position.GetBytes());
            buffer.AddRange(BitConverter.GetBytes(Orientation));
            return buffer.ToArray();
        }
    }
}
