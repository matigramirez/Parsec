namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ConditionalPropertyAttribute : Attribute
{
    public ConditionalPropertyAttribute(string conditioningPropertyName, object conditioningPropertyValue)
    {
        ConditioningPropertyName = conditioningPropertyName;
        ConditioningPropertyValue = conditioningPropertyValue;
    }

    public string ConditioningPropertyName { get; set; }
    public object ConditioningPropertyValue { get; set; }
}
