using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Common;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.WLD;

public sealed class Texture : IBinary
{
    /// <summary>
    /// .tga texture file
    /// </summary>
    public String256 TextureName { get; set; }

    /// <summary>
    /// Texture tile size
    /// </summary>
    public float TileSize { get; set; }

    /// <summary>
    /// .wav sound file
    /// </summary>
    public String256 SoundName { get; set; }

    [JsonConstructor]
    public Texture()
    {
    }

    public Texture(SBinaryReader binaryReader)
    {
        TextureName = new String256(binaryReader);
        TileSize = binaryReader.Read<float>();
        SoundName = new String256(binaryReader);
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();
        buffer.AddRange(TextureName.GetBytes());
        buffer.AddRange(TileSize.GetBytes());
        buffer.AddRange(SoundName.GetBytes());
        return buffer;
    }
}
