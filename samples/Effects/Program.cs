using Parsec.Shaiya.EFT;
using Parsec.Shaiya.Seff;
using static Parsec.Shaiya.Core.FileBase;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region EFT

            var eft = ReadFromFile<EFT>("Monster.EFT");
            eft.ExportJson($"{eft.FileName}.json");

            #endregion

            #region seff

            var seff = ReadFromFile<Seff>("weapon.seff");
            seff.ExportJson($"{seff.FileName}.json");

            #endregion
        }
    }
}
