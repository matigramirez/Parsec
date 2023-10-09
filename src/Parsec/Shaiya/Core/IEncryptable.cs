using Parsec.Serialization;

namespace Parsec.Shaiya.Core;

public interface IEncryptable
{
    /// <summary>
    /// Decrypts the file's buffer
    /// </summary>
    void DecryptBuffer(SBinaryReader binaryReader, bool validateChecksum = false);

    /// <summary>
    /// Gets the encrypted file bytes
    /// </summary>
    byte[] GetEncryptedBytes();

    /// <summary>
    /// Writes the file with encryption
    /// </summary>
    /// <param name="path">Save path</param>
    void WriteEncrypted(string path);

    /// <summary>
    /// Writes the file without encryption
    /// </summary>
    /// <param name="path">Save path</param>
    void WriteDecrypted(string path);
}
