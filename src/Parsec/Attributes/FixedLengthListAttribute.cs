namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class FixedLengthListAttribute : Attribute
{
    public Type ItemType { get; set; }
    public int Length { get; set; }

    public FixedLengthListAttribute(Type itemType, int length)
    {
        ItemType = itemType;
        Length = length;
    }
}
