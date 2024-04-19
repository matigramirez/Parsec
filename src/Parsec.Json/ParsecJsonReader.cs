using System.Text.Json;

namespace Parsec.Json;

public static class ParsecJsonReader
{
    public static T? FromJsonFile<T>(string path) where T : class
    {
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = ParsecJsonSerializerContext.Default
        };

        return JsonSerializer.Deserialize<T>(File.ReadAllText(path), options);
    }
}
