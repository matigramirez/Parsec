using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Obj3DC
{
    public class Vertex : IBinary
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
        /// UV mapping for the 2D texture. For more information visit
        /// <a href="https://en.wikipedia.org/wiki/UV_mapping">this link</a>.
        /// </summary>
        public Vector2 UV { get; set; }

        public Vertex(int index, Format format, SBinaryReader binaryReader)
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

            UV = new Vector2(binaryReader);
        }

        [JsonConstructor]
        public Vertex()
        {
        }

        /// <summary>
        /// Serializes the vertex data into a byte array that's ready to be written into a file
        /// Expects <see cref="Format"/> as an option parameter
        /// </summary>
        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();

            var format = Format.EP5;

            if (options.Length > 0)
                format = (Format)options[0];

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
            buffer.AddRange(UV.GetBytes());

            return buffer.ToArray();
        }
    }
}
