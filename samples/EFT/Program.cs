using Parsec.Helpers;
using Parsec.Shaiya.EFT;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportJsonFromEFT("Monster.EFT", "Monster.json");
            CreateEFTFromJson("Monster.json", "Monster.Created.EFT");
        }

        static void ExportJsonFromEFT(string eftPath, string jsonPath)
        {
            var eft = new EFT(eftPath);
            eft.Read();
            eft.ExportJson(jsonPath);
        }

        static void CreateEFTFromJson(string jsonPath, string eftPath)
        {
            // Importing the created json file
            var eftFromJson = Deserializer.ReadFromJson<EFT>(jsonPath);

            // Export the loaded json file
            eftFromJson.Write(eftPath);
        }
    }
}
