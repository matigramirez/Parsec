using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;
using Parsec.Shaiya.SDATA;

namespace Parsec.Shaiya.CASH
{
    public class Cash : SData, IJsonReadable
    {
        public List<Product> Products { get; } = new();

        public Cash(string path) : base(path)
        {
        }

        [JsonConstructor]
        public Cash()
        {
        }

        public override void Read()
        {
            var productCount = _binaryReader.Read<int>();

            for (int i = 0; i < productCount; i++)
            {
                var product = new Product(_binaryReader);
                Products.Add(product);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Products.Count));

            foreach (var product in Products)
            {
                buffer.AddRange(product.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
