namespace Parsec.Shaiya.Skill
{
    public enum SkillUtilizer
    {
        /// <summary>
        /// Skill can be used only by humans.
        /// </summary>
        Human,

        /// <summary>
        /// Skill can be used only by elves.
        /// </summary>
        Elf,

        /// <summary>
        /// Skill can be used only by both humans and elves.
        /// </summary>
        Light,

        /// <summary>
        /// Skill can be used only by deatheaters.
        /// </summary>
        Deatheater,

        /// <summary>
        /// Skill can be used only by vails.
        /// </summary>
        Vail,

        /// <summary>
        /// Skill can be used only by both deatheaters and vails.
        /// </summary>
        Fury,

        /// <summary>
        /// Skill can be used by any profession in any fraction.
        /// </summary>
        AllFractions
    }
}
