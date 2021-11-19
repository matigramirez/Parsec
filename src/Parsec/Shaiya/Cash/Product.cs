using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.CASH
{
    public class Product
    {
        public int Index { get; set; }
        public int Bag { get; set; }
        [JsonIgnore]
        public int Unknown { get; set; }
        public int Cost { get; set; }
        public List<Item> Items { get; } = new();
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }

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
    }
}
