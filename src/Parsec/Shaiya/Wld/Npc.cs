using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.WLD;

public sealed class Npc
{
    [ShaiyaProperty]
    public int Type { get; set; }

    [ShaiyaProperty]
    public int TypeId { get; set; }

    [ShaiyaProperty]
    public Vector3 Coordinates { get; set; }

    [ShaiyaProperty]
    public float Orientation { get; set; }

    [ShaiyaProperty]
    [LengthPrefixedList(typeof(Vector3))]
    public List<Vector3> PatrolCoordinates { get; } = new();
}
