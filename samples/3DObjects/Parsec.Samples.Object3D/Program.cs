using System.Collections.Generic;
using Parsec.Shaiya.OBJ3DC;

namespace Parsec.Samples.Object3D
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj3dc = new Obj3DC("demf_boots001.3DC");
            obj3dc.Read();
            obj3dc.Export("demf_boots001.json", new List<string>{ "isIdentity" }, enumFriendly: true);
        }
    }
}
