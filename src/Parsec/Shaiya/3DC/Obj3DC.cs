using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DC
{
    /// <summary>
    /// Class that represents a .3DC model which is used for characters, mobs, npc's, wings and any model that requires "complex" animations done through its skeleton.
    /// </summary>
    public class Obj3DC : FileBase, IJsonReadable
    {
        /// <summary>
        ///  Indicates the format of the 3DC file. Its value is 0 for EP5 format and 0x01BC for EP6+ format
        /// </summary>
        public int Signature { get; set; }

        /// <summary>
        /// The format of this file which is taken from the <see cref="Signature"/> value
        /// </summary>
        public Episode Episode => Signature > 0 ? Episode.EP6 : Episode.EP5;

        /// <summary>
        /// List of bones linked to this 3d model. Although a model might be linked to a few bones (for example boots models), the 3DC file contains the definitions for all the bones in the whole skeleton.
        /// </summary>
        public List<Bone> Bones { get; } = new();

        /// <summary>
        /// List of vertices which are used to make faces (polygons)
        /// </summary>
        public List<Vertex> Vertices { get; set; } = new();

        /// <summary>
        /// List of faces (polygons) that give shape to the mesh of the 3d model. Faces can only be made up of 3 vertices, so they'll all be triangular
        /// </summary>
        public List<Face> Faces { get; set; } = new();

        [JsonIgnore]
        public override string Extension => "3DC";

        public override void Read(params object[] options)
        {
            Signature = _binaryReader.Read<int>();

            var boneCount = _binaryReader.Read<int>();

            for (int i = 0; i < boneCount; i++)
            {
                var bone = new Bone(_binaryReader, i);
                Bones.Add(bone);
            }

            var vertexCount = _binaryReader.Read<int>();

            for (int i = 0; i < vertexCount; i++)
            {
                var vertex = new Vertex(i, Episode, _binaryReader);
                Vertices.Add(vertex);
            }

            var faceCount = _binaryReader.Read<int>();

            for (int i = 0; i < faceCount; i++)
            {
                var face = new Face(_binaryReader);
                face.Vertex1 = Vertices[face.VertexIndex1];
                face.Vertex2 = Vertices[face.VertexIndex2];
                face.Vertex3 = Vertices[face.VertexIndex3];
                Faces.Add(face);
            }
        }

        public override IEnumerable<byte> GetBytes(Episode? episode = null)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Signature.GetBytes());

            buffer.AddRange(Bones.GetBytes());
            buffer.AddRange(Vertices.Count.GetBytes());

            foreach (var vertex in Vertices)
                buffer.AddRange(vertex.GetBytes(Episode));

            buffer.AddRange(Faces.GetBytes());

            return buffer.ToArray();
        }

        /// <summary>
        /// Method that merges an external 3DC object into the current one in use
        /// </summary>
        /// <param name="obj3dc">External 3DC object to merge</param>
        private void Merge(Obj3DC obj3dc)
        {
            // Merge vertices
            foreach (var vertex in obj3dc.Vertices)
                Vertices.Add(vertex);

            // Merge faces
            foreach (var face in obj3dc.Faces)
                Faces.Add(face);

            // Fix vertex index on faces
            foreach (var face in Faces)
            {
                face.VertexIndex1 = (ushort)Vertices.IndexOf(face.Vertex1);
                face.VertexIndex2 = (ushort)Vertices.IndexOf(face.Vertex2);
                face.VertexIndex3 = (ushort)Vertices.IndexOf(face.Vertex3);
            }
        }

        /// <summary>
        /// Method that merges two or more 3DC objects together, meaning that all their vertices and faces will be put together in the same object
        /// </summary>
        /// <param name="objects">Array of 3DC objects to merge</param>
        public void Merge(params Obj3DC[] objects)
        {
            foreach (var obj in objects)
                Merge(obj);
        }
    }
}
