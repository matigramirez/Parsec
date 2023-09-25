namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class LengthPrefixedStringAttribute : Attribute
{
    public bool IncludeStringTerminator { get; set; }

    public string Suffix { get; set; }

    public LengthPrefixedStringAttribute()
    {
    }

    public LengthPrefixedStringAttribute(bool includeStringTerminator)
    {
        IncludeStringTerminator = includeStringTerminator;
    }
}
