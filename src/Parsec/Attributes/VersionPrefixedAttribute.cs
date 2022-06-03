using System;
using Parsec.Common;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class VersionPrefixedAttribute : Attribute
{
    public string Prefix { get; set; }
    public Episode MinEpisode { get; set; }
    public Episode MaxEpisode { get; set; } = Episode.Unknown;

    public VersionPrefixedAttribute(string prefix, Episode minEpisode)
    {
        Prefix = prefix;
        MinEpisode = minEpisode;
    }

    public VersionPrefixedAttribute(string prefix, Episode minEpisode, Episode maxEpisode)
    {
        Prefix = prefix;
        MinEpisode = minEpisode;
        MaxEpisode = maxEpisode;
    }
}
