namespace Parsec.Shaiya.Skill;

public enum UserFamily : long
{
    /// <summary>
    /// Skill can only be used by the Human family.
    /// </summary>
    Human,

    /// <summary>
    /// Skill can only be used by the Elf family.
    /// </summary>
    Elf,

    /// <summary>
    /// Skill can be used only by the Alliance of Light faction (both Human and Elf families).
    /// </summary>
    Light,

    /// <summary>
    /// Skill can only be used by the DeathEater family.
    /// </summary>
    DeathEater,

    /// <summary>
    /// Skill can only be used by the Vail family.
    /// </summary>
    Vail,

    /// <summary>
    /// Skill can only be used by the Union of Fury faction (both DeathEater and Vail families).
    /// </summary>
    Fury,

    /// <summary>
    /// Skill can be used by all families from both factions.
    /// </summary>
    AllFactions
}
