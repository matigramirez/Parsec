using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.SDATA;

namespace Parsec.Shaiya.SETITEM
{
    public class SetItem : SData, IJsonReadable
    {
        public List<Set> Sets { get; } = new();

        public SetItem(string path) : base(path)
        {
        }

        [JsonConstructor]
        public SetItem()
        {
        }

        public override void Read()
        {
            var setCount = _binaryReader.Read<int>();

            for (int i = 0; i < setCount; i++)
            {
                var set = new Set(_binaryReader);
                Sets.Add(set);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Sets.Count));

            foreach (var set in Sets)
            {
                buffer.AddRange(set.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
