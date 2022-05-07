namespace Parsec.Shaiya.Core
{
    public interface IEncryptable
    {
        /// <summary>
        /// Decrypts the file's buffer
        /// </summary>
        void DecryptBuffer(bool validateChecksum = false);

        /// <summary>
        /// Gets the encrypted file bytes 
        /// </summary>
        byte[] GetEncryptedBytes(params object[] options);

        /// <summary>
        /// Writes the file with encryption
        /// </summary>
        /// <param name="path">Save path</param>
        /// <param name="options">Extra options</param>
        void WriteEncrypted(string path, params object[] options);

        /// <summary>
        /// Writes the file without encryption
        /// </summary>
        /// <param name="path">Save path</param>
        /// <param name="options">Extra options</param>
        void WriteDecrypted(string path, params object[] options);
    }
}
