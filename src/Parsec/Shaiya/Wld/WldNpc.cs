using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldNpc : ISerializable
{
    public int Type { get; set; }

    public int TypeId { get; set; }

    public Vector3 Position { get; set; }

    public float Orientation { get; set; }

    public List<Vector3> PatrolPositions { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Type = binaryReader.ReadInt32();
        TypeId = binaryReader.ReadInt32();
        Position = binaryReader.Read<Vector3>();
        Orientation = binaryReader.ReadSingle();
        PatrolPositions = binaryReader.ReadList<Vector3>().ToList();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Type);
        binaryWriter.Write(TypeId);
        binaryWriter.Write(Position);
        binaryWriter.Write(Orientation);
        binaryWriter.Write(PatrolPositions.ToSerializable());
    }
}
