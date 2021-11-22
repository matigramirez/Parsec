using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Readers;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.OBJ3DC
{
    public class Vertex3DC
    {
        /// <summary>
        /// The vertex index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// X coordinate
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Z coordinate
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// If the 3DC file's format is EP5 or inferior, this value is shared between <see cref="BoneVertexGroup1"/> and <see cref="BoneVertexGroup2"/>, it indicates the weight of this vertex for those vertex groups.
        /// If the file's format is EP6 or superior, this value is the weight for <see cref="BoneVertexGroup1"/> only.
        /// </summary>
        public float BoneWeight { get; set; }

        /// <summary>
        /// Bone weight for <see cref="BoneVertexGroup2"/> Present in EP6+ format only
        /// </summary>
        public float Bone2Weight { get; set; }

        /// <summary>
        /// Present in EP6+ format
        /// </summary>
        public float Bone3Weight { get; set; }

        /// <summary>
        /// The first vertex group this vertex belongs. The vertex group belongs to a bone.
        /// </summary>
        public byte BoneVertexGroup1 { get; set; }

        /// <summary>
        /// The second vertex group this vertex belongs. The vertex group belongs to a bone.
        /// </summary>
        public byte BoneVertexGroup2 { get; set; }

        /// <summary>
        /// The third vertex group this vertex belongs. The vertex group belongs to a bone.
        /// </summary>
        public byte BoneVertexGroup3 { get; set; }

        /// <summary>
        /// Unknown byte. Always 0.
        /// </summary>
        public byte Unknown { get; set; }

        /// <summary>
        /// Normal of this point, used for lighting computation.
        /// </summary>
        public Vector3 Normal { get; set; }

        /// <summary>
        /// U coordinate of the UV mapping for the 2D texture. For more information visit
        /// <a href="https://en.wikipedia.org/wiki/UV_mapping">this link</a>.
        /// </summary>
        public float U { get; set; }

        /// <summary>
        /// V coordinate of the UV mapping for the 2D texture. For more information visit
        /// <a href="https://en.wikipedia.org/wiki/UV_mapping">this link</a>.
        /// </summary>
        public float V { get; set; }

        public Vertex3DC(int index, Format format, ShaiyaBinaryReader binaryReader)
        {
            Index = index;
            X = binaryReader.Read<float>();
            Y = binaryReader.Read<float>();
            Z = binaryReader.Read<float>();
            BoneWeight = binaryReader.Read<float>();

            if (format >= Format.EP6)
            {
                Bone2Weight = binaryReader.Read<float>();
                Bone3Weight = binaryReader.Read<float>();
            }

            BoneVertexGroup1 = binaryReader.Read<byte>();
            BoneVertexGroup2 = binaryReader.Read<byte>();
            BoneVertexGroup3 = binaryReader.Read<byte>();

            Unknown = binaryReader.Read<byte>();

            Normal = new Vector3(binaryReader);

            U = binaryReader.Read<float>();
            V = binaryReader.Read<float>();
        }

        [JsonConstructor]
        public Vertex3DC()
        {
        }

        /// <summary>
        /// Serializes the vertex data into a byte array that's ready to be written into a file
        /// </summary>
        /// <param name="format">The desired format for the vertex binary data</param>
        public byte[] GetBytes(Format format)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(X));
            buffer.AddRange(BitConverter.GetBytes(Y));
            buffer.AddRange(BitConverter.GetBytes(Z));
            buffer.AddRange(BitConverter.GetBytes(BoneWeight));

            if (format >= Format.EP6)
            {
                buffer.AddRange(BitConverter.GetBytes(Bone2Weight));
                buffer.AddRange(BitConverter.GetBytes(Bone3Weight));
            }

            buffer.Add(BoneVertexGroup1);
            buffer.Add(BoneVertexGroup2);
            buffer.Add(BoneVertexGroup3);
            buffer.Add(Unknown);
            buffer.AddRange(Normal.GetBytes());
            buffer.AddRange(BitConverter.GetBytes(U));
            buffer.AddRange(BitConverter.GetBytes(V));

            return buffer.ToArray();
        }
    }
}
