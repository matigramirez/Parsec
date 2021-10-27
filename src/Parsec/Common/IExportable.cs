using System.Collections.Generic;

namespace Parsec.Common
{
    public interface IExportable
    {
        void Export(string path);

        void Export(string path, IEnumerable<string> ignoredPropertyNames);
    }
}
