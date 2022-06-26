using Parsec.Attributes;
using Parsec.Extensions;
using Parsec.Readers;
using Parsec.Shaiya.Core;

namespace Parsec.Shaiya.Common;

public class String256 : IBinary
{
    [ShaiyaProperty]
    [FixedLengthString(256)]
    public string Value { get; set; }

    public String256()
    {
    }

    public String256(SBinaryReader binaryReader)
    {
        Value = binaryReader.ReadString(256);
    }

    public IEnumerable<byte> GetBytes(params object[] options) => Value.PadRight(256, '\0').GetBytes();
}
