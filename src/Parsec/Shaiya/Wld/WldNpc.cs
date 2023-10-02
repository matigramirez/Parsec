using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class WldNpc : IBinary
{
    public int Type { get; set; }

    public int TypeId { get; set; }

    public Vector3 Coordinates { get; set; }

    public float Orientation { get; set; }

    public List<WldNpcPatrolCoordinate> PatrolCoordinates { get; set; } = new();

    [JsonConstructor]
    public WldNpc()
    {
    }

    public WldNpc(SBinaryReader binaryReader)
    {
        Type = binaryReader.Read<int>();
        TypeId = binaryReader.Read<int>();
        Coordinates = new Vector3(binaryReader);
        Orientation = binaryReader.Read<float>();

        int patrolCoordinatesCount = binaryReader.Read<int>();
        for (int i = 0; i < patrolCoordinatesCount; i++)
            PatrolCoordinates.Add(new WldNpcPatrolCoordinate(binaryReader));
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Type.GetBytes());
        buffer.AddRange(TypeId.GetBytes());
        buffer.AddRange(Coordinates.GetBytes());
        buffer.AddRange(Orientation.GetBytes());
        buffer.AddRange(PatrolCoordinates.GetBytes());
        return buffer;
    }
}
