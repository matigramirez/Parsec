using Parsec.Shaiya.ITM;
using Parsec.Shaiya.MLT;
using Parsec.Shaiya.OBJ3DC;
using Parsec.Shaiya.OBJ3DO;
using Parsec.Shaiya.SMOD;

namespace Parsec.Samples.Object3D
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 3DC

            var obj3dc = new Obj3DC("Mob_Fox_01.3DC");
            obj3dc.Read();
            obj3dc.ExportJson($"{obj3dc.FileName}.json", enumFriendly: true);

            #endregion

            #region MLT

            var mlt = new MLT("humf_face.MLT");
            mlt.Read();
            mlt.ExportJson($"{mlt.FileName}.json");

            #endregion

            #region 3DO

            var obj3do = new Obj3DO("03_F_201.3DO");
            obj3do.Read();
            obj3do.ExportJson($"{obj3do.FileName}.json");

            #endregion

            #region ITM

            var itm = new ITM("02.ITM");
            itm.Read();
            itm.ExportJson($"{itm.FileName}.json");

            #endregion

            #region SMOD

            var smod = new Smod("A1_ElfDoor.SMOD");
            smod.Read();
            smod.ExportJson($"{smod.FileNameWithoutExtension}.json");

            #endregion
        }
    }
}
