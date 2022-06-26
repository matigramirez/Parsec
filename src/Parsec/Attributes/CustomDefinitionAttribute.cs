namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class CustomDefinitionAttribute : Attribute
{
    public CustomDefinitionAttribute(Func<object> read, Func<IEnumerable<byte>> getBytes)
    {
        Read = read;
        GetBytes = getBytes;
    }

    public Func<object> Read { get; set; }
    public Func<IEnumerable<byte>> GetBytes { get; set; }
}
