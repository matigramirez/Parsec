using System.IO;
using System.Linq;

namespace Parsec.Helpers;

public static class CsvHelper
{
    private const char ColumnDelimiter = ',';
    private const char RowDelimiter = '\n';
    private const char EscapeCharacter = '"';

    public static List<string> ReadColumnNames(string filePath)
    {
        var text = File.ReadLines(filePath);
        var columnNames = ParseRow(text.First().AsSpan());
        return columnNames;
    }

    private static List<string> ParseRow(ReadOnlySpan<char> text)
    {
        var values = new List<string>();

        int i = 0;

        while (i < text.Length)
        {
            var t = text.Slice(i, text.Length - i);
            var value = ReadColumnValue(t);
            i += value.Length + 1;
            values.Add(value.ToString());
        }

        return values;
    }

    private static ReadOnlySpan<char> ReadColumnValue(ReadOnlySpan<char> text)
    {
        bool readUntilNextEscape = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == EscapeCharacter)
                readUntilNextEscape = !readUntilNextEscape;

            // Reading should be done until the column delimiter is reached.
            // In case the escape character precedes the column delimiter, reading should continue.
            if (text[i] == ColumnDelimiter && !readUntilNextEscape)
                return text.Slice(0, i);
        }

        return text;
    }
}
