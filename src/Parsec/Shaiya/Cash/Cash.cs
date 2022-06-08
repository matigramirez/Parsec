using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;

namespace Parsec.Shaiya.Cash
{
    public class Cash : SData.SData, IJsonReadable
    {
        public List<Product> Products { get; } = new();

        [JsonConstructor]
        public Cash()
        {
        }

        public override void Read(params object[] options)
        {
            var productCount = _binaryReader.Read<int>();

            for (int i = 0; i < productCount; i++)
            {
                var product = new Product(_binaryReader);
                Products.Add(product);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown) => Products.GetBytes();
    }
}
