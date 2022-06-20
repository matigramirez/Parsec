namespace Parsec.Common;

public interface ICsv
{
    /// <summary>
    /// Exports the file in csv format
    /// </summary>
    /// <param name="path">Export file path</param>
    void ExportCSV(string path);
}
