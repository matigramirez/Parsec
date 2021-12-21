using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SetItem
{
    public class Set : IBinary
    {
        public short Index { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; } = new();
        public List<Synergy> Synergies { get; } = new();

        [JsonConstructor]
        public Set()
        {
        }

        public Set(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<short>();
            Name = binaryReader.ReadString();

            for (int i = 0; i < 13; i++)
            {
                var item = new Item(binaryReader);
                Items.Add(item);
            }

            for (int i = 0; i < 13; i++)
            {
                var synergy = new Synergy(binaryReader);
                Synergies.Add(synergy);
            }
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Index));
            buffer.AddRange(BitConverter.GetBytes(Name.Length + 1));
            buffer.AddRange(Encoding.ASCII.GetBytes(Name + '\0'));

            foreach (var item in Items)
            {
                buffer.AddRange(item.GetBytes());
            }

            foreach (var synergy in Synergies)
            {
                buffer.AddRange(synergy.GetBytes());
            }

            return buffer.ToArray();
        }
    }
}
