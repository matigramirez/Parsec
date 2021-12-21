using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.EFT
{
    public class Scene : IBinary
    {
        public string Name { get; set; }
        public int Unknown01 { get; set; }
        public int Unknown02 { get; set; }
        public int Unknown03 { get; set; }
        public int Unknown04 { get; set; }
        public int Unknown05 { get; set; }
        public int Unknown06 { get; set; }
        public int Unknown07 { get; set; }
        public int Unknown08 { get; set; }
        public int Unknown09 { get; set; }
        public int Unknown10 { get; set; }
        public float Unknown11 { get; set; }
        public float Unknown12 { get; set; }
        public float Unknown13 { get; set; }
        public float Unknown14 { get; set; }
        public float Unknown15 { get; set; }
        public float Unknown16 { get; set; }
        public float Unknown17 { get; set; }
        public float Unknown18 { get; set; }
        public float Unknown19 { get; set; }
        public float Unknown20 { get; set; }
        public float Unknown21 { get; set; }
        public float Unknown22 { get; set; }
        public float Unknown23 { get; set; }
        public float Unknown24 { get; set; }
        public float Unknown25 { get; set; }
        public float Unknown26 { get; set; }
        public float Unknown27 { get; set; }
        public float Unknown28 { get; set; }
        public float Unknown29 { get; set; }
        public float Unknown30 { get; set; }
        public float Unknown31 { get; set; }
        public float Unknown32 { get; set; }
        public float Unknown33 { get; set; }
        public int Unknown34 { get; set; }
        public int Unknown35 { get; set; }
        public int Unknown36 { get; set; }
        public List<Vector4> Vec04Array { get; } = new();
        public int Unknown37 { get; set; }
        public int Unknown38 { get; set; }
        public float Unknown39 { get; set; }
        public int Unknown40 { get; set; }
        public int Unknown41 { get; set; }
        public int Unknown42 { get; set; }
        public int Vec05Count { get; set; }
        public List<Vector5> Vec05Array { get; } = new();
        public int Vec02Count { get; set; }
        public List<Vector2> Vec02Array { get; } = new();
        public int Vec03Count { get; set; }
        public List<Vector3> Vec03Array { get; } = new();
        public int Unknown43 { get; set; }
        public int Unknown44 { get; set; }
        public float Unknown45 { get; set; }
        public int Unknown46 { get; set; }
        public int DDSCount { get; set; }
        public List<DDS> DDSSequence { get; } = new();

        [JsonConstructor]
        public Scene()
        {
        }

        public Scene(EFTFormat format, ShaiyaBinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            //read 10
            Unknown01 = binaryReader.Read<int>();
            Unknown02 = binaryReader.Read<int>();
            Unknown03 = binaryReader.Read<int>();
            Unknown04 = binaryReader.Read<int>();
            Unknown05 = binaryReader.Read<int>();
            Unknown06 = binaryReader.Read<int>();
            Unknown07 = binaryReader.Read<int>();
            Unknown08 = binaryReader.Read<int>();
            Unknown09 = binaryReader.Read<int>();
            Unknown10 = binaryReader.Read<int>();
            //read 23
            Unknown11 = binaryReader.Read<float>();
            Unknown12 = binaryReader.Read<float>();
            Unknown13 = binaryReader.Read<float>();
            Unknown14 = binaryReader.Read<float>();
            Unknown15 = binaryReader.Read<float>();
            Unknown16 = binaryReader.Read<float>();
            Unknown17 = binaryReader.Read<float>();
            Unknown18 = binaryReader.Read<float>();
            Unknown19 = binaryReader.Read<float>();
            Unknown20 = binaryReader.Read<float>();
            Unknown21 = binaryReader.Read<float>();
            Unknown22 = binaryReader.Read<float>();
            Unknown23 = binaryReader.Read<float>();
            Unknown24 = binaryReader.Read<float>();
            Unknown25 = binaryReader.Read<float>();
            Unknown26 = binaryReader.Read<float>();
            Unknown27 = binaryReader.Read<float>();
            Unknown28 = binaryReader.Read<float>();
            Unknown29 = binaryReader.Read<float>();
            Unknown30 = binaryReader.Read<float>();
            Unknown31 = binaryReader.Read<float>();
            Unknown32 = binaryReader.Read<float>();
            Unknown33 = binaryReader.Read<float>();
            //
            Unknown34 = binaryReader.Read<int>();
            Unknown35 = binaryReader.Read<int>();
            Unknown36 = binaryReader.Read<int>();
            //
            for (int i = 0; i < 1; i++)
            {
                var vec = new Vector4(binaryReader);
                Vec04Array.Add(vec);
            }
            //
            Unknown37 = binaryReader.Read<int>();
            Unknown38 = binaryReader.Read<int>();
            Unknown39 = binaryReader.Read<float>();
            Unknown40 = binaryReader.Read<int>();

            if (format == EFTFormat.EF3)
            {
                Unknown41 = binaryReader.Read<int>();
                Unknown42 = binaryReader.Read<int>();
            }

            Vec05Count = binaryReader.Read<int>();

            for (int i = 0; i < Vec05Count; i++)
            {
                var vec = new Vector5(binaryReader);
                Vec05Array.Add(vec);
            }

            Vec02Count = binaryReader.Read<int>();

            for (int i = 0; i < Vec02Count; i++)
            {
                var vec = new Vector2(binaryReader);
                Vec02Array.Add(vec);
            }

            Vec03Count = binaryReader.Read<int>();

            for (int i = 0; i < Vec03Count; i++)
            {
                var vec = new Vector3(binaryReader);
                Vec03Array.Add(vec);
            }

            Unknown43 = binaryReader.Read<int>();
            Unknown44 = binaryReader.Read<int>();
            Unknown45 = binaryReader.Read<float>();
            Unknown46 = binaryReader.Read<int>();

            DDSCount = binaryReader.Read<int>();

            for (int i = 0; i < DDSCount; i++)
            {
                var dds = new DDS(binaryReader);
                DDSSequence.Add(dds);
            }
        }

        /// <summary>
        /// Expects <see cref="EFTFormat"/> as a parameter
        /// </summary>
        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            var format = EFTFormat.EFT;

            if (options.Length > 0)
                format = (EFTFormat)options[0];

            buffer.AddRange(BitConverter.GetBytes(Name.Length + 1));
            buffer.AddRange(Encoding.ASCII.GetBytes(Name + '\0'));

            buffer.AddRange(BitConverter.GetBytes(Unknown01));
            buffer.AddRange(BitConverter.GetBytes(Unknown02));
            buffer.AddRange(BitConverter.GetBytes(Unknown03));
            buffer.AddRange(BitConverter.GetBytes(Unknown04));
            buffer.AddRange(BitConverter.GetBytes(Unknown05));
            buffer.AddRange(BitConverter.GetBytes(Unknown06));
            buffer.AddRange(BitConverter.GetBytes(Unknown07));
            buffer.AddRange(BitConverter.GetBytes(Unknown08));
            buffer.AddRange(BitConverter.GetBytes(Unknown09));
            buffer.AddRange(BitConverter.GetBytes(Unknown10));
            buffer.AddRange(BitConverter.GetBytes(Unknown11));
            buffer.AddRange(BitConverter.GetBytes(Unknown12));
            buffer.AddRange(BitConverter.GetBytes(Unknown13));
            buffer.AddRange(BitConverter.GetBytes(Unknown14));
            buffer.AddRange(BitConverter.GetBytes(Unknown15));
            buffer.AddRange(BitConverter.GetBytes(Unknown16));
            buffer.AddRange(BitConverter.GetBytes(Unknown17));
            buffer.AddRange(BitConverter.GetBytes(Unknown18));
            buffer.AddRange(BitConverter.GetBytes(Unknown19));
            buffer.AddRange(BitConverter.GetBytes(Unknown20));
            buffer.AddRange(BitConverter.GetBytes(Unknown21));
            buffer.AddRange(BitConverter.GetBytes(Unknown22));
            buffer.AddRange(BitConverter.GetBytes(Unknown23));
            buffer.AddRange(BitConverter.GetBytes(Unknown24));
            buffer.AddRange(BitConverter.GetBytes(Unknown25));
            buffer.AddRange(BitConverter.GetBytes(Unknown26));
            buffer.AddRange(BitConverter.GetBytes(Unknown27));
            buffer.AddRange(BitConverter.GetBytes(Unknown28));
            buffer.AddRange(BitConverter.GetBytes(Unknown29));
            buffer.AddRange(BitConverter.GetBytes(Unknown30));
            buffer.AddRange(BitConverter.GetBytes(Unknown31));
            buffer.AddRange(BitConverter.GetBytes(Unknown32));
            buffer.AddRange(BitConverter.GetBytes(Unknown33));
            buffer.AddRange(BitConverter.GetBytes(Unknown34));
            buffer.AddRange(BitConverter.GetBytes(Unknown35));
            buffer.AddRange(BitConverter.GetBytes(Unknown36));

            foreach (var vec in Vec04Array)
                buffer.AddRange(vec.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Unknown37));
            buffer.AddRange(BitConverter.GetBytes(Unknown38));
            buffer.AddRange(BitConverter.GetBytes(Unknown39));
            buffer.AddRange(BitConverter.GetBytes(Unknown40));

            if (format == EFTFormat.EF3)
            {
                buffer.AddRange(BitConverter.GetBytes(Unknown41));
                buffer.AddRange(BitConverter.GetBytes(Unknown42));
            }

            buffer.AddRange(BitConverter.GetBytes(Vec05Array.Count));

            foreach (var vec in Vec05Array)
                buffer.AddRange(vec.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Vec02Array.Count));

            foreach (var vec in Vec02Array)
                buffer.AddRange(vec.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Vec03Array.Count));

            foreach (var vec in Vec03Array)
                buffer.AddRange(vec.GetBytes());

            buffer.AddRange(BitConverter.GetBytes(Unknown43));
            buffer.AddRange(BitConverter.GetBytes(Unknown44));
            buffer.AddRange(BitConverter.GetBytes(Unknown45));
            buffer.AddRange(BitConverter.GetBytes(Unknown46));

            buffer.AddRange(BitConverter.GetBytes(DDSSequence.Count));

            foreach (var dds in DDSSequence)
                buffer.AddRange(dds.GetBytes());

            return buffer.ToArray();
        }
    }
}
