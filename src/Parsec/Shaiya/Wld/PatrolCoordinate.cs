using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

public sealed class PatrolCoordinate
{
    [ShaiyaProperty]
    public Vector3 Position { get; set; }
}
