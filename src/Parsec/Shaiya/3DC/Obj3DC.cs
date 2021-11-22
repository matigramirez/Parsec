using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Helpers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.OBJ3DC
{
    /// <summary>
    /// Class that represents a .3DC model which is used for characters, mobs, npc's, wings and any model that requires "complex" animations done through its skeleton.
    /// </summary>
    public class Obj3DC : FileBase, IJsonReadable
    {

        /// <summary>
        ///  Indicates the format of the 3DC file. Its value is 0 for EP5 format and 0x01BC for EP6+ format
        /// </summary>
        public int Tag { get; set; }

        /// <summary>
        /// The format of this file which is taken from the <see cref="Tag"/> value
        /// </summary>
        public Format Format => Tag > 0 ? Format.EP6 : Format.EP5;

        /// <summary>
        /// List of bones linked to this 3d model. Although a model might be linked to a few bones (for example boots models), the 3DC file contains the definitions for all the bones in the whole skeleton.
        /// </summary>
        public List<Bone3DC> Bones { get; } = new();

        /// <summary>
        /// List of vertices which are used to make polygons
        /// </summary>
        public List<Vertex3DC> Vertices { get; set; } = new();

        /// <summary>
        /// List of polygons that give shape to the mesh of the 3d model. Polygons can only be made up of 3 vertices, so they'll all be triangular
        /// </summary>
        public List<Polygon3DC> Polygons { get; set; } = new();

        public Obj3DC(string path) : base(path)
        {
        }

        [JsonConstructor]
        public Obj3DC()
        {
        }

        public override void Read()
        {
            Tag = _binaryReader.Read<int>();

            var boneCount = _binaryReader.Read<int>();

            for (int i = 0; i < boneCount; i++)
            {
                var bone = new Bone3DC(i, _binaryReader);
                Bones.Add(bone);
            }

            var vertexCount = _binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex3DC(i, Format, _binaryReader);
                Vertices.Add(vertex);
            }

            var polygonCount = _binaryReader.Read<int>();

            for (int i = 0; i < polygonCount; i++)
            {
                var polygon = new Polygon3DC(_binaryReader);
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

        /// <summary>
        /// Method that merges an external 3DC object into the current one in use
        /// </summary>
        /// <param name="obj3dc">External 3DC object to merge</param>
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

        /// <summary>
        /// Method that merges two or more 3DC objects together, meaning that all their vertices and polygons will be put together in the same object
        /// </summary>
        /// <param name="objects">Array of 3DC objects to merge</param>
        public void Merge(params Obj3DC[] objects)
        {
            foreach (var obj in objects)
                Merge(obj);
        }
    }
}
