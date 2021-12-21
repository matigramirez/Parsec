using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cash
{
    public class Product : IBinary
    {
        public int Index { get; set; }
        public int Bag { get; set; }
        public int Unknown { get; set; }
        public int Cost { get; set; }
        public List<Item> Items { get; } = new();
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }

        [JsonConstructor]
        public Product()
        {
        }

        public Product(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
            Bag = binaryReader.Read<int>();
            Unknown = binaryReader.Read<int>();
            Cost = binaryReader.Read<int>();

            for (int i = 0; i < 24; i++)
            {
                var item = new Item(binaryReader);
                Items.Add(item);
            }

            ProductName = binaryReader.ReadString();
            ProductCode = binaryReader.ReadString();
            Description = binaryReader.ReadString();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Index));
            buffer.AddRange(BitConverter.GetBytes(Bag));
            buffer.AddRange(BitConverter.GetBytes(Unknown));
            buffer.AddRange(BitConverter.GetBytes(Cost));

            foreach (var item in Items)
                buffer.AddRange(item.GetBytes());

            // For some reason these strings have 2 string terminators
            buffer.AddRange(BitConverter.GetBytes(ProductName.Length + 2));
            buffer.AddRange(Encoding.ASCII.GetBytes(ProductName + "\0\0"));
            buffer.AddRange(BitConverter.GetBytes(ProductCode.Length + 2));
            buffer.AddRange(Encoding.ASCII.GetBytes(ProductCode + "\0\0"));
            buffer.AddRange(BitConverter.GetBytes(Description.Length + 2));
            buffer.AddRange(Encoding.ASCII.GetBytes(Description + "\0\0"));

            return buffer.ToArray();
        }
    }
}
