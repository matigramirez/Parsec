﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.VAni
{
    public class VertexFrame : IBinary
    {
        /// <summary>
        /// The vertex coordinates in the 3d space
        /// </summary>
        public Vector3 Coordinates { get; set; }

        /// <summary>
        /// The vertex normal
        /// </summary>
        public Vector3 Normal { get; set; }

        /// <summary>
        /// VAni's don't have bones, that's why this value is always -1.
        /// </summary>
        public int BoneIndex { get; set; } = -1;

        /// <summary>
        /// Texture mapping
        /// </summary>
        public Vector2 UV { get; set; }

        [JsonConstructor]
        public VertexFrame()
        {
        }

        public VertexFrame(SBinaryReader binaryReader)
        {
            Coordinates = new Vector3(binaryReader);
            Normal = new Vector3(binaryReader);
            BoneIndex = binaryReader.Read<int>();
            UV = new Vector2(binaryReader);
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(Coordinates.GetBytes());
            buffer.AddRange(Normal.GetBytes());
            buffer.AddRange(BoneIndex.GetBytes());
            buffer.AddRange(UV.GetBytes());
            return buffer.ToArray();
        }
    }
}