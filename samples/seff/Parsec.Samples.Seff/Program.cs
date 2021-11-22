using Parsec.Helpers;
using Parsec.Shaiya.SEFF;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var seff = new Seff("weapon.seff");
            seff.Read();
            seff.ExportJson("weapon.seff.json");

            // Importing the created json file
            var seffFromJson = Deserializer.ReadFromJson<Seff>("weapon.seff.json");

            // Export the loaded json file
            seffFromJson.Write("weapon.modified.seff");
        }
    }
}
