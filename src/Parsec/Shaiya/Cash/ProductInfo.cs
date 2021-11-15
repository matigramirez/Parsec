using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.CASH
{
    public class ProductInfo
    {
        [JsonIgnore]
        public int Index { get; set; }
        public int Bag { get; set; }
        [JsonIgnore]
        public int Unknown { get; set; }
        public int Cost { get; set; }
        public List<Item> Product { get; } = new();
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }

        public ProductInfo()
        {
        }

        public ProductInfo(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<int>();
            Bag = binaryReader.Read<int>();
            Unknown = binaryReader.Read<int>();
            Cost = binaryReader.Read<int>();

            for (int i = 0; i < 24; ++i)
            {
                var item = new Item(binaryReader);
                Product.Add(item);
            }

            ProductName = binaryReader.ReadString();
            ProductCode = binaryReader.ReadString();
            Description = binaryReader.ReadString();
        }
    }
}