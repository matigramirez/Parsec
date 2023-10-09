using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mon;

public sealed class MonObject : ISerializable
{
    /// <summary>
    /// Name of the .3DC mesh file
    /// </summary>
    public string MeshName { get; set; } = string.Empty;

    /// <summary>
    /// Name of the .dds texture file
    /// </summary>
    public string TextureName { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        MeshName = binaryReader.ReadString();
        TextureName = binaryReader.ReadString();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MeshName);
        binaryWriter.Write(TextureName);
    }
}
