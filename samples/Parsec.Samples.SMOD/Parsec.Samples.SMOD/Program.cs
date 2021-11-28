using Parsec.Shaiya.SMOD;

namespace Parsec.Samples.SMOD
{
    class Program
    {
        static void Main(string[] args)
        {
            var smod = new Smod("A1_ElfDoor.SMOD");
            smod.Read();
            smod.ExportJson($"{smod.FileNameWithoutExtension}.json");
        }
    }
}
