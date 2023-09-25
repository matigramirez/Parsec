using System.Text;

namespace Parsec.Common;

public interface ICsv
{
    /// <summary>
    /// Exports the file in csv format
    /// </summary>
    /// <param name="outputPath">Export file path</param>
    /// <param name="encoding">File encoding</param>
    void WriteCsv(string outputPath, Encoding encoding = null);
}
