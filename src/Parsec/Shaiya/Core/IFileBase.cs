using Parsec.Common;

namespace Parsec.Shaiya.Core;

public interface IFileBase
{
    /// <summary>
    /// Reads and parses the file
    /// </summary>
    /// <param name="options">Reading options</param>
    void Read(params object[] options);

    /// <summary>
    /// Writes the file to its original format
    /// </summary>
    /// <param name="path">Path where to write the file</param>
    /// <param name="episode">The desired output format</param>
    void Write(string path, Episode episode = Episode.Unknown);

    /// <summary>
    /// Gets the serialized file data
    /// </summary>
    /// <param name="episode">The desired file episode</param>
    IEnumerable<byte> GetBytes(Episode episode = Episode.Unknown);
}
