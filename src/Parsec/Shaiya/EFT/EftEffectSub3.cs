using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectSub3 : ISerializable
{
    public float Unknown1 { get; set; }

    public float Unknown2 { get; set; }

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Unknown1 = binaryReader.ReadSingle();
        Unknown2 = binaryReader.ReadSingle();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Unknown1);
        binaryWriter.Write(Unknown2);
        binaryWriter.Write(Time);
    }
}
