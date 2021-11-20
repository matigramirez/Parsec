using Parsec.Shaiya.EFT;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var eft = new EFT("Crun.EFT");
            eft.Read();
            eft.ExportJson("Crun.json");
        }
    }
}
