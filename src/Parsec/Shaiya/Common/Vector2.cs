using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common
{
    /// <summary>
    /// Represents a vector in a 2-dimensional space
    /// </summary>
    public class Vector2 : IBinary
    {
        /// <summary>
        /// 1st (first) element of the vector
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// 2nd (second) element of the vector
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// The vector's length
        /// </summary>
        [JsonIgnore]
        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

        [JsonConstructor]
        public Vector2()
        {
        }

        public Vector2(SBinaryReader binaryReader)
        {
            X = binaryReader.Read<float>();
            Y = binaryReader.Read<float>();
        }

        public byte[] GetBytes(params object[] options)
        {
            var buffer = new List<byte>();
            buffer.AddRange(BitConverter.GetBytes(X));
            buffer.AddRange(BitConverter.GetBytes(Y));
            return buffer.ToArray();
        }
    }
}
