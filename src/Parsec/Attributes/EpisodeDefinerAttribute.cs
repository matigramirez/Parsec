using Parsec.Common;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class EpisodeDefinerAttribute : Attribute
{
    public Episode Episode { get; set; }
    public object Value { get; set; }

    public EpisodeDefinerAttribute(Episode episode, object value)
    {
        Episode = episode;
        Value = value;
    }
}
