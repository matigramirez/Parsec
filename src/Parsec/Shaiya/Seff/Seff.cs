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
        public int Format { get; set; }
        public short Unknown2 { get; set; }
        public short Unknown3 { get; set; }
        public short Unknown4 { get; set; }
        public short Unknown5 { get; set; }
        public short Unknown6 { get; set; }
        public short Unknown7 { get; set; }
        public List<Record> Records { get; } = new();

        [JsonIgnore]
        public override string Extension => "seff";

        public override void Read(params object[] options)
        {
            Format = _binaryReader.Read<int>();
            Unknown2 = _binaryReader.Read<short>();
            Unknown3 = _binaryReader.Read<short>();
            Unknown4 = _binaryReader.Read<short>();
            Unknown5 = _binaryReader.Read<short>();
            Unknown6 = _binaryReader.Read<short>();
            Unknown7 = _binaryReader.Read<short>();

            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var record = new Record(_binaryReader, Format);
                Records.Add(record);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Format.GetBytes());
            buffer.AddRange(Unknown2.GetBytes());
            buffer.AddRange(Unknown3.GetBytes());
            buffer.AddRange(Unknown4.GetBytes());
            buffer.AddRange(Unknown5.GetBytes());
            buffer.AddRange(Unknown6.GetBytes());
            buffer.AddRange(Unknown7.GetBytes());

            buffer.AddRange(Records.Count.GetBytes());

            foreach (var effect in Records)
                buffer.AddRange(effect.GetBytes(Format));

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
