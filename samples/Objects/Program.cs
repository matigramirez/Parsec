using Parsec.Readers;
using Parsec.Shaiya.Itm;
using Parsec.Shaiya.Mlt;
using Parsec.Shaiya.Obj3DC;
using Parsec.Shaiya.Obj3DO;
using Parsec.Shaiya.Smod;

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

            #region MLT

            var mlt = Reader.ReadFromFile<MLT>("humf_face.MLT");
            mlt.ExportJson($"{mlt.FileName}.json");

            #endregion

            #region 3DO

            var obj3do = Reader.ReadFromFile<Obj3DO>("03_F_201.3DO");
            obj3do.ExportJson($"{obj3do.FileName}.json");

            #endregion

            #region ITM

            var itm = Reader.ReadFromFile<ITM>("02.ITM");
            itm.ExportJson($"{itm.FileName}.json");

            #endregion

            #region SMOD

            var smod = Reader.ReadFromFile<Smod>("A1_ElfDoor.SMOD");
            smod.ExportJson($"{smod.FileNameWithoutExtension}.json");

            #endregion
        }
    }
}
