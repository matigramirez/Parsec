using Parsec.Common;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DefaultVersionAttribute : Attribute
{
    public Episode Episode { get; set; }

    public DefaultVersionAttribute(Episode episode)
    {
        Episode = episode;
    }
}
