using System.Collections.Generic;
using Parsec.Readers;

namespace Parsec.Shaiya.SETITEM
{
    public class Set
    {
        public short Index { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; } = new();
        public List<Synergy> Synergies { get; } = new();

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
    }
}
