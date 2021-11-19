using Parsec.Shaiya.DUALLAYERCLOTHES;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var dualLayerClothes = new DualLayerClothes("DualLayerClothes.SData");
            dualLayerClothes.Read();
            dualLayerClothes.ExportJson("DualLayerClothes.json");
        }
    }
}
