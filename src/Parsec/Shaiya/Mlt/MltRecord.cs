using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Mlt;

public sealed class MltRecord : ISerializable
{
    /// <summary>
    /// Index of the .3DC filename
    /// </summary>
    public int MeshIndex { get; set; }

    /// <summary>
    /// Index of the .DDS filename
    /// </summary>
    public int TextureIndex { get; set; }

    /// <summary>
    /// Alpha blending mode
    /// </summary>
    public AlphaBlendingMode AlphaBlendingMode { get; set; }

    public void Read(SBinaryReader binaryReader)
    {
        MeshIndex = binaryReader.ReadInt32();
        TextureIndex = binaryReader.ReadInt32();
        AlphaBlendingMode = (AlphaBlendingMode)binaryReader.ReadInt32();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(MeshIndex);
        binaryWriter.Write(TextureIndex);
        binaryWriter.Write((int)AlphaBlendingMode);
    }
}
