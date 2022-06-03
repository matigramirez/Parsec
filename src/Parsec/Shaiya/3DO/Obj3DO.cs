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
        public List<Vertex> Vertices { get; } = new();

        [ShaiyaProperty]
        [LengthPrefixedList(typeof(Face))]
        public List<Face> Faces { get; } = new();

        [JsonIgnore]
        public override string Extension => "3DO";

        public override void Read(params object[] options)
        {
            TextureName = _binaryReader.ReadString();

            var vertexCount = _binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex(_binaryReader);
                Vertices.Add(vertex);
            }

            var faceCount = _binaryReader.Read<int>();

            for (int i = 0; i < faceCount; i++)
            {
                var face = new Face(_binaryReader);
                Faces.Add(face);
            }
        }
    }
}
