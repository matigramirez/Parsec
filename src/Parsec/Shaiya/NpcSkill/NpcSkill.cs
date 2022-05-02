using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;

namespace Parsec.Shaiya.NpcSkill
{
    public class NpcSkill : SData.SData, IJsonReadable
    {
        [JsonIgnore]
        public Format Format { get; set; }
        [JsonIgnore]
        public int MaxLevel { get; set; }
        public int Count { set; get; }
        public List<Skill> Skills { get; } = new();

        [JsonConstructor]
        public NpcSkill()
        {
        }

        public override void Read(params object[] options)
        {
            if (options.Length > 0)
            {
                object format = options[0];
                Format = (Format)format;
            }
            else
            {
                Format = Format.EP5;
            }

            Count = _binaryReader.Read<int>();

            MaxLevel = Format switch
            {
                Format.EP4 => 3,
                Format.EP5 => 9,
                Format.EP6 => 15,
                Format.EP7 => 15,
                _ => throw new NotImplementedException()
            };

            for (int i = 0; i < Count * MaxLevel; i++)
            {
                var skill = new Skill(_binaryReader, Format);
                Skills.Add(skill);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Count));

            foreach (var skill in Skills)
            {
                buffer.AddRange(skill.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
