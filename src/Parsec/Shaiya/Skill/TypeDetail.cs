namespace Parsec.Shaiya.Skill
{
    public enum TypeDetail
    {
        None = 0,
        WeaponPowerUp = 1,
        Backpack = 2,
        PassiveDefence = 4,
        Interpretation = 5,
        PotentialDefence = 6, // When character is almost dead, there is such skill, that turns on.
        WeaponMastery = 8, // Passive, that increases weapon attack.
        ShieldMastery = 10, // Passive, that increases defence, when shield is on.
        UniqueHitAttack = 21,
        MultipleHitsAttack = 22,
        Eraser = 23,
        HP_MP_SP_Reduction = 25,
        EnergyDrain = 27, // Like "Mana Leech" or "Health Drain"
        Healing = 41,
        Dispel = 42,
        Sacrifice = 43,
        EmergencySatelliteSupport = 44, // something from new ep?
        PeriodicalDebuff = 61,
        SubtractingDebuff = 62,
        DeathTouch = 63, // Only for mags and pagans
        Stun = 64,
        Immobilize = 65,
        Sleep = 66,
        PreventAttack = 67,
        RemoveAttribute = 68, // Removes element, only for mags and pagans.
        Taunt = 69,
        Provoke = 72,
        EnergyBackhole = 74, // Like "Mental Storm - Lure" or "Black Hole"
        MentalStormConfusion = 75, // Only for rangers and assassins.
        SoulMenace = 76, // Only for archers.
        MentalStormDistortion = 77, // Only for rangers and assassins.
        PeriodicalHeal = 81,
        Buff = 82,
        DamageReflection = 83,
        FireThorn = 84, // Only for mags or priests.
        BlockMagicAttack = 85,
        BlockShootingAttack = 86,
        HealthAssistant = 87, // "Health Pact" or "Ultimate Barrier". Only for mags.
        Stealth = 88, // Only for rangers and assassins.
        Evolution = 90, // All transformation skills.
        AbilityExchange = 91, // "Berserker" or "Bloody Karma". Not used anymore?
        Untouchable = 92,
        Detection = 93, // To get assassins from Stealth. Only for priests.
        ElementalAttack = 94,
        ElementalProtection = 95,
        DanceOfDeath = 96, // Only for rangers and assassins.
        MassAmbush = 97, // Only for mags. Not used anymore?
        EtainShield = 98, // Only for priests.
        Trap = 101,
        Resurrection = 121,
        SoulBurn = 122, // Burns soul of dead body.
        Scouting = 123, // Get element of enemy. Only for rangers/assassins.
        TownPortal = 125,
        MentalImpact = 126, // Only for defenders.
        ThirdEye = 129, // Totem from new ep. Creates mob, that shows hidden players.
        Transformation = 132, // New transformation skill from new ep.
        DungeonMapScroll = 150, // New ep skill, can be used only in dungeons.
        PersistBarrier = 300, // New ep skill, enables not-interrupting casts.
        CurseOfGoddess = 1062
    }
}
