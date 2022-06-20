using Parsec;
using Parsec.Shaiya._3DE;
using Parsec.Shaiya.EFT;
using Parsec.Shaiya.Seff;
using Parsec.Shaiya.Wtr;

namespace Sample.Effects
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

            var obj3de = Reader.ReadFromFile<_3DE>("fire002.3DE");
            obj3de.ExportJson($"{obj3de.FileName}.json");

            #endregion

            #region seff

            var seff = Reader.ReadFromFile<Seff>("weapon.seff");
            seff.ExportJson($"{seff.FileName}.json");

            #endregion

            #region wtr

            var wtr = Reader.ReadFromFile<Wtr>("A2.wtr");
            wtr.ExportJson($"{wtr.FileName}.json");

            #endregion
        }
    }
}
