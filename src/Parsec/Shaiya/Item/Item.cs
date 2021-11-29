using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Helpers;
using Parsec.Shaiya.SDATA;

namespace Parsec.Shaiya.Item
{
    public class Item : SData
    {
        public int MaxType { get; set; }
        public List<Type> Types { get; } = new();

        public Item(string path) : base(path)
        {
        }

        [JsonConstructor]
        public Item()
        {
        }

        public override void Read()
        {
            MaxType = _binaryReader.Read<int>();

            for (int i = 0; i < MaxType; i++)
            {
                var type = new Type(_binaryReader);
                Types.Add(type);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(MaxType));

            foreach (var type in Types)
            {
                buffer.AddRange(type.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
