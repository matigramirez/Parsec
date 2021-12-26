using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
{
    public class RotationKeyframe : IBinary
    {
        public int Keyframe { get; set; }
        public Quaternion Quaternion { get; set; }

        public RotationKeyframe(SBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Quaternion = new Quaternion(binaryReader);
        }

        [JsonConstructor]
        public RotationKeyframe()
        {
        }

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Keyframe));
            buffer.AddRange(BitConverter.GetBytes(Quaternion.X));
            buffer.AddRange(BitConverter.GetBytes(Quaternion.Y));
            buffer.AddRange(BitConverter.GetBytes(Quaternion.Z));
            buffer.AddRange(BitConverter.GetBytes(Quaternion.W));
            return buffer.ToArray();
        }
    }
}
