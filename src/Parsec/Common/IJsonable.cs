using System.Collections.Generic;

namespace Parsec.Common
{
    /// <summary>
    /// Interface that defines the behavior of files that can be exported as json
    /// </summary>
    public interface IJsonable<T>
    {
        /// <summary>
        /// Serializes an object into json
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <param name="ignoredPropertyNames">List of property names that should be excluded from the serialization</param>
        /// <param name="enumFriendly">Indicates whether enums should be printed as strings for readability purposes</param>
        /// <param name="ignoreDefaults">Indicates whether default values should be skipped</param>
        /// <returns>The serialized object as a json string</returns>
        string JsonSerialize(T obj, IEnumerable<string> ignoredPropertyNames, bool enumFriendly, bool ignoreDefaults);
    }
}
