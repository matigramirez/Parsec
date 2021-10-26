using System;

namespace Parsec.Shaiya.Common
{
    /// <summary>
    /// Represents a vector in a 2-dimensional space
    /// </summary>
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
    }
}
