using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldNpc : ISerializable
{
    public int Type { get; set; }

    public int TypeId { get; set; }

    public Vector3 Coordinates { get; set; }

    public float Orientation { get; set; }

    public List<WldNpcPatrolCoordinate> PatrolCoordinates { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Type = binaryReader.ReadInt32();
        TypeId = binaryReader.ReadInt32();
        Coordinates = binaryReader.Read<Vector3>();
        Orientation = binaryReader.ReadSingle();
        PatrolCoordinates = binaryReader.ReadList<WldNpcPatrolCoordinate>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Type);
        binaryWriter.Write(TypeId);
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(Orientation);
        binaryWriter.Write(PatrolCoordinates.ToSerializable());
    }
}
