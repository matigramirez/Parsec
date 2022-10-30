using Parsec.Attributes;

namespace Parsec.Shaiya.KillStatus;

public sealed class KillStatusBonus
{
    /// <summary>
    /// The type of bonus
    /// </summary>
    [ShaiyaProperty]
    public KillStatusBonusType Type { get; set; }

    /// <summary>
    /// The value of the bonus
    /// </summary>
    [ShaiyaProperty]
    public short Value { get; set; }
}
