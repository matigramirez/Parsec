namespace Parsec.Shaiya.Skill;

public enum DamageType
{
    /// <summary>
    /// Deals fixed damage, that ignores enemy defense/resistance.
    /// </summary>
    FixedDamage = 0,

    /// <summary>
    /// Deals damage + extra value.
    /// </summary>
    PlusExtraDamage = 1,

    /// <summary>
    /// Deals damage times multiplied by the coefficient.
    /// </summary>
    DamageCoefficient = 2,

    /// <summary>
    /// Suicide attack. Deals damage, that equals target hp.
    /// </summary>
    Eraser = 3,

    /// <summary>
    /// Reduces target's MP by %.
    /// </summary>
    MPPercentageDamage = 4,

    /// <summary>
    /// Reduces target's HP by %.
    /// </summary>
    HPPercentageDamage = 5,

    /// <summary>
    /// Deals damage, equals rec * coefficient.
    /// </summary>
    RecDamageCoefficient = 6,

    /// <summary>
    /// Deals damage, equals rec + extra damage.
    /// </summary>
    RecDamagePlusExtra = 7
}
