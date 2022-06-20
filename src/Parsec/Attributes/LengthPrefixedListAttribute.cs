namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class LengthPrefixedListAttribute : Attribute
{
    public Type ItemType { get; set; }
    public Type LengthType { get; set; } = typeof(int);

    public LengthPrefixedListAttribute(Type itemType)
    {
        ItemType = itemType;
    }

    public LengthPrefixedListAttribute(Type itemType, Type lengthType)
    {
        ItemType = itemType;
        LengthType = lengthType;
    }
}
