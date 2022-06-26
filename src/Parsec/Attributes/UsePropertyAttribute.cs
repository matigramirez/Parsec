namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class UsePropertyAttribute : Attribute
{
    public UsePropertyAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; set; }
}
