using System.Collections.Generic;
using Parsec.Readers;

namespace Parsec.Shaiya.DUALLAYERCLOTHES
{
    public class Costume
    {
        public short Index { get; set; }

        public List<Layer> Layers { get; } = new();

        public Costume()
        {
        }

        public Costume(ShaiyaBinaryReader binaryReader)
        {
            Index = binaryReader.Read<short>();

            var layer = new Layer(binaryReader);
            Layers.Add(layer);
        }
    }
}
