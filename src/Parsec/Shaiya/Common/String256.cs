using System.Text;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

public sealed class String256 : ISerializable
{
    public string Value { get; set; } = string.Empty;

    public char PaddingChar { get; set; } = '\0';

    public void Read(SBinaryReader binaryReader)
    {
        var unparsedBytes = binaryReader.ReadBytes(256);
        var stringEndIndex = 0;

        for (var i = 0; i < 256; i++)
        {
            if (unparsedBytes[i] == 0)
            {
                stringEndIndex = i;
                break;
            }
        }

        Value = Encoding.ASCII.GetString(unparsedBytes, 0, stringEndIndex);
    }

    public void Write(SBinaryWriter binaryWriter)
    {
        var value = Value.PadRight(256, PaddingChar);
        binaryWriter.Write(value, isLengthPrefixed: false, includeStringTerminator: false);
    }

    public override string ToString() => Value;

    public static implicit operator string(String256 string256) => string256.ToString();

    public static implicit operator String256(string str) => new() { Value = str };
}
