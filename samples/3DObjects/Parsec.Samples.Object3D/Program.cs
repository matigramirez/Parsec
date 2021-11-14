using System.Collections.Generic;
using Parsec.Shaiya.OBJ3DC;

namespace Parsec.Samples.Object3D
{
    class Program
    {
        static void Main(string[] args)
        {
            var ignoredFields = new List<string>
            {
                "isIdentity",
                "format"
            };

            var obj = new Obj3DC("Mob_Fox_01.3DC");
            obj.Read();
            obj.ExportJson($"{obj.FileNameWithoutExtension}.json", ignoredFields);
        }
    }
}
