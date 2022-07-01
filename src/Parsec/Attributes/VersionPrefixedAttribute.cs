using Parsec.Common;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class VersionPrefixedAttribute : Attribute
{
    public Type PrefixType { get; set; }
    public object Prefix { get; set; }
    public Episode MinEpisode { get; set; }
    public Episode MaxEpisode { get; set; } = Episode.Unknown;

    public VersionPrefixedAttribute(Type prefixType, object prefix, Episode minEpisode)
    {
        PrefixType = prefixType;
        Prefix = prefix;
        MinEpisode = minEpisode;
    }

    public VersionPrefixedAttribute(Type prefixType, object prefix, Episode minEpisode, Episode maxEpisode)
    {
        PrefixType = prefixType;
        Prefix = prefix;
        MinEpisode = minEpisode;
        MaxEpisode = maxEpisode;
    }
}
