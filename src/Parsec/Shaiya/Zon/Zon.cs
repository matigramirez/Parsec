using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Zon
{
    public class Zon : FileBase, IJsonReadable
    {
        public int Format { get; set; }
        public List<ZonRecord> Records { get; } = new();

        public override string Extension => "zon";

        public override void Read(params object[] options)
        {
            Format = _binaryReader.Read<int>();

            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var record = new ZonRecord(Format, _binaryReader);
                Records.Add(record);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(Format.GetBytes());

            buffer.AddRange(Records.Count.GetBytes());

            foreach (var record in Records)
                buffer.AddRange(record.GetBytes(Format));

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
