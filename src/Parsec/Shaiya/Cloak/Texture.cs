using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Cloak;

public class Texture : IBinary
{
    public string Name { get; set; } = "";

    [JsonIgnore]
    private int _fixedLength;

    [JsonIgnore]
    private char _padChar = '\0';

    [JsonConstructor]
    public Texture()
    {
    }

    public Texture(SBinaryReader binaryReader, int length, char padChar)
    {
        _fixedLength = length;
        _padChar = padChar;

        var stringBuffer = binaryReader.ReadBytes(_fixedLength);
        Name = Encoding.ASCII.GetString(stringBuffer.TakeWhile(b => b != '\0').ToArray());
    }

    public IEnumerable<byte> GetBytes(params object[] options)
    {
        var buffer = new List<byte>();

        if (options.Length >= 2)
        {
            _fixedLength = (int)options[0];
            _padChar = Convert.ToChar(options[1]);
        }

        buffer.AddRange(Name.GetLengthPrefixedBytes());

        var padLength = _fixedLength - Name.Length - 1;

        if (padLength > 0)
        {
            var pad = "".PadRight(padLength, _padChar);
            buffer.AddRange(pad.GetBytes());
        }

        return buffer;
    }
}
