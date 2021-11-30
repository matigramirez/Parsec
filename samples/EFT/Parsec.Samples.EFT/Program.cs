using System;
using Parsec.Helpers;
using Parsec.Shaiya.EFT;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a file name: ");
            string fileName = Console.ReadLine();

            var eft = new EFT(fileName);

            eft.Read();
            eft.ExportJson(fileName + ".json");

            // Import the created json file
            var eftFromJson = Deserializer.ReadFromJson<EFT>(fileName + ".json");

            string name = System.IO.Path.GetFileNameWithoutExtension(fileName);

            // Export the loaded json file
            eftFromJson.Write(name + ".modified.EFT");
        }
    }
}
