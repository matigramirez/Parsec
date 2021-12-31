using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
{
    public class Rotation : IBinary
    {
        public int Keyframe { get; set; }
        public Quaternion Quaternion { get; set; }

        [JsonConstructor]
        public Rotation()
        {
        }

        public Rotation(SBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Quaternion = new Quaternion(binaryReader);
        }

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Keyframe.GetBytes());
            buffer.AddRange(Quaternion.GetBytes());
            return buffer.ToArray();
        }
    }
}
