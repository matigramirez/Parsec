using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Ani
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

        [JsonConstructor]
        public TranslationKeyframe()
        {
        }

        /// <inheritdoc />
        public byte[] GetBytes(params object[] options)
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
