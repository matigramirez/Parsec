using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Seff
{
    public class Seff : FileBase, IJsonReadable
    {
        public int Unknown1 { get; set; }
        public short Unknown2 { get; set; }
        public short Unknown3 { get; set; }
        public short Unknown4 { get; set; }
        public short Unknown5 { get; set; }
        public short Unknown6 { get; set; }
        public short Unknown7 { get; set; }
        public List<Effect> Effects { get; } = new();


        [JsonIgnore]
        public override string Extension => "seff";

        public override void Read(params object[] options)
        {
            Unknown1 = _binaryReader.Read<int>();
            Unknown2 = _binaryReader.Read<short>();
            Unknown3 = _binaryReader.Read<short>();
            Unknown4 = _binaryReader.Read<short>();
            Unknown5 = _binaryReader.Read<short>();
            Unknown6 = _binaryReader.Read<short>();
            Unknown7 = _binaryReader.Read<short>();

            var effectCount = _binaryReader.Read<int>();

            for (int i = 0; i < effectCount; i++)
            {
                var effect = new Effect(_binaryReader);
                Effects.Add(effect);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Unknown1.GetBytes());
            buffer.AddRange(Unknown2.GetBytes());
            buffer.AddRange(Unknown3.GetBytes());
            buffer.AddRange(Unknown4.GetBytes());
            buffer.AddRange(Unknown5.GetBytes());
            buffer.AddRange(Unknown6.GetBytes());
            buffer.AddRange(Unknown7.GetBytes());

            buffer.AddRange(Effects.Count.GetBytes());

            foreach (var effect in Effects)
                buffer.AddRange(effect.GetBytes());

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
