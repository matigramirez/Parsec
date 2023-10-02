using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class WldTexture : IBinary
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

    [JsonConstructor]
    public WldTexture()
    {
    }

    public WldTexture(SBinaryReader binaryReader)
    {
        TextureName = new String256(binaryReader);
        TileSize = binaryReader.Read<float>();
        WalkSound = new String256(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(TextureName.GetBytes());
        buffer.AddRange(TileSize.GetBytes());
        buffer.AddRange(WalkSound.GetBytes());
        return buffer;
    }
}
