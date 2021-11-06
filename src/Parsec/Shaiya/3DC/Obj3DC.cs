using System;
using System.Collections.Generic;
using System.Text;
using Parsec.Common;
using Parsec.Helpers;
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
                polygon.Vertex1 = Vertices[polygon.VertexIndex1];
                polygon.Vertex2 = Vertices[polygon.VertexIndex2];
                polygon.Vertex3 = Vertices[polygon.VertexIndex3];
                Polygons.Add(polygon);
            }
        }

        public override void Write(string path)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(Tag));
            buffer.AddRange(BitConverter.GetBytes(Bones.Count));

            foreach (var bone in Bones)
            {
                buffer.AddRange(bone.GetBytes());
            }

            buffer.AddRange(BitConverter.GetBytes(Vertices.Count));

            foreach (var vertex in Vertices)
            {
                buffer.AddRange(vertex.GetBytes(Format));
            }

            buffer.AddRange(BitConverter.GetBytes(Polygons.Count));

            foreach (var polygon in Polygons)
            {
                buffer.AddRange(polygon.GetBytes());
            }

            FileHelper.WriteFile(path, buffer.ToArray());
        }

        private void Merge(Obj3DC obj3dc)
        {
            // Merge vertices
            foreach (var vertex in obj3dc.Vertices)
            {
                Vertices.Add(vertex);
            }

            // Merge polygons
            foreach (var polygon in obj3dc.Polygons)
            {
                Polygons.Add(polygon);
            }

            // Fix vertex index on polygons
            foreach (var polygon in Polygons)
            {
                polygon.VertexIndex1 = (ushort)Vertices.IndexOf(polygon.Vertex1);
                polygon.VertexIndex2 = (ushort)Vertices.IndexOf(polygon.Vertex2);
                polygon.VertexIndex3 = (ushort)Vertices.IndexOf(polygon.Vertex3);
            }
        }

        public void Merge(params Obj3DC[] objects)
        {
            foreach(var obj in objects)
                Merge(obj);
        }
    }
}
