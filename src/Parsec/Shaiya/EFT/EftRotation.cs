using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftRotation : ISerializable
{
    public Quaternion Quaternion { get; set; } = new();

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Quaternion = binaryReader.Read<Quaternion>();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Quaternion);
        binaryWriter.Write(Time);
    }
}
