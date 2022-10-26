using Parsec.Attributes;
using Parsec.Shaiya.Common;

namespace Parsec.Shaiya.KillStatus;

public sealed class KillStatusRecord
{
    /// <summary>
    /// The faction that will receive the bonus
    /// </summary>
    [ShaiyaProperty]
    public FactionByte Faction { get; set; }

    /// <summary>
    /// The absolute bless value at which the bonuses will take effect
    /// </summary>
    [ShaiyaProperty]
    public int BlessValue { get; set; }

    /// <summary>
    /// The index of this record
    /// </summary>
    [ShaiyaProperty]
    public short Index { get; set; }

    /// <summary>
    /// The bonuses to be applied
    /// </summary>
    [ShaiyaProperty]
    [FixedLengthList(typeof(KillStatusBonus), 6)]
    public List<KillStatusBonus> Bonuses { get; set; } = new();
}
