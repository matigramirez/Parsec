using System.Collections.Generic;

namespace Parsec.Common
{
    public interface IExportable<T> : IJsonable<T>
    {
        /// <summary>
        /// Exports the file as JSON with the possibility of ignoring some properties
        /// </summary>
        /// <param name="path">Path where to save the json file</param>
        /// <param name="ignoredPropertyNames">Property names to ignore</param>
        /// <param name="enumFriendly">Indicates whether enums should be printed as strings for readability purposes</param>
        /// <param name="ignoreDefaults">Indicates whether default values should be skipped</param>
        void ExportJson(string path, IEnumerable<string> ignoredPropertyNames, bool enumFriendly, bool ignoreDefaults);
    }
}
