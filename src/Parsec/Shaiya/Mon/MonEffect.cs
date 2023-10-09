using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mon;

public class MonEffect : ISerializable
{
    public int BoneId { get; set; }

    public int EffectId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        BoneId = binaryReader.ReadInt32();
        EffectId = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(BoneId);
        binaryWriter.Write(EffectId);
    }
}
