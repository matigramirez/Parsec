using System;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class SuffixedStringAttribute : Attribute
{
    public string Suffix { get; set; }

    public SuffixedStringAttribute(string suffix)
    {
        Suffix = suffix;
    }
}
