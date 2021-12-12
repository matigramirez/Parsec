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
    }
}
