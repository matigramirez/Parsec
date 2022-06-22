using System.IO;
using System.Linq;

namespace Parsec.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Character used as separator by string extensions
    /// </summary>
    private const char _separator = '/';

    /// <summary>
    /// Separates a string based on a separator. If the separator is not specified, the global StringExtensions.Separator will be used instead.
    /// </summary>
    /// <param name="text">Text to separate</param>
    /// <param name="separator">Separator character</param>
    public static string[] Separate(this string text, char? separator = null) =>
        separator == null ? text.Split(_separator) : text.Split((char)separator);

    /// <summary>
    /// The list of invalid characters
    /// </summary>
    private static readonly string _invalidCharacters = new string(Path.GetInvalidPathChars()) + new string(Path.GetInvalidFileNameChars());

    /// <summary>
    /// Checks if a string has invalid characters
    /// </summary>
    /// <param name="str">String to check</param>
    /// <returns>True if it has invalid characters, false if it doesn't</returns>
    public static bool HasInvalidCharacters(this string str) => str.Any(c => _invalidCharacters.Contains(c.ToString()));

    /// <summary>
    /// Converts a string's first character to lowercase
    /// </summary>
    /// <param name="str">String to convert</param>
    public static string ToCamelCase(this string str) => char.ToLowerInvariant(str[0]) + str.Substring(1, str.Length - 1);
}
