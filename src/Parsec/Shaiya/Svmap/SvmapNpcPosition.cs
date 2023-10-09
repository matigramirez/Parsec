using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Svmap;

public sealed class SvmapNpcPosition : ISerializable
{
    public Vector3 Position { get; set; }

    public float Yaw { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Position = binaryReader.Read<Vector3>();
        Yaw = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Position);
        binaryWriter.Write(Yaw);
    }
}
