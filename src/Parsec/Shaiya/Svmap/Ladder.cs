using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap
{
    public class Ladder : IBinary
    {
        public Vector3 Position { get; set; }

        public Ladder(ShaiyaBinaryReader binaryReader)
        {
            Position = new Vector3(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Position.GetBytes());
            return buffer.ToArray();
        }
    }
}
