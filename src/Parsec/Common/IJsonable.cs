namespace Parsec.Common;

/// <summary>
/// Interface that defines the behavior of files that can be exported as json
/// </summary>
public interface IJsonable<T>
{
    /// <summary>
    /// Serializes an object into json
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <param name="ignoredPropertyNames">Array of property names that should be excluded from the serialization</param>
    /// <returns>The serialized object as a json string</returns>
    string JsonSerialize(T obj, params string[] ignoredPropertyNames);
}
