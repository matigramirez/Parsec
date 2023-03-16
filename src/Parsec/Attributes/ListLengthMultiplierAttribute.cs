using Parsec.Common;

namespace Parsec.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal sealed class ListLengthMultiplierAttribute : Attribute
{
    public Episode Episode { get; set; }
    public int Multiplier { get; set; }

    public ListLengthMultiplierAttribute(Episode episode, int multiplier)
    {
        Episode = episode;
        Multiplier = multiplier;
    }
}
