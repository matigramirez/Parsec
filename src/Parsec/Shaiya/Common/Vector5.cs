using System;
using Newtonsoft.Json;
using Parsec.Readers;

namespace Parsec.Shaiya.Common
{
    /// <summary>
    /// Represents a vector in a 5-dimensional space
    /// </summary>
    public class Vector5
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
        /// 3rd (third) element of the vector
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// 4th (forth) element of the vector
        /// </summary>
        public float W { get; set; }

        /// <summary>
        /// 5th (fifth) element of the vector
        /// </summary>
        public float U { get; set; }

        public Vector5(float x, float y, float z, float w, float u)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
            U = u;
        }

        /// <summary>
        /// The vector's length
        /// </summary>
        [JsonIgnore]
        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2) + Math.Pow(W, 2) + Math.Pow(U, 2));

        public Vector5(ShaiyaBinaryReader binaryReader)
        {
            X = binaryReader.Read<float>();
            Y = binaryReader.Read<float>();
            Z = binaryReader.Read<float>();
            W = binaryReader.Read<float>();
            U = binaryReader.Read<float>();
        }
    }
}
