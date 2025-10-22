using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Eft;

public sealed class EftSprite : ISerializable
{
    /// <summary>
    /// Name of the texture associated to this sprite
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        Name = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(Name);
    }
}
