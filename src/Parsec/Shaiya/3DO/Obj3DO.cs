using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Attributes;
using Parsec.Common;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DO
{
    public class Obj3DO : FileBase, IJsonReadable
    {
        [ShaiyaProperty]
        [LengthPrefixedString(includeStringTerminator: false)]
        public string TextureName { get; set; }

        [ShaiyaProperty]
        [LengthPrefixedList(typeof(Vertex))]
        public List<Vertex> Vertices { get; set; } = new();

        [ShaiyaProperty]
        [LengthPrefixedList(typeof(Face))]
        public List<Face> Faces { get; set; } = new();

        [JsonIgnore]
        public override string Extension => "3DO";
    }
}
