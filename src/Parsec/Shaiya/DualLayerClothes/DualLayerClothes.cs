using System;
using System.Collections.Generic;
using Parsec.Common;

namespace Parsec.Shaiya.DualLayerClothes
{
    public class DualLayerClothes : SData.SData, IJsonReadable
    {
        public List<Costume> Costumes { get; } = new();

        public override void Read(params object[] options)
        {
            var total = _binaryReader.Read<int>();

            for (int i = 0; i < total; i++)
            {
                var costume = new Costume(_binaryReader);
                Costumes.Add(costume);
            }
        }

        public override byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            buffer.AddRange(BitConverter.GetBytes(Costumes.Count));

            foreach (var costume in Costumes)
                buffer.AddRange(costume.GetBytes());

            return buffer.ToArray();
        }
    }
}
