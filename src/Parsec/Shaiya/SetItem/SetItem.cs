using System;
using System.Collections.Generic;
using Parsec.Common;
using Parsec.Helpers;

namespace Parsec.Shaiya.SetItem
{
    public class SetItem : SData.SData, IJsonReadable
    {
        public List<Set> Sets { get; } = new();

        public override void Read(params object[] options)
        {
            var setCount = _binaryReader.Read<int>();

            for (int i = 0; i < setCount; i++)
            {
                var set = new Set(_binaryReader);
                Sets.Add(set);
            }
        }

        public override void Write(string path, params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Sets.Count));

            foreach (var set in Sets)
                buffer.AddRange(set.GetBytes());

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
