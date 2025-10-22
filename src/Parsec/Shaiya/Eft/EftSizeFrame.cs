using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftSizeFrame : ISerializable
{
    // This could potentially be ScaleX
    public float StartSize { get; set; }

    // This could potentially be ScaleY
    public float EndSize { get; set; }

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        StartSize = binaryReader.ReadSingle();
        EndSize = binaryReader.ReadSingle();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(StartSize);
        binaryWriter.Write(EndSize);
        binaryWriter.Write(Time);
    }
}
