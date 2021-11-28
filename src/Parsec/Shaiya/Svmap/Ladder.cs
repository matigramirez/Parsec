using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SVMAP
{
    public class Ladder : IBinary
    {
        public Vector3 Position { get; set; }

        public Ladder(ShaiyaBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(Position.GetBytes());
            return buffer.ToArray();
        }
    }
}
