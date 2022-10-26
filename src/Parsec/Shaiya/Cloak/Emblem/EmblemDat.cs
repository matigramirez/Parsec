using Newtonsoft.Json;
using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Cloak;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Emblem;

public sealed class EmblemDat : FileBase, IJsonReadable
{
    [JsonConstructor]
    public EmblemDat()
    {
    }

    public List<Texture> Textures { get; } = new();

    [JsonIgnore]
    public override string Extension => "dat";

    public override void Read(params object[] options)
    {
        var textureCount = _binaryReader.Read<int>();

        for (int i = 0; i < textureCount; i++)
        {
            var texture = new Texture(_binaryReader, 260, (char)0xCC);
            Textures.Add(texture);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Textures.Count.GetBytes());

        foreach (var texture in Textures)
            buffer.AddRange(texture.GetBytes(260, 0xCC));

        return buffer;
    }
}
