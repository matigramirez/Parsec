using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SEFF
{
    public class Seff : FileBase, IJsonReadable
    {
        public int[] Unknown { get; } = new int[4];
        public List<Effect> Effects { get; } = new();

        [JsonConstructor]
        public Seff()
        {
        }

        public Seff(string path) : base(path)
        {
        }

        [JsonIgnore]
        public override string Extension => "seff";

        public override void Read()
        {
            for (int i = 0; i < 4; i++)
            {
                Unknown[i] = _binaryReader.Read<int>();
            }

            var effectCount = _binaryReader.Read<int>();

            for (int i = 0; i < effectCount; i++)
            {
                var effect = new Effect(_binaryReader);
                Effects.Add(effect);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();

            for (int i = 0; i < 4; i++)
            {
                buffer.AddRange(BitConverter.GetBytes(Unknown[i]));
            }

            buffer.AddRange(BitConverter.GetBytes(Effects.Count));

            foreach (var effect in Effects)
            {
                buffer.AddRange(effect.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
