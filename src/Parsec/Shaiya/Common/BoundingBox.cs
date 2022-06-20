using Parsec.Attributes;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Cube formed by the volume between 2 points which form its diagonal.
/// The cube is unique; it doesn't form any angle with the x and y axis.
/// </summary>
public struct BoundingBox : IBinary
{
    /// <summary>
    /// Point used as reference for the rectangle
    /// </summary>
    [ShaiyaProperty]
    public Vector3 LowerLimit { get; set; }

    /// <summary>
    /// Point used as reference for the rectangle
    /// </summary>
    [ShaiyaProperty]
    public Vector3 UpperLimit { get; set; }

    public BoundingBox(Vector3 lowerLimit, Vector3 upperLimit)
    {
        LowerLimit = lowerLimit;
        UpperLimit = upperLimit;
    }

    public BoundingBox(SBinaryReader binaryReader)
    {
        LowerLimit = new Vector3(binaryReader);
        UpperLimit = new Vector3(binaryReader);
    }

    /// <inheritdoc />
    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(LowerLimit.GetBytes());
        buffer.AddRange(UpperLimit.GetBytes());
        return buffer;
    }
}
