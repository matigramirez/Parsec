using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftOpacityFrame : ISerializable
{
    public float Opacity { get; set; }

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Opacity = binaryReader.ReadSingle();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Opacity);
        binaryWriter.Write(Time);
    }
}
