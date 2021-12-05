using Parsec.Helpers;
using Parsec.Shaiya.SEFF;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportJsonFromSeff("weapon.seff", "weapon.seff.json");

            CreateSeffFromJson("weapon.seff.json", "weapon_createdfromjson.seff");
        }

        static void ExportJsonFromSeff(string seffPath, string jsonPath)
        {
            var seff = new Seff(seffPath);
            seff.Read();
            seff.ExportJson(jsonPath);
        }

        static  void CreateSeffFromJson(string jsonPath, string seffPath)
        {
            // Importing the created json file
            var seffFromJson = Deserializer.ReadFromJson<Seff>(jsonPath);

            // Export the loaded json file
            seffFromJson.Write(seffPath);
        }
    }
}
