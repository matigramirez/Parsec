using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.NpcQuest
{
    public class GateTarget : IBinary
    {
        private readonly Format _format;
        public short MapId { get; set; }
        public Vector3 Position { get; set; }
        public string TargetName { get; set; }

        /// <summary>
        /// Teleporting gold cost
        /// </summary>
        public int Cost { get; set; }

        public GateTarget(SBinaryReader binaryReader, Format format)
        {
            _format = format;
            MapId = binaryReader.Read<short>();
            Position = new Vector3(binaryReader);
            if (_format <= Format.EP8) // In ep 8, messages are moved to separe translation files.
                TargetName = binaryReader.ReadString(false);
            Cost = binaryReader.Read<int>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(MapId.GetBytes());
            buffer.AddRange(Position.GetBytes());
            if (_format <= Format.EP8) // In ep 8, messages are moved to separe translation files.
                buffer.AddRange(TargetName.GetLengthPrefixedBytes(false));
            buffer.AddRange(Cost.GetBytes());

            return buffer.ToArray();
        }
    }
}
