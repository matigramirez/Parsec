using System.Text;
using Parsec.Common;

namespace Parsec.Serialization;

public class BinarySerializationOptions
{
    public BinarySerializationOptions()
    {
    }

    public BinarySerializationOptions(Episode episode)
    {
        Episode = episode;
    }

    public BinarySerializationOptions(Encoding encoding)
    {
        Encoding = encoding;
    }

    public BinarySerializationOptions(Episode episode, Encoding? encoding)
    {
        Episode = episode;
        Encoding = encoding ?? Encoding.ASCII;
    }

    public Episode Episode { get; set; } = Episode.Unknown;

    public Encoding Encoding { get; set; } = Encoding.ASCII;

    public object? ExtraOption { get; set; }

    public static BinarySerializationOptions Default => new();
}
