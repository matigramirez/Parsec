using System.Collections.Generic;

namespace Parsec.Common
{
    public interface IExportable
    {
        /// <summary>
        /// Exports the file as JSON
        /// </summary>
        /// <param name="path">Path where to save the json file</param>
        void Export(string path);

        /// <summary>
        /// Exports the file as JSON with the possibility of ignoring some properties
        /// </summary>
        /// <param name="path">Path where to save the json file</param>
        /// <param name="ignoredPropertyNames">Property names to ignore</param>
        void Export(string path, IEnumerable<string> ignoredPropertyNames);
    }
}
