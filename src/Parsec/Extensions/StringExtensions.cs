using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parsec.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Character used as separator by string extensions
        /// </summary>
        public static char Separator { get; set; } = '/';

        /// <summary>
        /// Separates a string based on a separator. If the separator is not specified, the global StringExtensions.Separator will be used instead.
        /// </summary>
        /// <param name="text">Text to separate</param>
        /// <param name="separator">Separator character</param>
        public static List<string> Separate(this string text, char? separator = null) =>
            separator == null ? text.Split(Separator).ToList() : text.Split((char)separator).ToList();

        private static readonly string _invalidCharacters = new string(Path.GetInvalidPathChars()) + new string(Path.GetInvalidFileNameChars());

        public static bool HasInvalidCharacters(this string text)
        {
            foreach (char c in text)
            {
                if (_invalidCharacters.Contains(c))
                    return true;
            }

            return false;
        }

        public static string ToCamelCase(this string text) => char.ToLowerInvariant(text[0]) + text[1..];
    }
}
