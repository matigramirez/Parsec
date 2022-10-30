using Parsec.Common;
using Parsec.Shaiya.SData;

namespace Parsec.Shaiya.Core;

public interface IEncryptable
{
    /// <summary>
    /// Decrypts the file's buffer
    /// </summary>
    void DecryptBuffer(bool validateChecksum = false);

    /// <summary>
    /// Gets the encrypted file bytes
    /// </summary>
    byte[] GetEncryptedBytes(Episode episode = Episode.Unknown, SDataVersion version = SDataVersion.Regular);

    /// <summary>
    /// Writes the file with encryption
    /// </summary>
    /// <param name="path">Save path</param>
    /// <param name="episode">The desired episode</param>
    void WriteEncrypted(string path, Episode episode = Episode.Unknown, SDataVersion version = SDataVersion.Regular);

    /// <summary>
    /// Writes the file without encryption
    /// </summary>
    /// <param name="path">Save path</param>
    /// <param name="episode">The desired episode</param>
    void WriteDecrypted(string path, Episode episode = Episode.Unknown);
}
