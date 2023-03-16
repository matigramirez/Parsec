using System.Numerics;
using Parsec.Attributes;

namespace Parsec.Shaiya.WLD;

public sealed class PatrolCoordinate
{
    [ShaiyaProperty]
    public Vector3 Position { get; set; }
}
