using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.DUALLAYERCLOTHES
{
    public class DualLayerClothes : FileBase
    {
        [JsonIgnore]
        public int Total { get; set; }
        public List<Costume> Costumes { get; } = new();

        public DualLayerClothes(string path) : base(path)
        {
        }

        public override void Read()
        {
            Total = _binaryReader.Read<int>();

            for (int i = 0; i < Total; i++)
            {
                var costume = new Costume(_binaryReader);
                Costumes.Add(costume);
            }
        }
    }
}
