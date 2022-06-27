namespace Parsec.Shaiya.Skill
{
    public enum StateType
    {
        None = 0,

        /// <summary>
        /// Sleep means can not move and attack.
        /// </summary>
        Sleep = 1,

        /// <summary>
        /// Stun means can not move, attack and use any consumables.
        /// </summary>
        Stun = 2,

        /// <summary>
        /// Darkness means can not make magic attacks.
        /// </summary>
        Darkness = 3,

        /// <summary>
        /// Silence means can not make physical attacks.
        /// </summary>
        Silence = 4,

        /// <summary>
        /// Immobilize means can not move
        /// </summary>
        Immobilize = 5,

        /// <summary>
        /// Slow means target's speed is decreased.
        /// </summary>
        Slow = 6,

        /// <summary>
        /// Constant damage.
        /// </summary>
        FlatDamage = 7,

        /// <summary>
        /// 100% kill.
        /// </summary>
        DeathTouch = 8,

        /// <summary>
        /// HP damage over time.
        /// </summary>
        HPDamageOverTime = 9,

        /// <summary>
        /// SP damage over time.
        /// </summary>
        SPDamageOverTime = 10,

        /// <summary>
        /// MP damage over time.
        /// </summary>
        MPDamageOverTime = 11,

        /// <summary>
        /// Used only in skill "Cursed Hand".
        /// </summary>
        MentalSmasher = 12,

        /// <summary>
        /// Lower attack or defence.
        /// </summary>
        LowerAttackOrDefence = 13,

        /// <summary>
        /// Used only in skill "Tranquilizing Shot" and in mob's skills like "Dull".
        /// </summary>
        DexDecrease = 14,

        /// <summary>
        /// Target's luck is decreased.
        /// </summary>
        Misfortunate = 15
    }
}
