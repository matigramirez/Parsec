using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DUALLAYERCLOTHES
{
    public class DualLayerClothes : FileBase
    {
        [JsonIgnore]
        public int Total { get; set; }
        public List<Cloth> Clothes { get; } = new();

        public DualLayerClothes(string path) : base(path)
        {
        }

        public override void Read()
        {
            Total = _binaryReader.Read<int>();

            for (int i = 0; i < Total; i++)
            {
                var cloth = new Cloth(_binaryReader);
                Clothes.Add(cloth);
            }
        }
    }
}
