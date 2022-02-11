using Parsec.Readers;
using Parsec.Shaiya.EFT;
using Parsec.Shaiya.Obj3DE;
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

            #region 3DE

            var obj3de = Reader.ReadFromFile<Obj3DE>("fire002.3DE");
            obj3de.ExportJson($"{obj3de.FileName}.json");

            #endregion

            #region seff

            var seff = Reader.ReadFromFile<Seff>("weapon.seff");
            seff.ExportJson($"{seff.FileName}.json");

            #endregion
        }
    }
}
