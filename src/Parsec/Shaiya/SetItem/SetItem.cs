using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.SETITEM
{
    public class SetItem : FileBase
    {
        [JsonIgnore]
        public int Total { get; set; }
        public List<Set> Sets { get; } = new();

        public SetItem(string path) : base(path)
        {
        }

        public override void Read()
        {
            Total = _binaryReader.Read<int>();

            for (int i = 0; i < Total; i++)
            {
                var set = new Set(_binaryReader);
                Sets.Add(set);
            }
        }

        public override void Write(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}
