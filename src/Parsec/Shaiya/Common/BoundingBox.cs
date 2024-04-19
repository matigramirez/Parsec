﻿using System.Text.Json.Serialization;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

/// <summary>
/// Cube formed by the volume between 2 points which form its diagonal.
/// The cube is unique; it doesn't form any angle with the x and y axis.
/// </summary>
public class BoundingBox : ISerializable
{
    /// <summary>
    /// Point used as reference for the rectangle
    /// </summary>
    public Vector3 LowerLimit { get; set; } = new();

    /// <summary>
    /// Point used as reference for the rectangle
    /// </summary>
    public Vector3 UpperLimit { get; set; } = new();

    [JsonIgnore]
    public double Radius
    {
        get
        {
            var x = UpperLimit.X - LowerLimit.X;
            var y = UpperLimit.Y - LowerLimit.Y;
            var z = UpperLimit.Z - LowerLimit.Z;
            return Math.Sqrt(x * x + y * y + z * z) / 2f;
        }
    }

    public void Read(SBinaryReader binaryReader)
    {
        LowerLimit = binaryReader.Read<Vector3>();
        UpperLimit = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(LowerLimit);
        binaryWriter.Write(UpperLimit);
    }
}
