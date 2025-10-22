using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftRotationFrame : ISerializable
{
    public float Rotation { get; set; }

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Rotation = binaryReader.ReadSingle();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Rotation);
        binaryWriter.Write(Time);
    }
}
