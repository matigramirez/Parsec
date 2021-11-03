using System;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.Common
{
    /// <summary>
    /// Represents a vector in a 2-dimensional space
    /// </summary>
    public class Vector2
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

        public Vector2(ShaiyaBinaryReader binaryReader)
        {
            X = binaryReader.Read<float>();
            Y = binaryReader.Read<float>();
        }
    }
}
