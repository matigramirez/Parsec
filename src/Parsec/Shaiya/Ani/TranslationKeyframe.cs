using System;
using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Core;
using Vector3 = Parsec.Shaiya.Common.Vector3;

namespace Parsec.Shaiya.ANI
{
    public class TranslationKeyframe : IBinary
    {
        public int Keyframe { get; set; }
        public Vector3 Translation { get; set; }

        public TranslationKeyframe(ShaiyaBinaryReader binaryReader)
        {
            Keyframe = binaryReader.Read<int>();
            Translation = new Vector3(binaryReader);
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Keyframe));
            buffer.AddRange(BitConverter.GetBytes(Translation.X));
            buffer.AddRange(BitConverter.GetBytes(Translation.Y));
            buffer.AddRange(BitConverter.GetBytes(Translation.Z));
            return buffer.ToArray();
        }
    }
}
