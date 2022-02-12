using System.Collections.Generic;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.MON
{
    public class MON : FileBase, IJsonReadable
    {
        /// <summary>
        /// File signature. "MO2", "MO4". Read as char[3]
        /// </summary>
        public string Signature { get; set; }

        public List<MONRecord> Records { get; } = new();

        public override string Extension => "MON";

        public override void Read(params object[] options)
        {
            Signature = _binaryReader.ReadString(3);

            var recordCount = _binaryReader.Read<int>();

            for (int i = 0; i < recordCount; i++)
            {
                var record = new MONRecord(_binaryReader);
                Records.Add(record);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Signature.GetBytes());
            buffer.AddRange(Records.GetBytes());
            return buffer.ToArray();
        }
    }
}
