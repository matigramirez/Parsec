using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectMesh : ISerializable
{
    public string Name { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.WriteLengthPrefixedString(Name);
    }
}
