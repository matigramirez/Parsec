using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;
using Quaternion = Parsec.Shaiya.Common.Quaternion;

namespace Parsec.Shaiya.ANI
{
    public class RotationKeyframe : IBinary
    {
        public int Keyframe { get; set; }
        public Quaternion Quaternion { get; set; }

        public RotationKeyframe(ShaiyaBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Quaternion = new Quaternion(binaryReader);
        }

        /// <inheritdoc />
        public byte[] GetBytes()
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
