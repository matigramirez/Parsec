using System.Collections.Generic;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.EFT
{
    public class EF3Scene
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
        public int Unknown41 { get; set; }
        public int Unknown42 { get; set; }
        public float Unknown43 { get; set; }
        public int Unknown44 { get; set; }
        public int Unknown45 { get; set; }
        public int Unknown46 { get; set; }
        public int Vec05Count { get; set; }
        public List<Vector5> Vec05Array { get; } = new();
        public int Vec02Count { get; set; }
        public List<Vector2> Vec02Array { get; } = new();
        public int Vec03Count { get; set; }
        public List<Vector3> Vec03Array { get; } = new();
        public int Unknown47 { get; set; }
        public int Unknown48 { get; set; }
        public float Unknown49 { get; set; }
        public int Unknown50 { get; set; }
        public int DDSCount { get; set; }
        public List<DDS> DDSSequence { get; } = new();

        public EF3Scene()
        {
        }

        public EF3Scene(ShaiyaBinaryReader binaryReader)
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
            Unknown41 = binaryReader.Read<int>();
            Unknown42 = binaryReader.Read<int>();
            Unknown43 = binaryReader.Read<float>();
            Unknown44 = binaryReader.Read<int>();
            Unknown45 = binaryReader.Read<int>();
            Unknown46 = binaryReader.Read<int>();

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

            Unknown47 = binaryReader.Read<int>();
            Unknown48 = binaryReader.Read<int>();
            Unknown49 = binaryReader.Read<float>();
            Unknown50 = binaryReader.Read<int>();

            DDSCount = binaryReader.Read<int>();

            for (int i = 0; i < DDSCount; i++)
            {
                var dds = new DDS(binaryReader);
                DDSSequence.Add(dds);
            }
        }
    }
}
