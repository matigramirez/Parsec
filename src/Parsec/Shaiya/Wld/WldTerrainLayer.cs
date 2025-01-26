using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wld;

public sealed class WldTerrainLayer : ISerializable
{
    /// <summary>
    /// Name of the texture file. Even though the game uses .dds files, this field always uses the ".tga" extension and gets
    /// replaced at runtime by the game client
    /// </summary>
    public String256 TextureFileName { get; set; } = string.Empty;

    /// <summary>
    /// Texture tile size
    /// </summary>
    public float LayerTileSize { get; set; }

    /// <summary>
    /// Sound that is played when a player walks over the terrain layer
    /// </summary>
    public String256 WalkSoundFileName { get; set; } = string.Empty;

    public void Read(SBinaryReader binaryReader)
    {
        TextureFileName = binaryReader.Read<String256>();
        LayerTileSize = binaryReader.ReadSingle();
        WalkSoundFileName = binaryReader.Read<String256>();
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        binaryWriter.Write(TextureFileName);
        binaryWriter.Write(LayerTileSize);
        binaryWriter.Write(WalkSoundFileName);
    }
}
