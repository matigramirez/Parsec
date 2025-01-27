using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectSequenceRecord : ISerializable
{
    public int EffectId { get; set; }

    public float Time { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        EffectId = binaryReader.ReadInt32();
        Time = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(EffectId);
        binaryWriter.Write(Time);
    }
}
