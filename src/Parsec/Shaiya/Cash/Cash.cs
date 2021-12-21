using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;

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

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Products.Count));

            foreach (var product in Products)
                buffer.AddRange(product.GetBytes());

            return buffer.ToArray();
        }
    }
}
