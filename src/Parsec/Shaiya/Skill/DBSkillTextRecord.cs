using System.Collections.Generic;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Skill
{
    public class DBSkillTextRecord : IBinarySDataRecord
    {
        public long Id { get; set; }
        public long SkillLevel { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public void Read(SBinaryReader binaryReader, params object[] options)
        {
            Id = binaryReader.Read<long>();
            SkillLevel = binaryReader.Read<long>();
            Name = binaryReader.ReadString();
            Text = binaryReader.ReadString();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Id.GetBytes());
            buffer.AddRange(SkillLevel.GetBytes());
            buffer.AddRange(Name.GetLengthPrefixedBytes());
            buffer.AddRange(Text.GetLengthPrefixedBytes());
            return buffer.ToArray();
        }
    }
}
