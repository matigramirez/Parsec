namespace Parsec.Shaiya.Skill;

public enum Duration : long
{
    /// <summary>
    /// Buff is cleared after death.
    /// </summary>
    ClearAfterDeath,

    /// <summary>
    /// Items such as "EXP stone", "Endurance" etc.
    /// </summary>
    DurationInHours,

    /// <summary>
    /// Items such as "Health Remedy".
    /// </summary>
    DurationInMinutes
}
