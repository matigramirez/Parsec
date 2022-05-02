using Parsec.Shaiya.Cloak.ClothTexture;
using Parsec.Shaiya.Emblem;
using Parsec.Shaiya.Obj3DC;
using Parsec.Shaiya.Obj3DO;
using Parsec.Shaiya.SMOD;
using Parsec.Shaiya.VAni;

namespace Parsec.Samples.Object3D
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 3DC

            var obj3dc = Reader.ReadFromFile<Obj3DC>("Mob_Fox_01.3DC");
            obj3dc.ExportJson($"{obj3dc.FileName}.json");

            #endregion

            #region 3DO

            var obj3do = Reader.ReadFromFile<Obj3DO>("03_F_201.3DO");
            obj3do.ExportJson($"{obj3do.FileName}.json");

            #endregion

            #region SMOD

            var smod = Reader.ReadFromFile<SMOD>("A1_ElfDoor.SMOD");
            smod.ExportJson($"{smod.FileName}.json");

            #endregion

            #region VAni

            var vani = Reader.ReadFromFile<VAni>("A1_butterfly01.VANI");
            vani.ExportJson($"{vani.FileName}.json");

            #endregion

            #region CTL

            var ctl = Reader.ReadFromFile<CTL>("CLOTH_TEXTHRE_DE.CTL");
            ctl.ExportJson("CLOTH_TEXTHRE_DE.json");

            #endregion

            #region Emblem dat

            var dat = Reader.ReadFromFile<EmblemDat>("EmblemList.dat");
            dat.ExportJson("EmblemList.json");

            #endregion
        }
    }
}
