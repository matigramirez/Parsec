using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya._3do;

public sealed class _3doVertex : ISerializable
{
    public Vector3 Coordinates { get; set; } = new();

    public Vector3 Normal { get; set; } = new();

    public Vector2 UV { get; set; } = new();

    public void Read(SBinaryReader binaryReader)
    {
        Coordinates = binaryReader.Read<Vector3>();
        Normal = binaryReader.Read<Vector3>();
        UV = binaryReader.Read<Vector2>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Coordinates);
        binaryWriter.Write(Normal);
        binaryWriter.Write(UV);
    }
}
