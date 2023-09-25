namespace Parsec.Common;

public interface IExportable<T> : IJsonable<T>
{
    /// <summary>
    /// Writes the file as JSON with the possibility of ignoring some properties
    /// </summary>
    /// <param name="path">Path where to save the json file</param>
    /// <param name="ignoredPropertyNames">Property names to ignore</param>
    void WriteJson(string path, params string[] ignoredPropertyNames);
}
