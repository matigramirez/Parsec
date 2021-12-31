using System;
using System.Collections.Generic;
using Parsec.Common;

namespace Parsec.Shaiya.Item
{
    public class Item : SData.SData, IJsonReadable
    {
        public int MaxType { get; set; }
        public List<Type> Types { get; } = new();

        public override void Read(params object[] options)
        {
            MaxType = _binaryReader.Read<int>();

            for (int i = 0; i < MaxType; i++)
            {
                var type = new Type(_binaryReader);
                Types.Add(type);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(MaxType));

            foreach (var type in Types)
                buffer.AddRange(type.GetBytes());

            return buffer.ToArray();
        }
    }
}
