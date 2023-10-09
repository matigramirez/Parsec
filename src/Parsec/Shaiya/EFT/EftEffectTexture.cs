using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftEffectTexture : ISerializable
{
    public int TextureId { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        TextureId = binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(TextureId);
    }
}
