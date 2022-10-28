using System.Text;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class FixedLengthStringAttribute : Attribute
{
    public int Length { get; set; }
    public Encoding Encoding { get; set; } = Encoding.ASCII;
    public bool IncludeStringTerminator { get; set; }

    public string Suffix { get; set; }

    public FixedLengthStringAttribute(int length)
    {
        Length = length;
    }

    public FixedLengthStringAttribute(Encoding encoding, int length, bool removeStringTerminator)
    {
        Encoding = encoding;
        Length = length;
        IncludeStringTerminator = removeStringTerminator;
    }
}
