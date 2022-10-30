using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak.ClothTexture;

public sealed class CTL : FileBase
{
    [JsonConstructor]
    public CTL()
    {
    }

    public List<Texture> Textures { get; } = new();

    [JsonIgnore]
    public override string Extension => "CTL";

    public override void Read(params object[] options)
    {
        int textureCount = _binaryReader.Read<int>();
        for (int i = 0; i < textureCount; i++)
            Textures.Add(new Texture(_binaryReader, 256, (char)0xCD));
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Textures.Count.GetBytes());
        foreach (var texture in Textures)
            buffer.AddRange(texture.GetBytes(256, (char)0xCD));

        return buffer;
    }
}
