namespace Parsec.Shaiya.Core
{
    public interface IEncryptable
    {
        /// <summary>
        /// Encrypts the file's buffer
        /// </summary>
        void EncryptBuffer();

        /// <summary>
        /// Decrypts the file's buffer
        /// </summary>
        void DecryptBuffer();

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
}
