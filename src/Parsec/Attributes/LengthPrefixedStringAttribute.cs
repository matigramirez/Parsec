using System.Text;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class LengthPrefixedStringAttribute : Attribute
{
    public Encoding Encoding { get; set; } = Encoding.ASCII;
    public bool IncludeStringTerminator { get; set; }

    public string Suffix { get; set; }

    public LengthPrefixedStringAttribute()
    {
    }

    public LengthPrefixedStringAttribute(Encoding encoding)
    {
        Encoding = encoding;
    }

    public LengthPrefixedStringAttribute(bool includeStringTerminator)
    {
        IncludeStringTerminator = includeStringTerminator;
    }

    public LengthPrefixedStringAttribute(Encoding encoding, bool includeStringTerminator)
    {
        Encoding = encoding;
        IncludeStringTerminator = includeStringTerminator;
    }
}
