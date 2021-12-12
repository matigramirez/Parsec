using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mlt
{
    public class Record : IBinary
    {
        /// <summary>
        /// Index of the .3DC filename
        /// </summary>
        public int Obj3DCIndex { get; set; }

        /// <summary>
        /// Index of the .DDS filename
        /// </summary>
        public int TextureIndex { get; set; }

        /// <summary>
        /// Alpha channel flag. 0: visibility  1: glow
        /// </summary>
        public int Alpha { get; set; }

        [JsonConstructor]
        public Record()
        {
        }

        public Record(ShaiyaBinaryReader binaryReader)
        {
            Obj3DCIndex = binaryReader.Read<int>();
            TextureIndex = binaryReader.Read<int>();
            Alpha = binaryReader.Read<int>();
        }

        public byte[] GetBytes()
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Obj3DCIndex));
            buffer.AddRange(BitConverter.GetBytes(TextureIndex));
            buffer.AddRange(BitConverter.GetBytes(Alpha));
            return buffer.ToArray();
        }
    }
}
