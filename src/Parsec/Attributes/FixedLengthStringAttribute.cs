namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class FixedLengthStringAttribute : Attribute
{
    public int Length { get; set; }
    public bool IncludeStringTerminator { get; set; }
    public bool IsString256 { get; set; }
    public string Suffix { get; set; }

    public FixedLengthStringAttribute(int length)
    {
        Length = length;
    }

    public FixedLengthStringAttribute(bool isString256)
    {
        IsString256 = isString256;
    }

    public FixedLengthStringAttribute(int length, bool removeStringTerminator)
    {
        Length = length;
        IncludeStringTerminator = removeStringTerminator;
    }
}
