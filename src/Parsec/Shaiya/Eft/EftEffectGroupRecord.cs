using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectGroupRecord : ISerializable
{
    public int EffectId { get; set; }

    public float StartDelay { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        EffectId = binaryReader.ReadInt32();
        StartDelay = binaryReader.ReadSingle();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(EffectId);
        binaryWriter.Write(StartDelay);
    }
}
