namespace Parsec.Common;

public interface ICsv
{
    /// <summary>
    /// Exports the file in csv format
    /// </summary>
    /// <param name="outputPath">Export file path</param>
    void ExportCsv(string outputPath);
}
