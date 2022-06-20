namespace Parsec.Common;

public interface IDumpable
{
    /// <summary>
    /// Creates an easy to read file with the original file's content
    /// </summary>
    /// <param name="path">The path of the file to create</param>
    void CreateFriendlyDump(string path);
}
