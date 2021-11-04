using System.Collections.Generic;
using Parsec.Common;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.OBJ3DC
{
    public class Obj3DC : FileBase {
        /// <summary>
        ///  Value is 0 for EP5 format and 0x01BC for EP6+ format
        /// </summary>
        public int Tag { get; set; }

        public Format Format => Tag > 0 ? Format.EP6 : Format.EP5;

        public List<Bone3DC> Bones { get; } = new();

        public List<Vertex3DC> Vertices { get; } = new();

        public List<Polygon> Polygons { get; } = new();

        public Obj3DC(string path) : base(path)
        {
        }

        public override void Read()
        {
            Tag = _binaryReader.Read<int>();

            var boneCount = _binaryReader.Read<int>();

            for (int i = 0; i < boneCount; i++)
            {
                var bone = new Bone3DC(_binaryReader);
                Bones.Add(bone);
            }

            var vertexCount = _binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex3DC(Format, _binaryReader);
                Vertices.Add(vertex);
            }

            var polygonCount = _binaryReader.Read<int>();

            for (int i = 0; i < polygonCount; i++)
            {
                var polygon = new Polygon(_binaryReader);
                Polygons.Add(polygon);
            }
        }
    }
}
