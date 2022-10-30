using Parsec.Common;
using Parsec.Extensions;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Wtr;

public sealed class Wtr : FileBase
{
    public float Unknown1 { get; set; }
    public int Unknown2 { get; set; }
    public int Unknown3 { get; set; }

    /// <summary>
    /// List of texture file names with a fixed lenght of 256
    /// </summary>
    public List<string> Textures { get; } = new();

    public override string Extension => "wtr";

    public override void Read(params object[] options)
    {
        Unknown1 = _binaryReader.Read<float>();
        Unknown2 = _binaryReader.Read<int>();
        Unknown3 = _binaryReader.Read<int>();

        int textureCount = _binaryReader.Read<int>();
        for (int i = 0; i < textureCount; i++)
        {
            // Read 256-byte strings and trim the null characters
            string texture = _binaryReader.ReadString(256).Trim('\0');
            Textures.Add(texture);
        }
    }

    public override IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown)
    {
        var buffer = new List<byte>();
        buffer.AddRange(Unknown1.GetBytes());
        buffer.AddRange(Unknown2.GetBytes());
        buffer.AddRange(Unknown3.GetBytes());
        buffer.AddRange(Textures.Count.GetBytes());

        foreach (string texture in Textures)
        {
            buffer.AddRange(texture.GetBytes());

            // Add extra null characters if needed if needed
            if (texture.Length < 256)
                buffer.AddRange(new byte[256 - texture.Length]);
        }

        return buffer;
    }
}
