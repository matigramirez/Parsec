using System.Text;
using Parsec.Attributes;
using Parsec.Extensions;
using Parsec.Serialization;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

public sealed class String256 : IBinary
{
    public String256()
    {
    }

    public String256(string str)
    {
        Value = str;
    }

    public String256(SBinaryReader binaryReader)
    {
        byte[] unparsedBytes = binaryReader.ReadBytes(256);
        int stringEndIndex = 0;

        for (int i = 0; i < 256; i++)
        {
            if (unparsedBytes[i] == 0)
            {
                stringEndIndex = i;
                break;
            }
        }

        Value = Encoding.ASCII.GetString(unparsedBytes, 0, stringEndIndex);
    }

    [ShaiyaProperty]
    [FixedLengthString(isString256: true)]
    public string Value { get; set; }

    public IEnumerable<byte> GetBytes(params object[] options) => Value.PadRight(256, '\0').GetBytes();

    public override string ToString() => Value;

    public static implicit operator string(String256 string256) => string256.ToString();

    public static implicit operator String256(string str) => new(str);
}
