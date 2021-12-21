using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Itm
{
    public class Record : IBinary
    {
        /// <summary>
        /// Index of the .3DO filename
        /// </summary>
        public int Obj3DOIndex { get; set; }

        /// <summary>
        /// Index of the .DDS filename
        /// </summary>
        public int TextureIndex { get; set; }

        public int Glow { get; set; }
        public int Unknown1 { get; set; }

        /// <summary>
        /// Record format. 0 or 1.
        /// </summary>
        public int Format { get; set; }

        public int Unknown2 { get; set; }

        /// <summary>
        /// Present if <see cref="Format"/> is 1.
        /// </summary>
        public uint RGBA { get; set; }

        /// <summary>
        /// Present if <see cref="Format"/> is 1.
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Present if <see cref="Format"/> is 1.
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// Present if <see cref="Format"/> is 1.
        /// </summary>
        public int Unknown3 { get; set; }

        /// <summary>
        /// Present if <see cref="ITMFormat"/> is "IT2".
        /// 1024 unknown bytes. 32 blocks of 8 uint32.
        /// </summary>
        public byte[] Unknown4 { get; } = new byte[1024];

        [JsonConstructor]
        public Record()
        {
        }

        public Record(ITMFormat format, ShaiyaBinaryReader binaryReader)
        {
            Obj3DOIndex = binaryReader.Read<int>();
            TextureIndex = binaryReader.Read<int>();
            Glow = binaryReader.Read<int>();
            Unknown1 = binaryReader.Read<int>();
            Format = binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<int>();

            if (Format == 1)
            {
                RGBA = binaryReader.Read<uint>();
                Rotation = binaryReader.Read<float>();
                Scale = binaryReader.Read<float>();
                Unknown3 = binaryReader.Read<int>();
            }

            if (format == ITMFormat.IT2)
                Unknown4 = binaryReader.ReadBytes(1024);
        }

        /// <summary>
        /// Expects <see cref="ITMFormat"/> as an option
        /// </summary>
        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            var format = ITMFormat.ITM;

            if (options.Length > 0)
                format = (ITMFormat)options[0];

            buffer.AddRange(BitConverter.GetBytes(Obj3DOIndex));
            buffer.AddRange(BitConverter.GetBytes(TextureIndex));
            buffer.AddRange(BitConverter.GetBytes(Glow));
            buffer.AddRange(BitConverter.GetBytes(Unknown1));
            buffer.AddRange(BitConverter.GetBytes(Format));
            buffer.AddRange(BitConverter.GetBytes(Unknown2));

            if (Format == 1)
            {
                buffer.AddRange(BitConverter.GetBytes(RGBA));
                buffer.AddRange(BitConverter.GetBytes(Rotation));
                buffer.AddRange(BitConverter.GetBytes(Scale));
                buffer.AddRange(BitConverter.GetBytes(Unknown3));
            }

            if (format == ITMFormat.IT2)
                buffer.AddRange(Unknown4);

            return buffer.ToArray();
        }
    }
}
