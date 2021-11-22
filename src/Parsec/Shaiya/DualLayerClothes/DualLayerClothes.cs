using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DUALLAYERCLOTHES
{
    public class DualLayerClothes : FileBase, IJsonReadable
    {
        public List<Costume> Costumes { get; } = new();

        public DualLayerClothes(string path) : base(path)
        {
        }

        [JsonConstructor]
        public DualLayerClothes()
        {
        }

        public override void Read()
        {
            var total = _binaryReader.Read<int>();

            for (int i = 0; i < total; i++)
            {
                var costume = new Costume(_binaryReader);
                Costumes.Add(costume);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Costumes.Count));

            foreach (var costume in Costumes)
            {
                buffer.AddRange(costume.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }
    }
}
