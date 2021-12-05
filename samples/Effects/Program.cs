using Parsec.Shaiya.EFT;
using Parsec.Shaiya.SEFF;

namespace Parsec.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region EFT

            var eft = new EFT("Monster.EFT");
            eft.Read();
            eft.ExportJson($"{eft.FileName}.json");

            #endregion

            #region seff

            var seff = new Seff("weapon.seff");
            seff.Read();
            seff.ExportJson($"{seff.FileName}.json");

            #endregion
        }
    }
}
