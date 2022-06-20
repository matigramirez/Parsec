using Parsec.Common;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ShaiyaPropertyAttribute : Attribute
{
    public Episode MinEpisode { get; set; }
    public Episode MaxEpisode { get; set; }

    public ShaiyaPropertyAttribute()
    {
    }

    public ShaiyaPropertyAttribute(Episode MinEpisode)
    {
        this.MinEpisode = MinEpisode;
    }

    public ShaiyaPropertyAttribute(Episode MinEpisode, Episode MaxEpisode)
    {
        this.MinEpisode = MinEpisode;
        this.MaxEpisode = MaxEpisode;
    }
}
