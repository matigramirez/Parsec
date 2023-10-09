using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectSub4 : ISerializable
{
    public int Unknown { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        Unknown = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Unknown);
    }
}
