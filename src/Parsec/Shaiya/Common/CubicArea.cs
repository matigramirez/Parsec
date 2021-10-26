using Parsec.Readers;

namespace Parsec.Shaiya.Common
{
    /// <summary>
    /// Cube formed by the volume between 2 points which form its diagonal.
    /// The cube is unique; it doesn't form any angle with the x and y axis.
    /// </summary>
    public class CubicArea
    {
        /// <summary>
        /// Point used as reference for the rectangle
        /// </summary>
        public Vector3 LowerLimit { get; set; }

        /// <summary>
        /// Point used as reference for the rectangle
        /// </summary>
        public Vector3 UpperLimit { get; set; }

        public CubicArea(Vector3 lowerLimit, Vector3 upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }

        public CubicArea(ShaiyaBinaryReader binaryReader)
        {
            LowerLimit = new Vector3(binaryReader);
            UpperLimit = new Vector3(binaryReader);
        }
    }
}
