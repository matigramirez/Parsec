using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldTexture : ISerializable
{
    /// <summary>
    /// .tga texture file
    /// </summary>
    public String256 TextureName { get; set; } = string.Empty;

    /// <summary>
    /// Texture tile size
    /// </summary>
    public float TileSize { get; set; }

    /// <summary>
    /// .wav sound file
    /// </summary>
    public String256 WalkSound { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        TextureName = binaryReader.Read<String256>();
        TileSize = binaryReader.ReadSingle();
        WalkSound = binaryReader.Read<String256>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(TextureName);
        binaryWriter.Write(TileSize);
        binaryWriter.Write(WalkSound);
    }
}
