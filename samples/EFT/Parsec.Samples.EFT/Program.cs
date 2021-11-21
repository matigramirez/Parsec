using System;
using Parsec.Shaiya.EFT;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a file name:");
            string fileName = Console.ReadLine();

            var eft = new EFT(fileName);
            eft.Read();
            eft.ExportJson(fileName + ".json");
        }
    }
}
