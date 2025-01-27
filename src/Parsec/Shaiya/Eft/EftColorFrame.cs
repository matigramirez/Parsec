using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftColorFrame : ISerializable
{
    public EftColor Color { get; set; }

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Color = binaryReader.Read<EftColor>();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Color);
        binaryWriter.Write(Time);
    }
}
