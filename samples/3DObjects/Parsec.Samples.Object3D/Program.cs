using Parsec.Shaiya.OBJ3DC;
using Parsec.Shaiya.OBJ3DO;

namespace Parsec.Samples.Object3D
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 3DC

            var obj3dc = new Obj3DC("Mob_Fox_01.3DC");
            obj3dc.Read();
            obj3dc.ExportJson($"{obj3dc.FileNameWithoutExtension}.json", enumFriendly: true);

            #endregion

            #region 3DO

            var obj3do = new Obj3DO("03_F_201.3DO");
            obj3do.Read();
            obj3do.ExportJson($"{obj3do.FileNameWithoutExtension}.json");

            #endregion
        }
    }
}
