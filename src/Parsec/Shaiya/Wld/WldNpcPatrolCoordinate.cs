using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldNpcPatrolCoordinate : ISerializable
{
    public Vector3 Position { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Position = binaryReader.Read<Vector3>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Position);
    }
}
