using Parsec.Readers;
using Parsec.Shaiya.EFT;
using Parsec.Shaiya.Seff;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region EFT

            var eft = Reader.ReadFromFile<EFT>("Monster.EFT");
            eft.ExportJson($"{eft.FileName}.json");

            #endregion

            #region seff

            var seff = Reader.ReadFromFile<Seff>("weapon.seff");
            seff.ExportJson($"{seff.FileName}.json");

            #endregion
        }
    }
}
