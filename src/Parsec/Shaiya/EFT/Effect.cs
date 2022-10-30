using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class Effect : IBinary
    {
        /// <summary>
        /// Not part of the structure, but left here for readability purposes
        /// </summary>
        public int Index { get; set; }
        public string Name { get; set; }
        public int Unknown1 { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public int Unknown4 { get; set; }
        public int Unknown5 { get; set; }
        public int Unknown6 { get; set; }
        public int TextureId { get; set; }
        public int Unknown8 { get; set; }
        public int Object3DEId { get; set; }
        public int Unknown10 { get; set; }
        public float Unknown11 { get; set; }
        public float Unknown12 { get; set; }
        public float Unknown13 { get; set; }
        public float Unknown14 { get; set; }
        public float Unknown15 { get; set; }
        public float Unknown16 { get; set; }
        public float Unknown17 { get; set; }
        public float Unknown18 { get; set; }

        public Vector3 UnknownVec1 { get; set; }
        public Vector3 UnknownVec2 { get; set; }

        /// <summary>
        /// The position where the effect should be rendered, relative to the effect's origin.
        /// In the case of mob effects, the origin is the bone to which the effect is attached to.
        /// </summary>
        public Vector3 Position { get; set; }
        public Vector3 UnknownVec4 { get; set; }
        public Vector3 UnknownVec5 { get; set; }

        public int Unknown19 { get; set; }
        public int Unknown20 { get; set; }
        public int Unknown21 { get; set; }

        public Vector3 UnknownVec6 { get; set; }

        public float Unknown22 { get; set; }
        public int Unknown23 { get; set; }
        public int Unknown24 { get; set; }
        public float Unknown25 { get; set; }
        public int Unknown26 { get; set; }

        /// <summary>
        /// Only present in EF3
        /// </summary>
        public float Unknown27 { get; set; }

        /// <summary>
        /// Only present in EF3
        /// </summary>
        public float Unknown28 { get; set; }

        public List<Rotation> Rotations { get; } = new();
        public List<EffectSub2> EffectSub2 { get; } = new();
        public List<EffectSub3> EffectSub3 { get; } = new();

        public int Unknown29 { get; set; }
        public int Unknown30 { get; set; }
        public int Unknown31 { get; set; }
        public int Unknown32 { get; set; }

        public List<EffectSub4> EffectSub4 { get; } = new();

        [JsonConstructor]
        public Effect()
        {
        }

        public Effect(SBinaryReader binaryReader, EFTFormat format, int index)
        {
            Index = index;
            Name = binaryReader.ReadString();

            Unknown1 = binaryReader.Read<int>();
            Unknown2 = binaryReader.Read<int>();
            Unknown3 = binaryReader.Read<int>();
            Unknown4 = binaryReader.Read<int>();
            Unknown5 = binaryReader.Read<int>();
            Unknown6 = binaryReader.Read<int>();
            TextureId = binaryReader.Read<int>();
            Unknown8 = binaryReader.Read<int>();
            Object3DEId = binaryReader.Read<int>();
            Unknown10 = binaryReader.Read<int>();

            Unknown11 = binaryReader.Read<float>();
            Unknown12 = binaryReader.Read<float>();
            Unknown13 = binaryReader.Read<float>();
            Unknown14 = binaryReader.Read<float>();
            Unknown15 = binaryReader.Read<float>();
            Unknown16 = binaryReader.Read<float>();
            Unknown17 = binaryReader.Read<float>();
            Unknown18 = binaryReader.Read<float>();

            UnknownVec1 = new Vector3(binaryReader);
            UnknownVec2 = new Vector3(binaryReader);
            Position = new Vector3(binaryReader);
            UnknownVec4 = new Vector3(binaryReader);
            UnknownVec5 = new Vector3(binaryReader);

            Unknown19 = binaryReader.Read<int>();
            Unknown20 = binaryReader.Read<int>();
            Unknown21 = binaryReader.Read<int>();

            UnknownVec6 = new Vector3(binaryReader);

            Unknown22 = binaryReader.Read<float>();
            Unknown23 = binaryReader.Read<int>();
            Unknown24 = binaryReader.Read<int>();
            Unknown25 = binaryReader.Read<float>();
            Unknown26 = binaryReader.Read<int>();

            if (format == EFTFormat.EF3)
            {
                Unknown27 = binaryReader.Read<float>();
                Unknown28 = binaryReader.Read<float>();
            }

            int rotationCount = binaryReader.Read<int>();
            for (int i = 0; i < rotationCount; i++)
            {
                var rotation = new Rotation(binaryReader);
                Rotations.Add(rotation);
            }

            int sceneSub2Count = binaryReader.Read<int>();
            for (int i = 0; i < sceneSub2Count; i++)
            {
                var sub2 = new EffectSub2(binaryReader);
                EffectSub2.Add(sub2);
            }

            int sceneSub3Count = binaryReader.Read<int>();
            for (int i = 0; i < sceneSub3Count; i++)
            {
                var sub3 = new EffectSub3(binaryReader);
                EffectSub3.Add(sub3);
            }

            Unknown29 = binaryReader.Read<int>();
            Unknown30 = binaryReader.Read<int>();
            Unknown31 = binaryReader.Read<int>();
            Unknown32 = binaryReader.Read<int>();

            int sceneSub4Count = binaryReader.Read<int>();
            for (int i = 0; i < sceneSub4Count; i++)
            {
                var sub4 = new EffectSub4(binaryReader);
                EffectSub4.Add(sub4);
            }
        }

        /// <summary>
        /// Expects <see cref="EFTFormat"/> as a parameter
        /// </summary>
        public IEnumerable<byte> GetBytes(params object[] options)
        {
            var format = EFTFormat.Unknown;

            if (options.Length > 0)
                format = (EFTFormat)options[0];

            var buffer = new List<byte>();
            buffer.AddRange(Name.GetLengthPrefixedBytes());

            buffer.AddRange(Unknown1.GetBytes());
            buffer.AddRange(Unknown2.GetBytes());
            buffer.AddRange(Unknown3.GetBytes());
            buffer.AddRange(Unknown4.GetBytes());
            buffer.AddRange(Unknown5.GetBytes());
            buffer.AddRange(Unknown6.GetBytes());
            buffer.AddRange(TextureId.GetBytes());
            buffer.AddRange(Unknown8.GetBytes());
            buffer.AddRange(Object3DEId.GetBytes());
            buffer.AddRange(Unknown10.GetBytes());
            buffer.AddRange(Unknown11.GetBytes());
            buffer.AddRange(Unknown12.GetBytes());
            buffer.AddRange(Unknown13.GetBytes());
            buffer.AddRange(Unknown14.GetBytes());
            buffer.AddRange(Unknown15.GetBytes());
            buffer.AddRange(Unknown16.GetBytes());
            buffer.AddRange(Unknown17.GetBytes());
            buffer.AddRange(Unknown18.GetBytes());
            buffer.AddRange(UnknownVec1.GetBytes());
            buffer.AddRange(UnknownVec2.GetBytes());
            buffer.AddRange(Position.GetBytes());
            buffer.AddRange(UnknownVec4.GetBytes());
            buffer.AddRange(UnknownVec5.GetBytes());
            buffer.AddRange(Unknown19.GetBytes());
            buffer.AddRange(Unknown20.GetBytes());
            buffer.AddRange(Unknown21.GetBytes());
            buffer.AddRange(UnknownVec6.GetBytes());
            buffer.AddRange(Unknown22.GetBytes());
            buffer.AddRange(Unknown23.GetBytes());
            buffer.AddRange(Unknown24.GetBytes());
            buffer.AddRange(Unknown25.GetBytes());
            buffer.AddRange(Unknown26.GetBytes());

            if (format == EFTFormat.EF3)
            {
                buffer.AddRange(Unknown27.GetBytes());
                buffer.AddRange(Unknown28.GetBytes());
            }

            buffer.AddRange(Rotations.GetBytes());
            buffer.AddRange(EffectSub2.GetBytes());
            buffer.AddRange(EffectSub3.GetBytes());
            buffer.AddRange(Unknown29.GetBytes());
            buffer.AddRange(Unknown30.GetBytes());
            buffer.AddRange(Unknown31.GetBytes());
            buffer.AddRange(Unknown32.GetBytes());
            buffer.AddRange(EffectSub4.GetBytes());
            return buffer;
        }
    }
}
