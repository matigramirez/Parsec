using System.Text.Json;

namespace Parsec.Json;

public static class ParsecJsonWriter
{
    public static void WriteJson<T>(this T instance, string path) where T : class
    {
        var json = JsonSerializer.Serialize(instance, typeof(T), ParsecJsonSerializerContext.Default);
        File.WriteAllText(path, json);
    }
}
